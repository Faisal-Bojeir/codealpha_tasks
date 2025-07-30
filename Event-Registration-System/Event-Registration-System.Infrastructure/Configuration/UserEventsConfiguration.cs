using Event_Registration_System.Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Infrastructure.Configuration
{
    public class UserEventsConfiguration : IEntityTypeConfiguration<UserEvents>
    {
        public void Configure(EntityTypeBuilder<UserEvents> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.User)
                .WithMany(p => p.UserEvents)
                .HasForeignKey(ue => ue.UserId);

            builder.HasOne(p => p.Event)
                .WithMany(p => p.UserEvents)
                .HasForeignKey(p => p.EventId);
        }
    }
}
