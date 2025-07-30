using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant_Management_System.Domain.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Configuration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.TableId)
                   .IsRequired();

            builder.Property(r => r.CustomerName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.ReservationTime)
                   .IsRequired();

            builder.Property(r => r.NumberOfGuests)
                   .IsRequired();

            builder.Property(r => r.Status)
                   .IsRequired()
                   .HasConversion<string>();

            builder.HasOne(r => r.Table)
                   .WithMany(t => t.Reservations)
                   .HasForeignKey(r => r.TableId);
        }
    }

}
