using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YpeAPI.Entities
{
    public class PatientExam
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Result { get; set; }
    }
}