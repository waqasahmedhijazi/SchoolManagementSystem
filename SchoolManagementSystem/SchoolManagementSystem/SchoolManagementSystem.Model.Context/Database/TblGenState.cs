//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolManagementSystem.Model.Context.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblGenState
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblGenState()
        {
            this.TblGenCities = new HashSet<TblGenCity>();
            this.TblParents = new HashSet<TblParent>();
        }
    
        public int StateID { get; set; }
        public string StateName { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblGenCity> TblGenCities { get; set; }
        public virtual TblGenCountry TblGenCountry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblParent> TblParents { get; set; }
    }
}
