using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant_Management_System.Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Configuration
{
    public class MenuItemInventoryConfiguration : IEntityTypeConfiguration<MenuItemInventory>
    {
        public void Configure(EntityTypeBuilder<MenuItemInventory> builder)
        {
            builder.HasKey(mii => new { mii.MenuItemId, mii.InventoryItemId });

            builder.Property(mii => mii.QuantityUsed)
                   .IsRequired();
        }
    }

}
