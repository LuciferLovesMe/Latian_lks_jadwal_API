using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lks_jadwal_API.Models
{
    public class AddStudentsModel
    {
        public int id { set; get; }
        public string name { set; get; }
        public string address { set; get; }
        public string gender { set; get; }
        public DateTime dob { set; get; }
        public string hp { set; get; }
        public string classid { set; get; }

    }
}