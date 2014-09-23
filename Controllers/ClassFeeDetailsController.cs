using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDK.DB;


namespace BDK.Controllers
{
    public class ClassFeeDetailsController : Controller
    {
        //
        // GET: /ClassFeeDetails/
        CollegeDBEntities db = new CollegeDBEntities();

        public ActionResult Index()
        {
            return View();
        }
        public static List<SelectListItem> FillClassCombo()
        {
            SelectListItem s = new SelectListItem();
            List<SelectListItem> litem = new List<SelectListItem>();
            s.Text = "-----Select Class Name-----";
            s.Value = "0";
            s.Selected = true;
            litem.Add(s);

            var classitem = new CollegeDBEntities().Classes.Select(x => new { x.ClassId, x.ClassName });
            foreach (var t in classitem)
            {
                s = new SelectListItem();
                s.Text = t.ClassName.ToString();
                s.Value = t.ClassId.ToString();
                litem.Add(s);
            }
            return litem;

        }
        public static List<SelectListItem> FillFeeHeadCombo()
        {
            SelectListItem s = new SelectListItem();
            List<SelectListItem> litem = new List<SelectListItem>();

            s.Text = "-----Select Fee Head-----";
            s.Value = "0";
            s.Selected = true;
            litem.Add(s);


            var item = new CollegeDBEntities().FeeHeads.Select(x => new { x.FeeId, x.FeeeName });
            foreach (var i in item)
            {
                s = new SelectListItem();
                s.Text = i.FeeeName.ToString();
                s.Value = i.FeeId.ToString();
                litem.Add(s);
            }
            return litem;

        }
        public ActionResult Save(ClassFeeDetail obj)
        {
            if (obj.ID == 0)
            {
                obj.ID = Convert.ToInt32(db.ClassFeeDetails.Max(m => (int?)m.ID) ?? 0) + 1;
                obj.SeesionName = "2013-2014";
                obj.UpdateBy = Session["User"].ToString();
                obj.UpdateDate = DateTime.Now.Date;
                db.ClassFeeDetails.Add(obj);


            }
            else
            {
                ClassFeeDetail _feedetail = db.ClassFeeDetails.Where(x => x.ID == obj.ID).FirstOrDefault();
                if (_feedetail != null)
                {
                    db.Entry(_feedetail).CurrentValues.SetValues(obj);
                }
            }

            db.SaveChanges();
            ModelState.Clear();

            return View("Index");

        }
        public static List<ClassFeeDetail> Fillgrid()
        {
            return (new CollegeDBEntities().ClassFeeDetails.OrderByDescending(m => m.ID).ToList());
        }
        public ActionResult EditClassFeeDetail(int id)
        {
            ClassFeeDetail _class = db.ClassFeeDetails.FirstOrDefault(X => X.ID == id);

            return View("Index", _class);


        }

    }
}
