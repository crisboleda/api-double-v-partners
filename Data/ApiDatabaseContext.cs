using Microsoft.EntityFrameworkCore;
using double_v_partners.Models;
using System;

namespace double_v_partners.Data
{
    public class ApiDatabaseContext : DbContext
    {
        
        public ApiDatabaseContext(DbContextOptions<ApiDatabaseContext> dbContextOptions) : base (dbContextOptions)
        {

        }

        public DbSet<StatusTicket> StatusTickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new StatusTicketMap(modelBuilder.Entity<StatusTicket>());
        }
    }
}
