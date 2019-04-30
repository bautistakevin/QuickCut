using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCut.CoreUI.Models
{
    public class BarberViewModel
    {
        public Barber barber { get; set; }
        public List<Services> services { get; set; } 
    }
}
