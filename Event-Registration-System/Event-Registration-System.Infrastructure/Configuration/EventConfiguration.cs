using Event_Registration_System.Domain.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Infrastructure.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Title)
               .IsRequired()
               .HasMaxLength(200);

            builder.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(e => e.Location)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.StartDate)
                   .IsRequired();

            builder.Property(e => e.EndDate)
                   .IsRequired();

            builder.Property(e => e.SeatsAvailable)
                   .IsRequired()
                   .HasDefaultValue(0);

            builder.Property(e => e.IsDeleted)
                   .IsRequired()
                   .HasDefaultValue(false);
        }
    }
}
