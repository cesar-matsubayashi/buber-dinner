﻿using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class DinnerConfigurations : IEntityTypeConfiguration<Dinner>
    {
        public void Configure(EntityTypeBuilder<Dinner> builder)
        {
            ConfigureDinnersTable(builder);
            ConfigureReservationsTable(builder);
        }

        private void ConfigureReservationsTable(EntityTypeBuilder<Dinner> builder)
        {
            builder.OwnsMany(d => d.Reservations, rb =>
            {
                rb.ToTable("Reservations");

                rb.WithOwner().HasForeignKey("DinnerId");

                rb.HasKey("Id", "DinnerId");

                rb.Property(r => r.Id)
                    .HasColumnName("ReservationId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => ReservationId.Create(value));

                rb.Property(r => r.Status)
                    .HasConversion<string>();

                rb.Property(r => r.GuestId)
                    .HasConversion(
                        id => id.Value,
                        value => GuestId.Create(value));

                rb.Property(r => r.BillId)
                    .HasConversion(
                        id => id.Value,
                        value => BillId.Create(value));
            });
        }

        private void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
        {
            builder.ToTable("Dinners");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => DinnerId.Create(value));

            builder.Property(d => d.Name)
                .HasMaxLength(100);

            builder.Property(d => d.Description)
                .HasMaxLength(100);

            builder.Property(d => d.Status)
                .HasConversion<string>();

            builder.OwnsOne(d => d.Price);

            builder.OwnsOne(d => d.Location);

            builder.Property(d => d.MenuId)
                .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value));

            builder.HasOne<Menu>()
                .WithMany()
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Host>()
                .WithMany()
                .HasForeignKey(d => d.HostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
