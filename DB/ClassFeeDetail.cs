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
    
    public partial class ClassFeeDetail
    {
        public int ID { get; set; }
        public int ClassId { get; set; }
        public int FeeHeadID { get; set; }
        public string SeesionName { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual FeeHead FeeHead { get; set; }
        public virtual Session Session { get; set; }
    }
}