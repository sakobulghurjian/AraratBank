using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AraratBank.Models.DataBase
{
    public class AppDBContext : IdentityDbContext<IdentityUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<API> APIs { get; set; }
    }
}
