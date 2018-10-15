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
    public class MonitorController : ControllerBase
    {
        private MonitorContext _context;

        public MonitorController(MonitorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public String GetAll()
        {
            var strg = "Hei dette er test";
            return strg;
            //return lstfiskesuppe.ToList();
        }

        //    private DateTime EDay = DateTime.Today.AddHours(24);

        [HttpGet]
        public IQueryable<Department> Server(String _srv)
        {
            var dbContext = DbContextFactory.ChangeDbString(_srv);
            _context = dbContext;
            var Result = _context.Departments.FromSql<Department>("SELECT Name, ID FROM dbo.Department ");

            return Result;

            //------ THis could most likely run a stored proecedyre and return data------
            //var blogs = _context.View_Sale_Fiskesuppe.FromSql("EXECUTE dbo.GetMostPopularBlogsForUser {0}");
        }

        //        1) Pass raw arguments and use the {0}
        //        syntax.E.g:

        //DbContext.Database.SqlQuery("StoredProcedureName {0}", paramName);
        //2) Pass DbParameter subclass arguments and use @ParamName syntax.

        //DbContext.Database.SqlQuery("StoredProcedureName @ParamName",
        //                                   new SqlParameter("@ParamName", paramValue);

        //var firstName = "John";
        //var id = 12;
        //var sql = "Update [User] SET FirstName = {0} WHERE Id = {1}";
        //ctx.Database.ExecuteSqlCommand(sql, firstName, id);

        //    //[HttpGet("{id}")]
        //    [HttpGet]
        //    public IQueryable<ReturnData> Week(int id = 0)
        //    {
        //        DateTime _start = FirstDayOfWeek(DateTime.Today);
        //        return GetData(_start, EDay, "Current Week");
        //    }

        //[HttpGet]
        [HttpGet("{id?}")]
        public string Year(int year = 0)
        {
            //String name = "Current Year";
            ////String TOKEN = Token;
            //DateTime Ystart = new DateTime(EDay.Year - 5, 1, 1);

            //if (year != 0)
            //{
            //    name = "Year: " + year;
            //    Ystart = new DateTime(year, 1, 1);
            //    EDay = new DateTime(year + 1, 1, 1);
            //    EDay.AddDays(-1);
            //    return GetData(Ystart, EDay, name);
            //}
            //else
            //{
            //    var grouped = (from p in _context.View_Sale_Fiskesuppe
            //                   group p by new { year = p.SalesDate.Year } into d
            //                   select new ReturnData { year = (d.Key.year), Quantity = d.Sum(y => y.Quantity), Liters = d.Sum(f => f.AmountDl) }).OrderByDescending(g => g.year);

            //    return grouped;
            //}

            return "Data";
        }

        //    private IQueryable<ReturnData> GetData(DateTime _start, DateTime _end, String method)
        //    {
        //        var q = from p in _context.View_Sale_Fiskesuppe
        //                             .Where(x => x.SalesDate >= _start)
        //                             .Where(x => x.SalesDate <= _end)
        //                group p by 1 into g
        //                select new ReturnData()
        //                {
        //                    Name = method,
        //                    Quantity = g.Sum(x => x.Quantity),
        //                    Liters = g.Sum(x => x.AmountDl)
        //                };

        //        return q;
        //    }

        //    [HttpGet]
        //    public IQueryable<ReturnData> Month(int id = 0)
        //    {
        //        DateTime _start = FirstDayOfMonth(DateTime.Today);

        //        return GetData(_start, EDay, "Current Month"); ;
        //    }

        //    public static DateTime FirstDayOfWeek(DateTime dt)
        //    {
        //        var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
        //        var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
        //        if (diff < 0)
        //            diff += 7;
        //        return dt.AddDays(-diff).Date;
        //    }

        //    public static DateTime FirstDayOfMonth(DateTime dt)
        //    {
        //        return new DateTime(dt.Year, dt.Month, 1);
        //    }
        //}
    }
}