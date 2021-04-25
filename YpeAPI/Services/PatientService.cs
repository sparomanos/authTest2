using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using YpeAPI.Entities;
using YpeAPI.Helpers;

namespace YpeAPI.Services
{
    public class PatientService
    {
        public async Task<List<PatientExam>> GetPatients()
        {
            try
            {
                var token = await new AuthCaller().GetAuthToken();

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    client.BaseAddress = new Uri(ApiSettings.ClientUrl);
                    var response = await client.GetAsync("/api/patientExam");
                    List<PatientExam> exams = JsonConvert.DeserializeObject<List<PatientExam>>(response.Content.ReadAsStringAsync().Result);
                    return exams;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}