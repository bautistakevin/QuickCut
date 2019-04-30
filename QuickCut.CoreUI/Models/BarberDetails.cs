using System;
using System.Collections.Generic;

namespace QuickCut.CoreUI.Models
{
    public partial class BarberDetails
    {
        public int BarberId { get; set; }
        public string PhoneNumber { get; set; }
        public string OperationHours { get; set; }
        public string DaysOfWeek { get; set; }
        public string PolicyInfo { get; set; }

        public virtual Barber Barber { get; set; }
    }
}
