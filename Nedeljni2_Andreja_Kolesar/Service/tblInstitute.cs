//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nedeljni2_Andreja_Kolesar.Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblInstitute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblInstitute()
        {
            this.tblClinicAdministrators = new HashSet<tblClinicAdministrator>();
        }
    
        public int instituteId { get; set; }
        public string name { get; set; }
        public System.DateTime constructionDate { get; set; }
        public string instituteOwner { get; set; }
        public string address { get; set; }
        public int numberOfFloors { get; set; }
        public int numberOfRooms { get; set; }
        public bool terrace { get; set; }
        public bool yard { get; set; }
        public Nullable<int> numberOfAmbulanceAccessPoints { get; set; }
        public Nullable<int> numberOfAccessPointsForInvalids { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClinicAdministrator> tblClinicAdministrators { get; set; }
    }
}