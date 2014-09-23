using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BDK.DB
{
    [MetadataType(typeof(Session))]
    public partial class Session
    {
        private sealed class MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Session Name.")]
            [StringLength(50, MinimumLength = 9, ErrorMessage = "The name must  be between 9-50 characters long.")]
            public object SessionName { get; set; }
        }
    }
}