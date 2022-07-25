using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roulette.DAL.Models;
using Roulette.DAL.Repositories;

namespace Roulette.Controllers
{
    [Route("api/UserDetails")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IRepositoryWrapper _context;

        public UserDetailsController(IRepositoryWrapper context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<UserDetail>> GetUserDetails()
        {
            return await _context.UserDetails.FindAll();
        }

        [HttpGet("{id}")]
        public async Task<UserDetail> GetUserDetail(string id)
        {
            return await _context.UserDetails.GetUserById(id);
        }

        

        
    }
}
