using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Mapping.MenuItems
{
    public class MenuItemsMap : BNAEntityTypeConfiguration<MenuItem>
    {
        public MenuItemsMap()
        {
            this.HasOptional(m => m.Parent)
                .WithMany().HasForeignKey(m => m.ParentMenuItemId);

            this.HasOptional(m => m.Menu).WithMany().HasForeignKey(m => m.MenuId);
        }
    }
}
