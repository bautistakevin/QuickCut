//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuickCut.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Appointment
    {
        public int AppointmentID { get; set; }

        public int BarberID { get; set; }

        public int ConsumerID { get; set; }

        public System.DateTime Date { get; set; }
    
        public virtual Barber Barber { get; set; }
        public virtual Consumer Consumer { get; set; }
    }
}