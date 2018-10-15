using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KDRGoldAPI.DATA
{
    public static class DbContextFactory
    {
        public static Dictionary<string, string> ConnectionStrings { get; set; }

        public static void SetConnectionString(Dictionary<string, string> connStrs)
        {
            ConnectionStrings = connStrs;
        }

        public static MonitorContext ChangeDbString(string connid)
        {
            if (!string.IsNullOrEmpty(connid))
            {
                var connStr = ConnectionStrings[connid];
                var optionsBuilder = new DbContextOptionsBuilder<MonitorContext>();
                if (connid == "DB1")
                {
                    optionsBuilder.UseSqlServer("Server=HEGGLAND\\HEGGLAND;Database=KDRGoldDemoKDRSNy;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true");
                }
                else if (connid == "DB2")
                {
                    optionsBuilder.UseSqlServer("Server=HEGGLAND\\HEGGLAND;Database=HegglandTEst;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true");
                }

                return new MonitorContext(optionsBuilder.Options);
            }
            else
            {
                throw new ArgumentNullException("ConnectionId");
            }
        }
    }
}