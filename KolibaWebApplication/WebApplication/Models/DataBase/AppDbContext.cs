using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication.Models.DataBase.EntityConfigurations;

namespace WebApplication.Models.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<MealHelper> MealHelpers { get; set; }
        public DbSet<DrinkHelper> DrinkHelpers { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Salesman> Salesmans { get; set; }
        public DbSet<Administrator> Administrators { get; set; }

        public AppDbContext()
            : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new MealConfiguration());
            modelBuilder.Configurations.Add(new DrinkConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}