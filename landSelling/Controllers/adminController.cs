using AutoMapper;
using landSelling.Authorization;
using landSelling.Models.Database;
using landSelling.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace landSelling.Controllers
{
    [Authorize]
    public class adminController : Controller
    {
        // GET: dashboard
        [AdminAccess]
        public ActionResult Dashboard()
        {
            return View();
        }

        [AdminAccess]
        public ActionResult ViewPost()
        {
            var db = new landSellingEntities();
            var postList = db.posts.ToList();
            return View(postList);
        }

        [AdminAccess]
        public ActionResult PostDetails(int id)
        {
            var db = new landSellingEntities();
            var post = (from e in db.posts
                        where e.id == id
                        select e).FirstOrDefault();
            post.mark = "read";
            db.SaveChanges();
            var ddb = new landSellingEntities();
            var userlist = ddb.sellers;
            var u = (from e in userlist
                     where e.uid == post.uid
                     select e).ToList();
            ViewBag.post = post;
            //ViewBag.ulist = u;
            /*var ddb = new landSellingEntities();
            var config = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<user, userModel>();
                    cfg.CreateMap<seller, sellerModel>();
                }
                );
            var userlist = db.sellers.ToList();
            Mapper mapper = new Mapper(config);
            var data = mapper.Map<List<usModel>>(userlist);*/
            return View(u);
        }
        [AdminAccess]
        public ActionResult AcceptPost(int id)
        {
            var db = new landSellingEntities();
            var post = (from e in db.posts
                        where e.id == id
                        select e).FirstOrDefault();
            post.status = "Approve";
            db.SaveChanges();
            return RedirectToAction("PostDetails", new { @id = id });
        }
        [AdminAccess]
        public ActionResult DeletePost(int id)
        {
            var db = new landSellingEntities();
            var post = (from e in db.posts
                        where e.id == id
                        select e).FirstOrDefault();
            db.posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("ViewPost");
        }
        public ActionResult MakePending(int id)
        {
            var db = new landSellingEntities();
            var post = (from e in db.posts
                        where e.id == id
                        select e).FirstOrDefault();
            post.status = "pending";
            db.SaveChanges();
            return RedirectToAction("PostDetails", new { @id = id });
        }
        



    }
}