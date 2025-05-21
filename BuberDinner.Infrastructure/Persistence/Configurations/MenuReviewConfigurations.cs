using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview;
using BuberDinner.Domain.MenuReview.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class MenuReviewConfigurations : IEntityTypeConfiguration<MenuReview>
    {
        public void Configure(EntityTypeBuilder<MenuReview> builder)
        {
            builder.ToTable("MenuReviews");
            
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuReviewId.Create(value));

            builder.OwnsOne(r => r.Rating);

            builder.Property(m => m.HostId)
                .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value));

            builder.HasOne<Host>()
                .WithMany()
                .HasForeignKey(m => m.HostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.MenuId)
                .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value));

            builder.HasOne<Menu>()
                .WithMany()
                .HasForeignKey(m => m.MenuId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.GuestId)
                .HasConversion(
                    id => id.Value,
                    value => GuestId.Create(value));

            builder.HasOne<Guest>()
                .WithMany()
                .HasForeignKey(m => m.GuestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.DinnerId)
                .HasConversion(
                    id => id.Value,
                    value => DinnerId.Create(value));

            builder.HasOne<Dinner>()
                .WithMany()
                .HasForeignKey(m => m.DinnerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
