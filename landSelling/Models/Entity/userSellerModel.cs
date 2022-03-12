using landSelling.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace landSelling.Models.Entity
{
    public class userSellerModel
    {
        public int id { get; set; }
        public int uid { get; set; }

        [Required(ErrorMessage = "Field couldn't be empty!")]
        public string name { get; set; }

        [Required(ErrorMessage = "Field couldn't be empty!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Field couldn't be empty!")]
        public int phone { get; set; }

        [Required(ErrorMessage = "Field couldn't be empty!")]
        public string presentaddress { get; set; }

        [Required(ErrorMessage = "Field couldn't be empty!")]
        public string permanentaddress { get; set; }
        public string facebooklink { get; set; }
        public Nullable<int> whatsappno { get; set; }
        public string occupation { get; set; }

        [Required(ErrorMessage = "Please provide your Username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please provide your password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please re-type your password")] 
        public string password2 { get; set; }
    }
}