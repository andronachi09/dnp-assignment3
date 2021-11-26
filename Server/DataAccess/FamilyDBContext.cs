using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.DataAccess
{
    public class FamilyDBContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Adults.db");
        }
    }
}