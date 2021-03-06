﻿using KDRGoldAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KDRGoldAPI.DATA
{
    public class UserContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
          :

            base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}