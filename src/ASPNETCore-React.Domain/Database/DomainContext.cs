using ASPNETCore_React.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPNETCore_React.Domain.Database
{
    public class DomainContext: DbContext
    {
        public DomainContext(DbContextOptions<DomainContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // In Memory Database
            optionsBuilder.UseInMemoryDatabase("aspnetcore_imdb_1");
        }

        public DbSet<User> Users { get; set; }
    }
}
