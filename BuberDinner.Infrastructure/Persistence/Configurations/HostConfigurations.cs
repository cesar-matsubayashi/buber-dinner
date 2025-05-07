using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Host;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class HostConfigurations : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            builder.ToTable("Hosts");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value));

            builder.Property(h => h.FirstName)
                .HasMaxLength(100);

            builder.Property(h => h.LastName)
                .HasMaxLength(100);

            builder.Property(h => h.ProfileImage)
                .HasMaxLength(255);

            builder.OwnsOne(h => h.AverageRating);

            builder.Property(h => h.UserId)
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

            builder.HasOne<User>()
                .WithOne()
                .HasForeignKey<Host>(h => h.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(h => h.MenuIds);

            builder.Ignore(h => h.DinnerIds);
        }
    }
}
