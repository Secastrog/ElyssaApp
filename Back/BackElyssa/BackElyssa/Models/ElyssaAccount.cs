using System;
using System.Collections.Generic;

namespace BackElyssa.Models
{
    public partial class ElyssaAccount
    {
        public ElyssaAccount()
        {
            HistoryClimates = new HashSet<HistoryClimate>();
        }

        public int IdAcElyssa { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<HistoryClimate> HistoryClimates { get; set; }
    }
}
