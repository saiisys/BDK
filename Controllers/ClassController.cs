using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDK.DB;
using System.Collections;
namespace BDK.Controllers
{
    public class ClassController : Controller
    {
        //
        // GET: /Class/

        CollegeDBEntities db = new CollegeDBEntities();

        public ActionResult Index()
        {

          
            return View("Class");
        }

        public ActionResult Save(Class obj)
        {
            if (obj.ClassId  == 0)
            {
                obj.ClassId = Convert.ToInt32(db.Classes.Max(m => (int?)m.ClassId ) ?? 0) + 1;
                obj.sessionName = "2013-2014";
                obj.UpdateBy = Session["User"].ToString();
                obj.UpdateDate = DateTime.Now.Date;
                db.Classes.Add(obj);


            }
            db.SaveChanges();
            ModelState.Clear();

            return View("Class");
        }



        public static List<SelectListItem> FillCombo()
        {
             SelectListItem s ;

             s = new SelectListItem();
             s.Text = "------Select Courses Type--------";
             s.Value = "0";
             s.Selected = true;
              
            var clientIDs = new CollegeDBEntities().CoursesTypes.Select(x => new { x.CoursesName, x.ID });
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(s);
            foreach (var t in clientIDs)
            {
              s = new SelectListItem();
                s.Text = t.CoursesName.ToString();
                s.Value = t.ID.ToString();
                
                items.Add(s);
            }
           

         
            return items;
        }
        

    }
}
