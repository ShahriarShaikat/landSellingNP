using landSelling.Authorization;
using landSelling.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace landSelling.Controllers
{
    [Authorize]
    public class sellerController : Controller
    {
        // GET: seller

        /* public ActionResult Index()
         {
             var db = new landSellingEntities();
             var data = db.posts.ToList();
             return View(data);
         }*/
        public ActionResult ViewProfile()
        {
            /*var s = Session["UserName"];
            var ddb = new landSellingEntities();
            var u = (from e in ddb.sellers
                     where e.user.username.Equals(s.ToString())
                     select e).FirstOrDefault();*/

            return View();
        }
        [sellerAccess]
        public ActionResult AddPost()
        {
            return View(new post());
        }
        [HttpPost]

        public ActionResult AddPost(post p)
        {
            if (ModelState.IsValid)
            {
                var db = new landSellingEntities();
                var usernameV = Session["UserName"].ToString();
                var userid = (from e in db.sellers
                              where e.user.username.Equals(usernameV)
                              select e).FirstOrDefault();
                p.uid = userid.uid;
                p.mark = "unread";
                p.status = "pending";
                db.posts.Add(p);
                db.SaveChanges();
                return RedirectToAction("DisplayPost");
            }
            return View();
        }

        public ActionResult DisplayPost()
        {
            var db = new landSellingEntities();
            var data = db.posts.ToList();
            return View(data);
        }
    }

}