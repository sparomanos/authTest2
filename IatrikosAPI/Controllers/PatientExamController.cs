using IatrikosAPI.Models;
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
    public class PatientExamController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetPatientExams()
        {
            try
            {
                List<PatientExam> exams = new List<PatientExam>();
                exams.Add(new PatientExam() { Id = 1, PatientId = 1, Result = "Result 1" });
                exams.Add(new PatientExam() { Id = 2, PatientId = 1, Result = "Result 1" });
                return Ok(exams);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
