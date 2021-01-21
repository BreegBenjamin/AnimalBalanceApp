using AnimalBalanceApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalBalanceApp.Infrastructure.Data
{
    public partial class AnimalBalanceAppContext : DbContext
    {
        public AnimalBalanceAppContext()
        {
        }

        public AnimalBalanceAppContext(DbContextOptions<AnimalBalanceAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnimalBalanceAppContext).Assembly);
        }
    }
}
