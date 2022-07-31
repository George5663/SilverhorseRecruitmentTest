using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverhorseRecruitmentTest.Models
{
    public class Address
    {
        public string city { get; set; }
        public string street { get; set; }
        public string suite { get; set; }
        public string zipcode { get; set; }
        public Geolocation geo { get; set; }
    }
}