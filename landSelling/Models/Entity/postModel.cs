using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace landSelling.Models.Entity
{
    public class postModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string quantity { get; set; }
        public string status { get; set; }
        public string mark { get; set; }
        public System.DateTime date { get; set; }
        public int uid { get; set; }
        public string location { get; set; }
        public userModel userid { get; set; }
    }
}