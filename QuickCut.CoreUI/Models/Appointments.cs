using System;
using System.Collections.Generic;

namespace QuickCut.CoreUI.Models
{
    public partial class Appointments
    {
        public int AppointmentId { get; set; }
        public int BarberId { get; set; }
        public int ConsumerId { get; set; }
        public DateTime Date { get; set; }

        public virtual Barber Barber { get; set; }
        public virtual Consumer Consumer { get; set; }
    }
}
