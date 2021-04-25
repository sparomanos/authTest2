using AuthAPI.Entities;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AuthAPI.Providers
{
    public class CustomOAuthProvider: OAuthAuthorizationServerProvider
    {
        private List<User> _userList;
        public CustomOAuthProvider()
        {
            _userList = new List<User>();
            _userList.Add(new User() { Id = 1, UserName = "ype", Password = "1234", FullName = "YPE", Role = "api", Hospital = "YPE API", UniqueDoctorId = "" });
            _userList.Add(new User() { Id = 2, UserName = "doctor1", Password = "1234", FullName = "DOCTOR 1", Role = "Doctor", Hospital = "HOSPITAL 1", UniqueDoctorId = "123231323" });
            _userList.Add(new User() { Id = 3, UserName = "doctor2", Password = "1234", FullName = "DOCTOR 2", Role = "Doctor", Hospital = "HOSPITAL 2", UniqueDoctorId = "129976321" });
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            string symmetricKeyAsBase64 = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                context.SetError("invalid_clientId", "client_Id is not set");
                return Task.FromResult<object>(null);
            }

            var audience = AudiencesStore.FindAudience(context.ClientId);

            if (audience == null)
            {
                context.SetError("invalid_clientId", string.Format("Invalid client_id '{0}'", context.ClientId));
                return Task.FromResult<object>(null);
            }

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            User user = _userList.Find(x => x.UserName == context.UserName && x.Password == context.Password);
            if (user is null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect");
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity("JWT");

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
            identity.AddClaim(new Claim("hospital", user.Hospital));
            identity.AddClaim(new Claim("doctor_unique_id", user.UniqueDoctorId));

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                         "audience", (context.ClientId == null) ? string.Empty : context.ClientId
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }
    }
}