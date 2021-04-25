using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using YpeAPI.Services;

namespace YpeAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/patientExams")]
    public class PatientExamController : ApiController
    {
        [Route("")]
        public async Task<IHttpActionResult> GetPatientExams()
        {
            try
            {
                PatientService patientService = new PatientService();
                var resonse = await patientService.GetPatients();
                return Ok(resonse);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
