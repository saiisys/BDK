//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcDemoRestorent.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Session
    {
        public Session()
        {
            this.CASTs = new HashSet<CAST>();
            this.ClassFeeDetails = new HashSet<ClassFeeDetail>();
            this.CoursesTypes = new HashSet<CoursesType>();
            this.FeeSettings = new HashSet<FeeSetting>();
        }
    
        public int SessionId { get; set; }


        [Display(Name = "Session Name Full")]
        [Required]
        public string SessionName { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]      
        public System.DateTime Startdate { get; set; }


        public System.DateTime EndingDate { get; set; }
        public bool DefaultIndic { get; set; }
        public bool OpenIndic { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual ICollection<CAST> CASTs { get; set; }
        public virtual ICollection<ClassFeeDetail> ClassFeeDetails { get; set; }
        public virtual ICollection<CoursesType> CoursesTypes { get; set; }
        public virtual ICollection<FeeSetting> FeeSettings { get; set; }
    }
}
