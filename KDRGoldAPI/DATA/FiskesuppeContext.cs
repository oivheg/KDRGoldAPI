using KDRGoldAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KDRGoldAPI.DATA
{
    public class FiskesuppeContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public FiskesuppeContext(DbContextOptions<FiskesuppeContext> options)
          :

            base(options)
        {
        }

        public DbSet<Fiskesuppe> View_Sale_Fiskesuppe { get; set; }
    }
}