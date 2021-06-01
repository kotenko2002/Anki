using AnkiAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnkiAPI.Date
{
    public class AnkiDbContext : DbContext
    {
        public AnkiDbContext(DbContextOptions<AnkiDbContext> opt) : base(opt)
        {
            Database.EnsureCreated();
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
