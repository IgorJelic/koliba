using System.Data.Entity.ModelConfiguration;

namespace WebApplication.Models.DataBase.EntityConfigurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            Property(o => o.Delivery)
                .IsRequired()
                .HasColumnName("Home Delivery");

            HasMany(o => o.Meals)
                .WithMany(m => m.Orders)
                .Map(m =>
                {
                    m.ToTable("OrderedMeals");
                    m.MapLeftKey("OrderId");
                    m.MapRightKey("MealId");
                });

            HasMany(o => o.Drinks)
                .WithMany(d => d.Orders)
                .Map(m =>
                {
                    m.ToTable("OrderedDrinks");
                    m.MapLeftKey("OrderId");
                    m.MapRightKey("DrinkId");

                }); 
        }
    }
}