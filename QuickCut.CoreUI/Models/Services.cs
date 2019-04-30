using System;
using System.Collections.Generic;

namespace QuickCut.CoreUI.Models
{
    public partial class Services
    {
        public int BarberId { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }

        public virtual Barber Barber { get; set; }
    }
}
