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
    
    public partial class FeeGroup
    {
        public FeeGroup()
        {
            this.FeeHeads = new HashSet<FeeHead>();
        }
    
        public int FGroupId { get; set; }
        public string GroupName { get; set; }
        public string SessionName { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual ICollection<FeeHead> FeeHeads { get; set; }
    }
}
