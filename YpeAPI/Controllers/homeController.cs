using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace YpeAPI.Controllers
{

    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {
        [Route("")]
        public string Get()
        {
            return "Ype API";
        }
    }
}
