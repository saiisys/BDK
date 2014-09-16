using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcDemoRestorent.DB;

namespace MvcDemoRestorent.Models
{
    public class Loginclass
    {
        CollegeDBEntities obj = new CollegeDBEntities();
        public bool CheckLogin(string user, string pass)
        {
            bool result = false;

            var Users = obj.Users.ToList(); 

            if(Users.Exists(a=>a.UserName == user && a.Password==pass))
            {
                result = true;
            }
            return result;
        }

    }
}