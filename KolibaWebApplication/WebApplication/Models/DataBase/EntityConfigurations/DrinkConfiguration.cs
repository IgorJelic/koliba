using System.Data.Entity.ModelConfiguration;

namespace WebApplication.Models.DataBase.EntityConfigurations
{
    public class DrinkConfiguration : EntityTypeConfiguration<Drink>
    {
        public DrinkConfiguration()
        {
            Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(40);

            Property(d => d.Price)
                .IsRequired()
                .HasColumnType("decimal");

            
                //.HasColumnType("decimal(6,2)")

            Property(d => d.Quantity)
                .IsRequired();

            
                //.HasColumnType("smallint")
        }
    }
}