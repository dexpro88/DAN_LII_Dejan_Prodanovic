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
    
    public partial class tblUserCake
    {
        public int UserID { get; set; }
        public int CakeID { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<System.DateTime> DateAndTimeOfOrder { get; set; }
    
        public virtual tblCake tblCake { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}
