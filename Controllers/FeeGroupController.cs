using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDK.DB;


namespace BDK.Controllers
{
   
    public class FeeGroupController : Controller
    {
        CollegeDBEntities db = new CollegeDBEntities();

    

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Save(FeeGroup obj)
        {
            //if (ModelState.IsValid == true)
            //{
                if (obj.FGroupId == 0)
                {
                    obj.FGroupId = Convert.ToInt32(db.FeeGroups.Max(x => (int?)x.FGroupId) ?? 0) + 1;
                    obj.SessionName = "2013-2014";
                    obj.UpdateDate = DateTime.Now.Date;
                    obj.UpdateBy = Session["User"].ToString();
                    db.FeeGroups.Add(obj);
                }
                else
                {
                    FeeGroup _feegroup = db.FeeGroups.Where(x => x.FGroupId == obj.FGroupId).FirstOrDefault();
                    if (_feegroup != null)
                    {
                        db.Entry(_feegroup).CurrentValues.SetValues(obj);
                    }
                }

                db.SaveChanges();
                ModelState.Clear();


            //}


            return View("Index");



        }


        public static List<FeeGroup> FillGride()
        {
            return (new CollegeDBEntities().FeeGroups.OrderByDescending(x => x.FGroupId).ToList());


        }

        public ActionResult EditFeeGroup(int Id)
        {
            FeeGroup _feegroup = db.FeeGroups.SingleOrDefault(x => x.FGroupId == Id );
            return View("Index", _feegroup );
        }
        
    }
}
