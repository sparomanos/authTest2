using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using YpeAPI.Entities;

namespace YpeAPI.Helpers
{
    public class AuthCaller
    {
        public async Task<string> GetAuthToken()
        {
            try
            {
                var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>( "grant_type", "password" ),
                        new KeyValuePair<string, string>( "username", "ype" ),
                        new KeyValuePair<string, string> ( "Password", "1234" ),
                        new KeyValuePair<string, string> ( "client_id", "ddf5d71b56b24347bbe2b95cca2e9533" )
                    };
                var content = new FormUrlEncodedContent(pairs);
               
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync(ApiSettings.AuthUrl + "/oauth2/token", content);
                    var token=JsonConvert.DeserializeObject<Token>(response.Content.ReadAsStringAsync().Result);
                    return token.access_token;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}