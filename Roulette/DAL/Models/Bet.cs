using System;
using System.Collections.Generic;

#nullable disable

namespace Roulette.DAL.Models
{
    public partial class Bet
    {
        public string BetId { get; set; }
        public long? BetValue { get; set; }
        public string SpinValue { get; set; }
        public double? Payout { get; set; }
        public double? BetAmount { get; set; }
        public string UserId { get; set; }

        public virtual UserDetail User { get; set; }
    }
}
