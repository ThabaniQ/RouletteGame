using Microsoft.EntityFrameworkCore;
using Roulette.DAL.Interface;
using Roulette.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.DAL.Repositories
{
    public class BetRepository : RepositoryBase<Bet>, IBetInterface
    {
        RouletteContext _context;
        string color ;
        public int rotation = 0, spinValue = 0;
        public double payout = 0;
        public double bet_amount=0;
        int[] Number = {  0 ,  32 ,  15 ,  19 ,  4 ,  21 ,  2 ,  25 ,  17 ,  34 ,  6 ,  27 ,  13 ,  36 ,  11 ,  30 ,  8 ,  23 ,  10 ,  5 ,  24 ,  16 ,  33 ,  1 ,  20 ,  14 ,  31 ,  9 ,  22 ,  18 ,  29 ,  7 ,  28 ,  12 ,  35 ,  3 ,  26  };
        int[] Red = {  32 ,  19 ,  21 ,  25 ,  34 ,  27 ,  36 ,  30 ,  23 ,  5 ,  16 ,  1 ,  14 ,  9 ,  18 ,  7 ,  12 ,  3  };
        int[] Black = {  15 ,  4 ,  2 ,  17 ,  6 ,  13 ,  11 ,  8 ,  10 ,  24 ,  33 ,  20 ,  31 ,  22 ,  29 ,  28 ,  35 ,  26  };

        public BetRepository(RouletteContext context):base(context)
        {
            _context = context;
        }
        public async Task<string> BetOutcome(int betValue,double amount)
        {
            if (amount !=0)
            {
                bet_amount = amount;
            }
            
            GetSpinValue();
            if (betValue<=36)
            {
                if (betValue == spinValue)
                {
                    Payout(amount);
                    return $"Won {payout}";
                }
                return "Lost";
            }
            else
            {
                return "outside the roulette wheel";
            }
        }   

        public async Task<IEnumerable<Bet>> GetAllBets()
        {
            return await _context.Bets.Select(x => x).ToListAsync();
        }
        public async Task<IEnumerable<Bet>> GetBetsByUserId(string id)
        {
            return await _context.Bets.Select(x => x).Where(x => x.BetId == id).ToListAsync();
        }
        public async Task<IEnumerable<Bet>> GetBetsByUserAsync(string id)
        {
            return await _context.Bets.Select(x => x).Where(x => x.UserId == id).ToListAsync();       
        }

        public async Task<int> GetSpinValue()
        {
            Random rnd = new Random();
            rotation = rnd.Next(360);

            decimal degrees = 360;
            decimal numbers = 37;
            decimal devider = degrees / numbers;
            decimal valueIndex = rotation / devider;
            int floorValue = (int)Math.Floor(valueIndex);

            spinValue = Number.ElementAt(floorValue);
            return spinValue;

        }


        public Task<Bet> Bet(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetSpinByColor(string color,double amount)
        {
            GetSpinValue();
            this.color = color;
            if (color.ToLower() == "red")
            {
                if (spinValue > 0)
                {
                    if (Red.Contains(spinValue))
                    {
                        Payout(amount);
                        return $"Won {payout}";
                    }
                    else
                    {
                        return "Lost";
                    }
                }
            }
            else if (color.ToLower() == "black")
            {
                if (spinValue > 0)
                {
                    if(Black.Contains(spinValue))
                    {
                        Payout(amount);
                        return $"Won {payout}";
                    }
                    return "Lost";
                }
            }
            return "Invalid color";
        }

        public async Task<double> Payout(double amount)
        {
            if (spinValue > 12 && spinValue < 25)
            {
                payout = (int)(amount * 2);
            }
             if (spinValue == 7)
            {
                payout = (int)amount * 35;
            }
             if (spinValue == 19)
            {
                payout = (int)amount * 17;
            }
             if (spinValue >= 28 && spinValue <= 30)
            {
                payout = (int)amount * 11;
            }
             if (spinValue >= 0 && spinValue <= 3)
            {
                payout = (int)amount * 6;
            }
             if (spinValue >= 4 && spinValue <= 9)
            {
                payout = (int)amount * 5;
            }
             if (!string.IsNullOrEmpty(color))
            {
                payout = (int)amount * 10;
            }
             if (spinValue % 2 == 0)
            {
                payout = (int)amount * 12;
            }
             if (spinValue % 2 != 0)
            {
                payout = (int)amount * 10;
            }
            else
            {
                payout = 0;
            }
            return payout;
        }

        public void Create()
        {
            Guid guid = Guid.NewGuid();
            var bet = new Bet
            {
                BetId =  guid.ToString(),
                UserId =  Guid.NewGuid().ToString(),
                BetAmount = bet_amount,
                Payout = payout,
                SpinValue = spinValue.ToString()
            };
            _context.Bets.Add(bet);

        }
       

    }
}
