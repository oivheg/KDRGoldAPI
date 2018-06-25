using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KDRGoldAPI.DATA;
using KDRGoldAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KDRGoldAPI.Controllers
{
    //[Route("api/[controller]/[action]/")]
    [Authorize]
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
        public List<Fiskesuppe> GetAll()
        {
            var lstfiskesuppe = _context.View_Sale_Fiskesuppe.Take(10);
            return lstfiskesuppe.ToList();
        }

        //public decimal AmountSold(int id)
        //{
        //    DateTime Ystart = new DateTime(id, 1, 1);
        //    DateTime Yend = new DateTime(id + 1, 1, 1);
        //    Yend.AddDays(-1);

        //    var q = from p in _context.View_Sale_Fiskesuppe
        //            .Where(x => x.SalesDate >= Ystart)
        //            .Where(x => x.SalesDate < Yend)
        //            select p.Quantity;
        //    return q.Sum();
        //    //------ THis could most likely run a stored proecedyre and return data------
        //    //var blogs = _context.View_Sale_Fiskesuppe.FromSql("EXECUTE dbo.GetMostPopularBlogsForUser {0}");
        //}

        //End OF Current DAY 24 HOUR
        private DateTime EDay = DateTime.Today.AddHours(24);

        [HttpGet]
        public IQueryable<ReturnData> Day(int id = 0)
        {
            DateTime Day = DateTime.Today;
            ;
            var q = from p in _context.View_Sale_Fiskesuppe
                    .Where(x => x.SalesDate >= Day)

                    select p.Quantity;
            return GetData(Day, EDay, "This Day");
            //------ THis could most likely run a stored proecedyre and return data------
            //var blogs = _context.View_Sale_Fiskesuppe.FromSql("EXECUTE dbo.GetMostPopularBlogsForUser {0}");
        }

        //[HttpGet("{id}")]
        [HttpGet]
        public IQueryable<ReturnData> Week(int id = 0)
        {
            DateTime _start = FirstDayOfWeek(DateTime.Today);
            return GetData(_start, EDay, "Current Week");
        }

        //[HttpGet]
        [HttpGet("{id?}")]
        public IQueryable<ReturnData> Year(int year = 0)
        {
            String name = "Current Year";
            //String TOKEN = Token;
            DateTime Ystart = new DateTime(EDay.Year - 5, 1, 1);

            if (year != 0)
            {
                name = "Year: " + year;
                Ystart = new DateTime(year, 1, 1);
                EDay = new DateTime(year + 1, 1, 1);
                EDay.AddDays(-1);
                return GetData(Ystart, EDay, name);
            }
            else
            {
                var grouped = (from p in _context.View_Sale_Fiskesuppe
                               group p by new { year = p.SalesDate.Year } into d
                               select new ReturnData { year = (d.Key.year), Quantity = d.Sum(y => y.Quantity), Liters = d.Sum(f => f.AmountDl) }).OrderByDescending(g => g.year);

                return grouped;
            }

            //    return GetData(Ystart, Yend, name);
        }

        private IQueryable<ReturnData> GetData(DateTime _start, DateTime _end, String method)
        {
            var q = from p in _context.View_Sale_Fiskesuppe
                                 .Where(x => x.SalesDate >= _start)
                                 .Where(x => x.SalesDate <= _end)
                    group p by 1 into g
                    select new ReturnData()
                    {
                        Name = method,
                        Quantity = g.Sum(x => x.Quantity),
                        Liters = g.Sum(x => x.AmountDl)
                    };

            return q;
        }

        [HttpGet]
        public IQueryable<ReturnData> Month(int id = 0)
        {
            DateTime _start = FirstDayOfMonth(DateTime.Today);

            return GetData(_start, EDay, "Current Month"); ;
        }

        public static DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;
        }

        public static DateTime FirstDayOfMonth(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }
    }
}