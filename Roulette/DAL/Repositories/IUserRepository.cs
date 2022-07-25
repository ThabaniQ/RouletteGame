using Roulette.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.DAL.Repositories
{
   public interface IUserRepository :IRepositoryBase<UserDetail>
    {
        Task<IEnumerable<UserDetail>> GetAllÚsers();
        Task<UserDetail> GetUserById(string id);
    }
}
