namespace ShoppingUI
{
    public class StoreManagerMainMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("WECOME TO THE STORE MANAGER MAIN MENU");
            Console.WriteLine("=======================================");
            Console.WriteLine(" ");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(" ");
            Console.WriteLine("[1] Add Order");
            Console.WriteLine("[2] Add product");
            Console.WriteLine("[3] Search product");
            Console.WriteLine("[4] Add customer");
            Console.WriteLine("[5] Search customer");
            Console.WriteLine("[6] Add Line items");
            Console.WriteLine("[7] Get Line item from order");
            Console.WriteLine("[8] Add Store");
            Console.WriteLine("[9] Add Store inventory");
            Console.WriteLine("[10] View Store inventory");
            Console.WriteLine("[11] View Store order");
            Console.WriteLine("[12] View all products");
            Console.WriteLine("[13] View order history");
            Console.WriteLine("[14] Get products from store");
            Console.WriteLine("[15] Replenish inventory");
            Console.WriteLine("[16] Go back");
            Console.WriteLine("[0] Exit");
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.Exit;
                case "1":
                    return MenuType.AddOrder;
                case "2":
                    return MenuType.AddProduct;
                case "3":
                    return MenuType.SearchProduct;
                case "4":
                    return MenuType.AddCustomer;
                case "5":
                    return MenuType.SearchCustomer;
                case "6":
                    return MenuType.AddLineItemsMenu;
                case "7":
                    return MenuType.GetOrderLineitems;
                case "8":
                    return MenuType.AddStoreFront;
                case "9":
                    return MenuType.AddInventory;
                case "10":
                    return MenuType.GetStoreFrontInventory;
                case "11":
                    return MenuType.GetStoreFrontOrders;
                case "12":
                    return MenuType.GetProduct;
                case "13":
                    return MenuType.OrderHistory;
                case "14":
                    return MenuType.GetStoreFrontProducts;
                case "15":
                    return MenuType.Replenishinventory;
                case "16":
                    return MenuType.GeneralMenu;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.GeneralMenu;
            }
        }
    }
}