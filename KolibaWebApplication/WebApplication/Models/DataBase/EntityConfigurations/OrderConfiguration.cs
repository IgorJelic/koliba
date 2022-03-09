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

            Property(o => o.Delivered)
                .HasColumnName("IsDelivered");

            HasMany(o => o.OrderedMeals)
                .WithMany(m => m.Orders)
                .Map(m =>
                {
                    m.ToTable("OrderedMeals");
                    m.MapLeftKey("OrderId");
                    m.MapRightKey("OrderedMealId");
                });

            HasMany(o => o.OrderedDrinks)
                .WithMany(d => d.Orders)
                .Map(m =>
                {
                    m.ToTable("OrderedDrinks");
                    m.MapLeftKey("OrderId");
                    m.MapRightKey("OrderedDrinkId");

                });

        }
    }
}