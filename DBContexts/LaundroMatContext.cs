using LaundroMat.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaundroMat.DBContexts
{
    public class LaundroMatContext : DbContext
    {
        public LaundroMatContext(DbContextOptions<LaundroMatContext> options) : base(options) 
        {
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}
