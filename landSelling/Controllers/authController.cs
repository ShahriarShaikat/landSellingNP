using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using landSelling.Models.Database;
using landSelling.Models.Entity;

namespace landSelling.Controllers
{
    public class authController : Controller
    {
        // GET: auth
        [HttpGet]
        public ActionResult Login()
        {
            return View(new userModel());
        }
        [HttpPost]
        public ActionResult Login(userModel u)
        {
            if (ModelState.IsValid)
            {
                var db = new landSellingEntities();
                /*var orders = db.users.ToList();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<user, userModel>();
                }
                );
                var mapper = new Mapper(config);
                var data = mapper.Map<List<user>>(orders);*/
                var val = (from e in db.users
                           where e.username.Equals(u.username) &&
                           e.password.Equals(u.password)
                           select e).FirstOrDefault();
                if (val != null)
                {
                    FormsAuthentication.SetAuthCookie(val.username, false);
                    Session["UserName"] = val.username;
                    Session["UserType"] = val.role;
                    if (val.role.Equals("admin"))
                    {
                        return RedirectToAction("Dashboard", "admin");
                    }
                    else if (val.role.Equals("employee"))
                    {
                        return RedirectToAction("Dashboard", "admin");
                    }
                    else if (val.role.Equals("buyer"))
                    {
                        //
                    }
                    else if (val.role.Equals("seller"))
                    {
                        return RedirectToAction("ViewProfile", "seller");
                    }
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult SignUpAsSeller()
        {
            ViewBag.err = null;
            return View(new userSellerModel());
        }
        [HttpPost]
        public ActionResult SignUpAsSeller(userSellerModel value)
        {
            if (ModelState.IsValid)
            {
                if (value.password == value.password2)
                {
                    var db = new landSellingEntities();
                    var u = new user();
                    u.username = value.username;
                    u.password = value.password;
                    u.role = "seller";
                    db.users.Add(u);
                    db.SaveChanges();
                    var s = new seller();
                    s.uid = u.id;
                    s.name = value.name;
                    s.email = value.email;
                    s.phone = value.phone;
                    s.presentaddress = value.presentaddress;
                    s.permanentaddress = value.permanentaddress;
                    s.facebooklink = value.facebooklink;
                    s.whatsappno = value.whatsappno;
                    s.occupation = value.occupation;
                    db.sellers.Add(s);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.err = "Password doesn't match!";
                    RedirectToAction("SignUpAsSeller");
                }

            }
            return View(value);
        }
        [HttpGet]
        public ActionResult SignUpAsBuyer()
        {
            ViewBag.err = null;
            return View(new userBuyerModel());
        }
        [HttpPost]
        public ActionResult SignUpAsBuyer(userBuyerModel value)
        {
            if (ModelState.IsValid)
            {
                if (value.password == value.password2)
                {
                    var db = new landSellingEntities();
                    var u = new user();
                    u.username = value.username;
                    u.password = value.password;
                    u.role = "buyer";
                    db.users.Add(u);
                    db.SaveChanges();
                    var s = new buyer();
                    s.uid = u.id;
                    s.name = value.name;
                    s.email = value.email;
                    s.occupation = value.occupation;
                    s.netincome = value.netincome;
                    db.buyers.Add(s);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.err = "Password doesn't match!";
                    return RedirectToAction("SignUpAsBuyer");
                }
            }
         return View(value);
        }
    }
}