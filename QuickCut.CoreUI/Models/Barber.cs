using System;
using System.Collections.Generic;

namespace QuickCut.CoreUI.Models
{
    public partial class Barber
    {
        public Barber()
        {
            Appointments = new HashSet<Appointments>();
            Ratings = new HashSet<Ratings>();
        }

        public int BarberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BarberAddress { get; set; }
        public int Zip { get; set; }

        public virtual BarberDetails BarberDetails { get; set; }
        public virtual Services Services { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }
    }
}
