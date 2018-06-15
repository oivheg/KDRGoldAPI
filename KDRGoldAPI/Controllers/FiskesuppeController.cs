using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using KDRGoldAPI.DATA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KDRGoldAPI.Controllers
{
    //[Route("api/[controller]/[action]/")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FiskesuppeController : ControllerBase
    {
        private readonly FiskesuppeContext _context;

        public FiskesuppeController(FiskesuppeContext context)
        {
            _context = null;
            _context = context;
        }

        [HttpGet]
        public List<Models.Fiskesuppe> GetAll()
        {
            var lstfiskesuppe = _context.View_Sale_Fiskesuppe.Take(10);
            return lstfiskesuppe.ToList();
        }

        [HttpGet("{id}")]
        public List<Models.Fiskesuppe> AmountSold(int id)
        {
            DateTime Ystart = new DateTime(id, 1, 1);
            DateTime Yend = new DateTime(id + 1, 1, 1);
            Yend.AddDays(-1);

            var q = _context.View_Sale_Fiskesuppe
                     .Where(x => x.SalesDate >= Ystart)
                     .Where(x => x.SalesDate < Yend);
            return q.ToList();
            //------ THis could most likely run a stored proecedyre and return data------
            //var blogs = _context.View_Sale_Fiskesuppe.FromSql("EXECUTE dbo.GetMostPopularBlogsForUser {0}");
        }
    }
}