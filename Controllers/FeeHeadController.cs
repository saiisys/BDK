using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDK.DB;


namespace BDK.Controllers
{
    public class FeeHeadController : Controller
    {
        //
        // GET: /FeeHead/
        CollegeDBEntities db = new CollegeDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(FeeHead obj )
        {
            //if (ModelState.IsValid == true)
            //{
                if (obj.FeeId == 0)
                {
                    obj.FeeId = Convert.ToInt32(db.FeeHeads.Max(x => (int?)x.FeeId) ?? 0) + 1;
                    obj.SessionName = "2013-2014";
                    obj.UpdateBy = Session["User"].ToString();
                    obj.UpdateDate = DateTime.Now.Date;
                    db.FeeHeads.Add(obj);
                }
                else
                {

                    FeeHead _feehead = db.FeeHeads.Where(x => x.FeeId == obj.FeeId).FirstOrDefault();
                    if (_feehead != null)
                    {
                        db.Entry(_feehead).CurrentValues.SetValues(obj);
                    }


                }


                db.SaveChanges();
                ModelState.Clear();

            //}

            return View ("Index");
        }
        public static List<SelectListItem> Fillcombo()
        {
            List<SelectListItem> Litem = new List<SelectListItem>();
            SelectListItem s = new SelectListItem();
            s.Text = "-----Select Fee Group-----";
            s.Value = "0";
            s.Selected = true;
            Litem.Add(s);
 
            var item = new CollegeDBEntities().FeeGroups.Select(x => new { x.FGroupId, x.GroupName });
            foreach (var G in item)
            {
                s = new SelectListItem();
                s.Text = G.GroupName.ToString();
                s.Value = G.FGroupId.ToString();
                Litem.Add(s);

            }
            return Litem;


        }
        public static List<FeeHead> FillGrid()
        {
          return (  new CollegeDBEntities().FeeHeads.OrderByDescending(x=>x.FeeId ).ToList());
  

            
        }
        public ActionResult edit(int id)
        {
            FeeHead _feehead = db.FeeHeads.SingleOrDefault(x => x.FeeId == id);

            return View("Index",_feehead );
        }

    }
}
