using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi2.Models;

namespace WebApi2.Data
{
    public class WAContext : IdentityDbContext<User>
    {
        public WAContext(DbContextOptions<WAContext> options) : base(options) { }
        

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<User> Users {  get; set; }
    }
}
