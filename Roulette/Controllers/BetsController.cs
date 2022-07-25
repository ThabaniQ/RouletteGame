using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roulette.DAL.Interface;
using Roulette.DAL.Models;
using Roulette.DAL.Repositories;
using Roulette.DAL.Repositories.Logger;

namespace Roulette.Controllers
{
    [Route("api/Bets")]
    [ApiController]
    public class BetsController : ControllerBase
    {
        private readonly IRepositoryWrapper _context;
        private ILoggerManager _logger;


        public BetsController(IRepositoryWrapper context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("getallbets")]
        public async Task<IEnumerable<Bet>> GetBets()
        {
            try
            {

            return await _context.Bet.FindAll();

            }
            catch (Exception)
            {
                 _logger.LogError("error getting bets, contact technical support.");
            }
            return (IEnumerable<Bet>)NotFound();

        }

        // GET: api/Bets/5
        [HttpGet(("/getbetuserbyid/{id}"))]
        public async Task<IEnumerable<Bet>> GetBet(string id)
        {
            return await _context.Bet.GetBetsByUserAsync(id);
        }
        [HttpGet("/getbetbyid/{id}")]
        public async Task<IEnumerable<Bet>> GetBetUser(string id)
        {
            return await _context.Bet.GetBetsByUserId(id);
        }

        [HttpPost]
        [Route("/spin")]
        public async Task<string> Spin(int betvalue, double amount)
        {
            if (betvalue<=36)
            {
                var c = await _context.Bet.BetOutcome(betvalue, amount);
                _context.Bet.Create();
                _context.SaveAsync();
                return c;
            }
            _logger.LogError("bet value can not exceed 36");
            return "bet value can not exceed 36";
           
        }

        //[HttpPost]
        //public async Task<Bet> PostBet(Bet bet)
        //{
        //    _context.Bets.Add(bet);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (BetExists(bet.BetId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetBet", new { id = bet.BetId }, bet);
        //}


    }
}
