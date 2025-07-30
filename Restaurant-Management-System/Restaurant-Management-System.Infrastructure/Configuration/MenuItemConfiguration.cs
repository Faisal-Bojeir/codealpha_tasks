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
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(mi => mi.Id);

            builder.Property(mi => mi.Name)
                   .IsRequired()
                   .HasColumnType("nvarchar(max)");

            builder.Property(mi => mi.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(mi => mi.IsAvailable)
                   .IsRequired();

            builder.Property(mi => mi.ImageUrl)
                   .HasColumnType("nvarchar(max)");

            builder.HasMany(mi => mi.OrderItems)
                   .WithOne(oi => oi.MenuItem)
                   .HasForeignKey(oi => oi.MenuItemId);

            builder.HasMany(mi => mi.MenuItemInventories)
                   .WithOne(mii => mii.MenuItem)
                   .HasForeignKey(mii => mii.MenuItemId);
        }
    }

}
