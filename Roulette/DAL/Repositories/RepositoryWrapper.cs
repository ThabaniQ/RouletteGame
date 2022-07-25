using Roulette.DAL.Interface;
using Roulette.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.DAL.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        
        
        private IBetInterface _betInterface;
        private IUserRepository _userDetails;
        public RouletteContext rouletteContext;
        public RepositoryWrapper(RouletteContext context) 
        {
            this.rouletteContext = context;
        }

        public IBetInterface Bet
        {
            get
            {
                if (_betInterface == null)
                {
                    _betInterface = new BetRepository(rouletteContext);
                }
                return _betInterface;
            }
        }

        public IUserRepository UserDetails
        {
            get
            {
                if (_userDetails == null)
                {
                    _userDetails = new UserRepository(rouletteContext);
                }
                return _userDetails;
            }
        }

        public async Task SaveAsync()
        {
            await rouletteContext.SaveChangesAsync();
        }
    }
}
