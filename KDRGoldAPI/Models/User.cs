using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KDRGoldAPI.Models
{
    public class User
    {
        public String UserGuid { get; set; }
        public String UserName { get; set; }
        public String MsterKey { get; set; }
        public bool Active { get; set; }
        public String AppId { get; set; }
        public int UserId { get; set; }
        public String Email { get; set; }
    }
}