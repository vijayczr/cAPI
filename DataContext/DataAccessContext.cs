
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.DataEntities;

namespace WebApplication1.DataContext
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext(DbContextOptions<DataAccessContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

    }
}
