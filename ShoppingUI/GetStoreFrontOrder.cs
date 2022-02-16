using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class GetStoreFrontOrders : IMenu
    {
        private List<StoreFront> _listOfStoreFront;
        private IStoreFrontBL _storefrontBL;
        public GetStoreFrontOrders(IStoreFrontBL p_storefrontBL)
        {
            _storefrontBL = p_storefrontBL;
            _listOfStoreFront = _storefrontBL.GetAllStoreFront();
        }
        public void Display()
        {
            foreach (var item in _listOfStoreFront)
            {
                Console.WriteLine("====================");
                Console.WriteLine(item);
            }
            Console.WriteLine("[1] Select store by Id");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();

            //Switch cases are just useful if you are doing a bunch of comparison
            switch (userInput)
            {
                case "0":
                    return MenuType.ManagerMainMenu;
                case "1":
                    Console.WriteLine("Enter StoreID:");

                    try
                    {
                        string orderID = Console.ReadLine();
                        List<Order> listOfOrder = _storefrontBL.GetOrderByStoreFrontID(orderID);
                        foreach (var item in listOfOrder)
                        {
                            Console.WriteLine("======================");
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();

                        return MenuType.ManagerMainMenu;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please input a valid response");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        return MenuType.GetStoreFrontOrders;
                    }
                    
                    return MenuType.GetStoreFrontOrders;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.GetStoreFrontOrders;
            }
        }
    }
}