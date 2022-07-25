using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Roulette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private int rotation;
        int[] Number = { 0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26 };


        // GET: api/<ValuesController>
        [HttpGet]
        public int GetSpinValue()
        {
            Random rnd = new Random();
            rotation = rnd.Next(360);
            decimal degrees = 360;
            decimal numbers = 37;
            decimal devider = degrees / numbers;
            decimal valueIndex = rotation / devider;
            int floorValue = (int)Math.Floor(valueIndex);
            
            int output= Number.ElementAt(floorValue);
            return output;
            //create an array for the roulette table and look for the position of the floorValue
            //spinValue=Array.Indexof(floor);

        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
