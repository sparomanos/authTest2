using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Hospital { get; set; }
        public string UniqueDoctorId { get; set; }
    }
}