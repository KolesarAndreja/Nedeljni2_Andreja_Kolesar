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
    
    public partial class tblUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUser()
        {
            this.tblClinicAdministrators = new HashSet<tblClinicAdministrator>();
            this.tblClinicDoctors = new HashSet<tblClinicDoctor>();
            this.tblClinicManagers = new HashSet<tblClinicManager>();
            this.tblClinicPatients = new HashSet<tblClinicPatient>();
        }
    
        public int userId { get; set; }
        public string fullname { get; set; }
        public string ICnumber { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public System.DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        public string citizenship { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClinicAdministrator> tblClinicAdministrators { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClinicDoctor> tblClinicDoctors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClinicManager> tblClinicManagers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClinicPatient> tblClinicPatients { get; set; }
    }
}