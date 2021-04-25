using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using YpeAPI.Helpers;

namespace YpeAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/patients")]
    public class PatientController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetPatients()
        {
            
            return Ok();
        }
    }
}
