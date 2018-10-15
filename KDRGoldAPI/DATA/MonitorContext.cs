using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KDRGoldAPI.DATA
{
    public class MonitorContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MonitorContext(DbContextOptions<MonitorContext> options)
          :

            base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
    }

    public class Department
    {
        public string Name { get; set; }
        [Key]
        public int Id { get; set; }
    }
}