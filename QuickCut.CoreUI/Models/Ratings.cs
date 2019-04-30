using System;
using System.Collections.Generic;

namespace QuickCut.CoreUI.Models
{
    public partial class Ratings
    {
        public int RatingId { get; set; }
        public int BarberId { get; set; }
        public int ConsumerId { get; set; }
        public int RatingNumber { get; set; }
        public string Comments { get; set; }

        public virtual Barber Barber { get; set; }
        public virtual Consumer Consumer { get; set; }
    }
}
