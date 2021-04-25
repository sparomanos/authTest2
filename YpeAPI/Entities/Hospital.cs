using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YpeAPI.Entities
{
    public class Hospital
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string ClientId { get; set; }
    }
}