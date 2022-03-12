using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace landSelling.Models.Entity
{
    public class usModel : userModel
    {
        public List<sellerModel> sellerList { set; get; }

        public usModel()
        {
            sellerList = new List<sellerModel>();
        }

    }
}