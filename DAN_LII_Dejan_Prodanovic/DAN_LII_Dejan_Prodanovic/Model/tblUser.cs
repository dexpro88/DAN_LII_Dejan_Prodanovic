//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAN_LII_Dejan_Prodanovic.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUser()
        {
            this.tblUserCakes = new HashSet<tblUserCake>();
        }
    
        public int UserID { get; set; }
        public string Fullname { get; set; }
        public string UserAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public Nullable<int> NumberOfOrders { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUserCake> tblUserCakes { get; set; }
    }
}
