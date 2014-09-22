using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDK.DB;

namespace BDK.Controllers
{
    [Authorize]
    public class CourceTypeController : Controller
    {
        //
        // GET: /CourceType/

        CollegeDBEntities db = new CollegeDBEntities();

      
        public ActionResult Index()
        {
          
               
                return View("CourceT");
            
        }

    
        public ActionResult Save(CoursesType obj)
        {
           // if (ModelState.IsValid == true)
            //{
                if (obj.ID  == 0)
                {
                    obj.ID = Convert.ToInt32 ( db.CoursesTypes.Max(m =>(int ?) m.ID )?? 0) + 1;
                    obj.Sessionname = "2013-2014";
                    obj.UpdateBy = Session["User"].ToString();
                    obj.UpdateDate = DateTime.Now.Date;
                    db.CoursesTypes.Add(obj);


                }
                else
                {
                    CoursesType _courses = db.CoursesTypes.Where(x => x.ID == obj.ID).FirstOrDefault();

                    if (_courses != null)
                    {
                        // _cast.CastName = obj.CastName;
                        db.Entry(_courses).CurrentValues.SetValues(obj);
                    }

                }

                db.SaveChanges();
                ModelState.Clear();

                
          // }
           
            return View("CourceT");

        }

      
        public ActionResult Edit(int id)
        {
            //CoursesType  _Cource = db.CoursesTypes.Where(m => m.ID == id);
            CoursesType _Cource = db.CoursesTypes.SingleOrDefault (m => m.ID == id);
            ViewBag.coursesTab = db.CoursesTypes.OrderByDescending(m => m.ID).ToList();

            return View("CourceT", _Cource);
        }

        public static List<CoursesType> FillGrid()
        {
            return (new CollegeDBEntities().CoursesTypes.OrderByDescending(x=>x.ID ).ToList());
        }

    }
}
