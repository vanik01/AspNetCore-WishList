

using Microsoft.EntityFrameworkCore;
using WishList.Model;

namespace WishList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public ApplicationDbContext(DbContextOptions option) : base(option)
        { }
    }
}
