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
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Number)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(t => t.Seats)
                   .IsRequired();

            builder.Property(t => t.IsAvailable)
                   .IsRequired();

            builder.HasMany(t => t.Reservations)
                   .WithOne(r => r.Table)
                   .HasForeignKey(r => r.TableId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
