using System;
using System.Collections.Generic;

namespace QuickCut.CoreUI.Models
{
    public partial class Consumer
    {
        public Consumer()
        {
            Appointments = new HashSet<Appointments>();
            Ratings = new HashSet<Ratings>();
        }

        public int ConsumerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }
    }
}
