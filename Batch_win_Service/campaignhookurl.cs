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
    
    public partial class campaignhookurl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public campaignhookurl()
        {
            this.hitnotifies = new HashSet<hitnotify>();
        }
    
        public int PK_HookID { get; set; }
        public string CampaignName { get; set; }
        public string HookURL { get; set; }
        public string Status { get; set; }
        public Nullable<int> FK_Rid { get; set; }
        public Nullable<int> FK_ClientID { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hitnotify> hitnotifies { get; set; }
    }
}