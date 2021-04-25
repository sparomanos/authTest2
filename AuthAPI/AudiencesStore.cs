using AuthAPI.Entities;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace AuthAPI
{
    public class AudiencesStore
    {
        public static ConcurrentDictionary<string, Audience> AudiencesList = new ConcurrentDictionary<string, Audience>();

        static AudiencesStore()
        {
            AudiencesList.TryAdd("099153c2625149bc8ecb3e85e03f0022",
                                new Audience
                                {
                                    ClientId = "099153c2625149bc8ecb3e85e03f0022",
                                    Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw",
                                    Name = "YPE api"
                                });

            AudiencesList.TryAdd("ddf5d71b56b24347bbe2b95cca2e9533",
                                new Audience
                                {
                                    ClientId = "ddf5d71b56b24347bbe2b95cca2e9533",
                                    Base64Secret = "uqj742swYW6RwtoMgt8SiYFYK985Tb6UXZQurrffY1k",
                                    Name = "client iatrikou 1"
                                });

            AudiencesList.TryAdd("567d3cdc3b204eaba23625d652b2dea8",
                                new Audience
                                {
                                    ClientId = "567d3cdc3b204eaba23625d652b2dea8",
                                    Base64Secret = "62LsAk1-LUB2nu3ypUHDTKTLUWME2QnsinMWvrOQ6p4",
                                    Name = "client iatrikou 2"
                                });
        }

        public static Audience AddAudience(string name)
        {
            var clientId = Guid.NewGuid().ToString("N");

            var key = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(key);
            var base64Secret = TextEncodings.Base64Url.Encode(key);

            Audience newAudience = new Audience { ClientId = clientId, Base64Secret = base64Secret, Name = name };
            AudiencesList.TryAdd(clientId, newAudience);
            return newAudience;
        }

        public static Audience FindAudience(string clientId)
        {
            Audience audience = null;
            if (AudiencesList.TryGetValue(clientId, out audience))
            {
                return audience;
            }
            return null;
        }
    }
}