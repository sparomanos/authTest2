using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YpeAPI.Entities;

namespace YpeAPI.Helpers
{
    public class mockContext
    {
        public static List<Hospital> GetHospitals()
        {
            List<Hospital> hospitals = new List<Hospital>();
            hospitals.Add(new Hospital() { Id = 1, HospitalName = "Hospital 2", ClientId = "" });
            hospitals.Add(new Hospital() { Id = 2, HospitalName = "Hospital 2", ClientId = "" });
            return hospitals;
        }
    }
}