using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WebAPISerilog.Models;

namespace WebAPISerilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly ILogger<PhonesController> _logger;

        private readonly dbcontext _db;

        public PhonesController(ILogger<PhonesController> logger, dbcontext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {                
                _logger.LogInformation("This is just a log entry for the try block");
                throw new Exception("Error Happened");
                return Ok(_db.Phones);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception in Catch block: " + ex.Message);
                return BadRequest("Sorry, we could not load the data");
            }
        }

        [HttpPost]
        public IActionResult AddPhone([FromBody]Phone phone)
        {
            _db.Add(phone);
            _db.SaveChanges();
            return Ok(phone);
        }
    }
}
