using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.Common
{
    public class Constants
    {
        public static class AuthRoutes
        {
            public const string Login = "Auth/Login";
        }

        public static class OrderRoutes
        {
            public const string AddNewOrder = "Add/Order";
            public const string Orders = "Orders";
            public const string Order = "Order";
            public const string SalesReport = "Report/Sales";
            public const string Remove = "Remove/Order";
            public const string UpdateStatus = "Update/OrderStatus/{orderId}";

        }

        public static class InventoryItemRoutes
        {
            public const string Add = "Add/InventoryItem";
            public const string Get = "Get/InventoryItems";
            public const string Update = "Update/InventoryItem/{id}";
            public const string Delete = "Delete/InventoryItem/{id}";
        }

        public static class MenuItemInventoryRoutes
        {
            public const string Add = "Add/MenuItemInventory";
            public const string Update = "Update/MenuItemInventory/{id}";
            public const string Delete = "Delete/MenuItemInventory/{id}";
            public const string GetByMenuItemId = "Get/MenuItemInventory/MenuItem/{menuItemId}";
        }

        public static class TableRoutes
        {
            public const string Add = "Add/Table";
            public const string Get = "Get/Tables";
            public const string Update = "Update/Table/{id}";
            public const string Delete = "Delete/Table/{id}";
        }


        public static class MenuItemsRoutes
        {
            public const string GetMenus = "Menus";
            public const string GetMenuById = "Menu/{id}";
            public const string AddNewMenu = "Add/Menu";
            public const string UpdateMenu = "Update/Menu";
            public const string DeleteMenu = "Delete/Menu/{id}";
        }

        public static class ReservationRoutes
        {
            public const string GetAllTables = "Tables";
            public const string AddNewReservation = "Add/Reservation";
            public const string Update = "Update/Reservation/{id}";
        }
    }
}
