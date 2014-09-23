using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDK.DB;

namespace BDK.Controllers
{
    public class ExtraCertificatesController : Controller
    {
        //
        // GET: /ExtraCertificates/
        CollegeDBEntities db = new CollegeDBEntities();

        public ActionResult Index()
        {
            return View();
        }

         public ActionResult Save(ExtraCertificate obj)
        {
            if (obj.CertificateId == 0)
            {
                obj.CertificateId = Convert.ToInt32(db.ExtraCertificates.Max(m => (int?)m.CertificateId) ?? 0) + 1;
                obj.SessionName = "2013-2014";
                obj.UpdateBy = Session["User"].ToString();
                obj.UpdateDate = DateTime.Now.Date;
                db.ExtraCertificates.Add(obj);

            }
            else
            {
                ExtraCertificate _feedetail = db.ExtraCertificates.Where(x => x.CertificateId == obj.CertificateId).FirstOrDefault();
                if (_feedetail != null)
                {
                    db.Entry(_feedetail).CurrentValues.SetValues(obj);
                }
            }

            db.SaveChanges();
            ModelState.Clear();

            return View("Index");

        }
         public static List<ExtraCertificate> Fillgrid()
        {
            return (new CollegeDBEntities().ExtraCertificates.OrderByDescending(m => m.CertificateId).ToList());
        }
        public ActionResult EditCertificates(int id)
        {
            ExtraCertificate _Certificates = db.ExtraCertificates.FirstOrDefault(X => X.CertificateId == id);

            return View("Index", _Certificates);


        }




    }
}
