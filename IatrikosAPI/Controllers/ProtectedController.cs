using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace IatrikosAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/protected")]
    public class ProtectedController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var identity = User.Identity as ClaimsIdentity;

             var claims= (identity.Claims.Select(c => new
                        {
                            Type = c.Type,
                            Value = c.Value
                        }));
            return  Ok(claims);
        }
    }
}
