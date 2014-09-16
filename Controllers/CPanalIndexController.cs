using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using BDK.Models;
using BDK.DB;
using System.Web.Security;
namespace BDK.Controllers.Cpanal
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
                FormsAuthentication.SetAuthCookie(Session["User"].ToString(), false); 

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
            FormsAuthentication.SignOut();
            return View("Index");
        }

        //[HttpPost]
        //public ActionResult AddCategory()
        //{
        //    return View("Category");
        //}
        [Authorize]
        public ActionResult Deshboard()
        {
            return View("dashboard");
        }

    }
}
