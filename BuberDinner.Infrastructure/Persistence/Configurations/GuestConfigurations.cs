using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host;
using BuberDinner.Domain.Host.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class GuestConfigurations : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            ConfigureGuestsTable(builder);
            ConfigureGuestRatingsTable(builder);
        }

        private void ConfigureGuestRatingsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(g =>  g.GuestRatings, rb =>
            {
                rb.ToTable("GuestRatings");

                rb.WithOwner().HasForeignKey("GuestId");

                rb.HasKey("Id", "GuestId");

                rb.Property(r => r.Id)
                    .HasColumnName("GuestRatingId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => GuestRatingId.Create(value));

                rb.Property(r => r.HostId)
                    .HasConversion(
                        id => id.Value,
                        value => HostId.Create(value));
                
                rb.HasOne<Host>()
                    .WithOne()
                    .HasForeignKey<GuestRating>(r => r.HostId)
                    .OnDelete(DeleteBehavior.Restrict);

                rb.Property(r => r.DinnerId)
                    .HasConversion(
                        id => id.Value,
                        value => DinnerId.Create(value));

                rb.HasOne<Dinner>()
                    .WithOne()
                    .HasForeignKey<GuestRating>(r => r.DinnerId)
                    .OnDelete(DeleteBehavior.Restrict);

                rb.OwnsOne(r => r.Rating);
            });
        }

        private void ConfigureGuestsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable("Guests");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => GuestId.Create(value));

            builder.Property(g => g.FirstName)
                .HasMaxLength(100);

            builder.Property(g => g.LastName)
                .HasMaxLength(100);

            builder.HasOne<User>()
                .WithOne()
                .HasForeignKey<Guest>(g => g.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(g => g.AverageRating);

            builder.Ignore(g => g.BillIds);

            builder.Ignore(g => g.MenuReviewIds);
            
            builder.Ignore(g => g.UpcomingDinnerIds);

            builder.Ignore(g => g.PastDinnerIds);

            builder.Ignore(g => g.PendingDinnerIds);
        }
    }
}
