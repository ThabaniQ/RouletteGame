using Roulette.DAL.Models;
using Roulette.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.DAL.Interface
{
   public interface IBetInterface : IRepositoryBase<Bet>
    {
        Task<Bet> Bet(int id);
        Task<IEnumerable<Bet>> GetAllBets();
        Task<IEnumerable<Bet>> GetBetsByUserAsync(string id);
        Task<IEnumerable<Bet>> GetBetsByUserId(string id);
        Task<string> BetOutcome(int betValue, double amount);
        Task<int> GetSpinValue();
        Task<string> GetSpinByColor(string color,double amount);
        Task<double> Payout(double amount);
        void Create();
    }
}
