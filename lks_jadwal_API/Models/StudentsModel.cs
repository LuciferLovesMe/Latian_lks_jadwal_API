using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace lks_jadwal_API.Models
{
    public class StudentsModel
    {
        public string name { set; get; }
        public int id { set; get; }
        public string address { set; get; }
        public string date { set; get; }
        public string hp { set; get; }
        public string classname { set; get; }
        public string username { set; get; }
    }
}