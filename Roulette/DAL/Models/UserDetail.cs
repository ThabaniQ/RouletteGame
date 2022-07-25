using System;
using System.Collections.Generic;

#nullable disable

namespace Roulette.DAL.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            Bets = new HashSet<Bet>();
        }

        public string UserId { get; set; }
        public string Name { get; set; }
        public long? Balance { get; set; }
        public long? NumberOfWins { get; set; }
        public long? NumberOfLoses { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
