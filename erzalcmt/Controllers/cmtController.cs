using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erzalcmt.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class cmtController : ControllerBase
    {

        private readonly ILogger<cmtController> _logger;

        public cmtController(ILogger<cmtController> logger)
        {
            _logger = logger;
        }

        [Route("[action]")]
        [HttpGet]
        public ActionResult GetStringArray(int Number)
        {
            List<string> returnStrings = new List<string>();
            try
            {
                for (int count = 1; count <= Number; count++)
                {
                    //checking for both multiples of 3 and 5
                    if (count % 3 == 0 && count % 5 == 0)
                    {
                        returnStrings.Add("FizzBuzz");
                    }
                    //checking for multiple of 3
                    else if (count % 3 == 0)
                    {
                        returnStrings.Add("Fizz");
                    }
                    //checking for multiple of 5
                    else if (count % 5 == 0)
                    {
                        returnStrings.Add("Buzz");
                    }
                    //just add string representation of count...
                    else
                    {
                        returnStrings.Add(count.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                //log the exception..
                _logger.LogError(ex.ToString());
                //return the error...
                return BadRequest(ex.ToString());
            }

            return Ok(returnStrings.ToArray());

        }
    }
}
