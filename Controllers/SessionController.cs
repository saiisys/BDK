using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BDK.Models;
using BDK.DB;
namespace BDK.Controllers
{
    public class SessionController : Controller
    {
        CollegeDBEntities db = new CollegeDBEntities();
        IEnumerable<Session> lsession;

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        //public PartialViewResult _CustomerCreate()
        //{
        //    var lsession = db.Sessions;
        //    ModelState.Clear();
        //    return PartialView("SessionGridP", lsession);
        //}
        [Authorize]
        [HttpPost]
        public ActionResult Save(Session objses)
        {
            lsession = new List<Session>();
            if (ModelState.IsValid == true)
            {
                if (objses.SessionId == 0)
                {
                    objses.SessionId = Convert.ToInt32(db.Sessions.Max(x => (int?)x.SessionId) ?? 0) + 1;                
                    objses.UpdateBy = Session["User"].ToString();
                    objses.UpdateDate = DateTime.Now.Date;
                    db.Sessions.Add(objses);                   
                }
                else
                {
                    Session _session = db.Sessions.Where(p => p.SessionId == objses.SessionId).FirstOrDefault();


                    if (_session != null)
                    {
                        db.Entry(_session).CurrentValues.SetValues(objses);
                    }
                    

                }

                db.SaveChanges();
                ModelState.Clear();

               
            }
                return View("index");
            
        }

        [Authorize]
        public ActionResult EditSession(int id)
        {
           
               Session _session= db.Sessions.SingleOrDefault(s => s.SessionId == id);
               
               lsession = db.Sessions.ToList();
               ViewBag.SessionList = lsession;
               return View("index",_session);
            
        }
        public static List<Session> FillGrid()
        {
            return (new CollegeDBEntities().Sessions.OrderByDescending(x => x.SessionId).ToList());


        }
    }
}
