using System.Data.Entity.ModelConfiguration;

namespace WebApplication.Models.DataBase.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Username");

            Property(u => u.Password)
                .IsRequired()
                .HasColumnName("Password");

            Property(u => u.FirstName)
                .IsOptional()
                .HasMaxLength(20)
                .HasColumnName("First Name");

            Property(u => u.LastName)
                .IsOptional()
                .HasMaxLength(30)
                .HasColumnName("Last Name");


            HasMany(u => u.MyOrders)
                .WithRequired(o => o.Customer);

        }
    }
}