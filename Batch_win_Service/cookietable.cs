//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StatsUpdate_win_Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class cookietable
    {
        public int PK_CookieId { get; set; }
        public string CookieValue { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<int> FK_ShorturlId { get; set; }
    
        public virtual shorturldata shorturldata { get; set; }
    }
}
