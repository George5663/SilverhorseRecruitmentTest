using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverhorseRecruitmentTest.Models
{
    public class Users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
    }
}