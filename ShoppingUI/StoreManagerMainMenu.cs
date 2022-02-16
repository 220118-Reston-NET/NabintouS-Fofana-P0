namespace ShopUI
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
            /*
            Console.WriteLine("[1] Add Order");
            Console.WriteLine("[2] Add product");
            Console.WriteLine("[3] Search product");
            Console.WriteLine("[4] Add customer");
            Console.WriteLine("[5] Search customer");
            Console.WriteLine("[6] Get Line item from order");
            Console.WriteLine("[7] Add Store");
            Console.WriteLine("[8] Add Store inventory");
            Console.WriteLine("[9] View Store inventory");
            Console.WriteLine("[10] View all products");
            Console.WriteLine("[11] View order history");
            //Console.WriteLine("[13] Get orders from store");
            Console.WriteLine("[14] Get products from store");
            */
            Console.WriteLine("[12] Go back");
            
            Console.WriteLine("[0] Exit");
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.Exit;
                    /*
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
               // case "6":
                 //   return MenuType.GetOrderLineitems;
                case "7":
                    return MenuType.AddStoreFront;
                case "8":
                    return MenuType.AddInventory;
                case "9":
                    return MenuType.ViewInventory;
                case "10":
                    return MenuType.GetProduct;
                case "11":
                    return MenuType.OrderHistory;
                    */
                case "12":
                    return MenuType.GeneralMenu;
                    /*
                case "14":
                    return MenuType.GetStoreProducts;
                    */
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.GeneralMenu;
            }
        }
    }
}