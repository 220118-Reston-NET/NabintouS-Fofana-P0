namespace ShoppingUI
{
    public class StoreCustomerMainMenu : IMenu
    {
        public void Display()
        {

            Console.WriteLine("================================");
            Console.WriteLine("WECOME TO THE CUSTOMER MAIN MENU");
            Console.WriteLine("=================================");
            Console.WriteLine(" ");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(" ");
            Console.WriteLine("[5] Go back");
            Console.WriteLine("[4] Search product");
            Console.WriteLine("[3] See all products");
            Console.WriteLine("[2] Order History");
            Console.WriteLine("[1] Place Order");
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
                    return MenuType.PlaceOrderMenu;
                case "2":
                    return MenuType.OrderHistory;
                case "3":
                    return MenuType.GetStoreFrontProducts;
                case "4":
                    return MenuType.SearchProduct;
                case "5":
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