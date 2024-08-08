using Ajaxsignup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace Ajaxsignup.Controllers
{
    public class HomeController : Controller
    {
        RegistrationEntities db = new RegistrationEntities();


        public ActionResult Index()
        {
            var data = db.Signups.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(string q)
        {
            if (string.IsNullOrEmpty(q) ==  false)
            {
                List<Signup> s =  db.Signups.Where(model => model.firstname.StartsWith(q)).ToList();
                return PartialView("_searchdata",s);
            }
            else
            {
                List<Signup> s = db.Signups.ToList();
                return PartialView("_searchdata", s);
            }
            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Signup p)
        {
            if (ModelState.IsValid) 
            {
                db.Signups.Add(p);
               int a = db.SaveChanges();
                if (a > 0) 
                {
                    return Json("Data Inserted");
                }
                else
                {
                    return Json("Data not Insterted");
                }

            }
            return View();
        }

    }
}