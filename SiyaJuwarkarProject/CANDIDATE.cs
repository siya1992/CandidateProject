//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiyaJuwarkarProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class CANDIDATE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CANDIDATE()
        {
            this.WORKEXPERIENCEs = new HashSet<WORKEXPERIENCE>();
        }
    
        public int ID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string EMAIL { get; set; }
        public Nullable<int> PHONECODE { get; set; }
        public int MOBILE { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string COUNTRY { get; set; }
        public string PINCODE { get; set; }
        public string IMAGELOCATION { get; set; }
        public string PASSWORD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WORKEXPERIENCE> WORKEXPERIENCEs { get; set; }
    }
}
