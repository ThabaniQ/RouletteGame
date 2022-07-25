using Roulette.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.DAL.Repositories
{
    public interface IRepositoryWrapper
    {
        IBetInterface Bet { get; }
        IUserRepository UserDetails { get; }
        Task SaveAsync();
    }
}
