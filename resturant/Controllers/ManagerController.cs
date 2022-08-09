using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resturant.Models;
using resturant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ManagerController(MyDbContext context)
        {
            _context = context;
        }



        [HttpGet("Get")]
        public async Task<IActionResult> GetManager()
        {
            var managers = _context.Manager.Select(s=>new { 
            
            s.phoneNumber,
            s.ManagerId,
            s.username,
            s.email,
           
            
            
            }).ToList();


            return Ok(managers);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddSupplier([FromBody] AddManager supp)
        {
            var manager = new Manager
            {
                phoneNumber = supp.phoneNumber,
                email = supp.email,
                username = supp.userName,
                AddressId = 1,
                
            };
            _context.Manager.Add(manager);
            await _context.SaveChangesAsync();

            return Ok(manager);
        }


    }
}
