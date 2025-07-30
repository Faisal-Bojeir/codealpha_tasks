using Event_Registration_System.Domain.Entities.Enum;
using Event_Registration_System.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.MiddleName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Username).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Role).IsRequired();

            builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.HasData(LoadUsers());
        }

        private List<User> LoadUsers()
        {
            return new List<User>()
            {
                new User
                {
                    Id = 1,
                    FirstName = "Faisal",
                    MiddleName = "Ahmed",
                    LastName = "Bojeir",
                    Username = "faisal.b",
                    Password = "faisal123",
                    Role = enRole.User,
                },
                new User
                {
                    Id = 2,
                    FirstName = "Sara",
                    MiddleName = "Mohamed",
                    LastName = "Ali",
                    Username = "sara.a",
                    Password = "sara123",
                    Role = enRole.Admin,
                },
            };
        }
    }
}
