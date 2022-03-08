using System.Data.Entity.ModelConfiguration;

namespace WebApplication.Models.DataBase.EntityConfigurations
{
    public class MealConfiguration : EntityTypeConfiguration<MealHelper>
    {
        public MealConfiguration()
        {
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            Property(m => m.Price)
                .IsRequired()
                .HasColumnType("decimal");


            //.HasColumnType("decimal(6,2)")

            Property(m => m.Quantity)
                .IsRequired();

            
                //.HasColumnType("smallint")
        }
    }
}