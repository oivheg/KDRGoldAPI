using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KDRGoldAPI.Models
{
    public class User
    {
        public Guid UserGuid { get; set; }
        public String UserName { get; set; }
        public String MasterKey { get; set; }
        public bool Active { get; set; }
        public String AppId { get; set; }
        public int UserId { get; set; }
        public String Email { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        //public Guid UserGuid { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UserId { get; set; }

        //public String UserName { get; set; }
        //public String Email { get; set; }
        //public String MasterKey { get; set; }
        //public Boolean Active { get; set; }
        //public String AppId { get; set; }
    }
}