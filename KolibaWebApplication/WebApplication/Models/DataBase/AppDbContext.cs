using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication.Models.DataBase.EntityConfigurations;

namespace WebApplication.Models.DataBase
{
    public class AppDbContext : DbContext
    {
        DbSet<Meal> Meals { get; set; }
        DbSet<Drink> Drinks { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Salesman> Salesmans { get; set; }
        DbSet<Administrator> Administrators { get; set; }

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