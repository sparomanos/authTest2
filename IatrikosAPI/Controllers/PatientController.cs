using IatrikosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace IatrikosAPI.Controllers
{
    [Authorize]
    public class PatientController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetPatientExams()
        {
            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient() { AMKA = "727277272", FullName = "patient full name 1" });
            patients.Add(new Patient() { AMKA = "7234272", FullName = "patient full name 1" });
            return Ok(patients);
        }
    }
}
