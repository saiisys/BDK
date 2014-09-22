using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDK.DB;



namespace BDK.Controllers
{
    [Authorize]
    public class CastController : Controller
    {
     
        CollegeDBEntities db = new CollegeDBEntities();
       
      
        public ActionResult Index()
        {
            //ViewBag.CastList = db.CASTs.OrderBy(x=>x.CastId).ToList();
            return View();
        }
      
        public ActionResult Save (CAST obj)
        { 
         

          if(ModelState.IsValid == true)
          {
              if (obj.CastId == 0)
              {
                  obj.CastId = Convert.ToInt32(db.CASTs.Max(x => (int?)x.CastId) ?? 0) + 1;
                  obj.Sessionname = "2013-2014";
                  db.CASTs.Add(obj);
              }
              else 
              {
                 CAST _cast = db.CASTs.Where(x => x.CastId == obj.CastId).FirstOrDefault();
                 if (_cast != null)
                 {
                    // _cast.CastName = obj.CastName;
                     db.Entry(_cast).CurrentValues.SetValues(obj);
                 }
              
              }
              db.SaveChanges();
              ModelState.Clear();

             
          }
         
         
          return View("Index");
        }
     
        public ActionResult EditCast(int Id)
        {
            CAST _cast = db.CASTs.SingleOrDefault(s => s.CastId == Id);

            return View("Index", _cast);
        }

        public static  List<CAST> FillGrid()
        {
            return( new CollegeDBEntities().CASTs.OrderByDescending(x => x.CastId).ToList());
        }
    }
}
