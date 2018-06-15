using KDRGoldAPI.DATA;
using KDRGoldAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KDRGoldAPI.Controllers
{
    //[Route("api/[controller]/[action]/")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly UserContext _context;

        public TestController(UserContext context)
        {
            _context = null;
            _context = context;

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new User { UserName = "Item1" });
                //_context.SaveChanges();
            }
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<User> GetById(int id)
        {
            var item = _context.Users.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}