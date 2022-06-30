using System;
using System.Collections.Generic;

namespace BackElyssa.Models
{
    public partial class HistoryClimate
    {
        public int IdClimate { get; set; }
        public string? City { get; set; }
        public string? Lat { get; set; }
        public string? Long { get; set; }
        public string? Temperature { get; set; }
        public int? IdAcElyssa { get; set; }

        public virtual ElyssaAccount? IdAcElyssaNavigation { get; set; }
    }
}
