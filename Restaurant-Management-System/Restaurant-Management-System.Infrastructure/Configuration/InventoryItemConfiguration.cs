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
    public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
    {
        public void Configure(EntityTypeBuilder<InventoryItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                   .IsRequired()
                   .HasColumnType("nvarchar(max)");

            builder.Property(i => i.Quantity)
                   .IsRequired();

            builder.HasMany(i => i.MenuItemInventories)
                   .WithOne(mi => mi.InventoryItem)
                   .HasForeignKey(mi => mi.InventoryItemId);
        }
    }
}
