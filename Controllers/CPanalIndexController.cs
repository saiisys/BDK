using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using MvcDemoRestorent.Models;
using MvcDemoRestorent.DB;
namespace MvcDemoRestorent.Controllers.Cpanal
{
    public class CPanalIndexController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
        

        //[SessionState(SessionStateBehavior.Default] 
        [HttpPost]
        public ActionResult Login()
        {
            Loginclass obj = new Loginclass();


            if (obj.CheckLogin(Request["username"].ToString(), Request["password"].ToString()) == true)
            {
                Session["User"] = (Request["username"].ToString());
                //globalvar.globallogin = Session["User"].ToString();
                //TempData["user"] = globalvar.globallogin;

                return View("dashboard");
            }
            else
            {
                ViewBag.msg = "Username and Password is Incorrect.!";
                return View("Index");
            }
          
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return View("Index");
        }

        //[HttpPost]
        //public ActionResult AddCategory()
        //{
        //    return View("Category");
        //}

        public ActionResult Deshboard()
        {
            return View("dashboard");
        }

    }
}
