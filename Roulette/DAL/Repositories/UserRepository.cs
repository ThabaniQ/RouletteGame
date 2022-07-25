using Microsoft.EntityFrameworkCore;
using Roulette.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.DAL.Repositories
{
    public class UserRepository :RepositoryBase<UserDetail>, IUserRepository
    {
        RouletteContext _context;
        public  UserRepository(RouletteContext context):base( context)
        {
            _context = context;
        }

      
        public async Task<IEnumerable<UserDetail>> GetAllÚsers()
        {
            return await _context.UserDetails.Select(x => x).ToListAsync();
        }

        public async  Task<UserDetail> GetUserById(string id)
        {
            return await _context.UserDetails.SingleOrDefaultAsync(x=> x.UserId == id);
        }
    }
}
