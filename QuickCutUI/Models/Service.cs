//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuickCutUI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service
    {
        public int BarberID { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
    
        public virtual Barber Barber { get; set; }
    }
}
