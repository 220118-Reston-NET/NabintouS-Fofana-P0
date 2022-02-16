using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class GetStoreOrder : IMenu
    {
        private List<Order> _listOfOrder;
        private IOrderBL _orderBL;
        public GetStoreOrder(IOrderBL b_orderBL)
        {
            _orderBL = b_orderBL;
            _listOfOrder = _orderBL.GetAllOrder();
        }
        public void Display()
        {
            Console.WriteLine("Customer Order history");
            
            foreach (var item in _listOfOrder)
            {
                Console.WriteLine("====================");
                Console.WriteLine(item);
            }
            
            Console.WriteLine("[1] Select store by Id");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine(" ");
            
        }

        public MenuType UserChoice()
        {
            /*
            Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
             return MenuType.MainMenu;
            */
            string userInput = Console.ReadLine();

            //Switch cases are just useful if you are doing a bunch of comparison
            switch (userInput)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    Console.WriteLine("Enter StoreID:");

                    try
                    {
                        string StoreID = Console.ReadLine();
                        List<Order> listOfOrder = _orderBL.GetOrderByStoreID(StoreID);
                        foreach (var item in listOfOrder)
                        {
                            Console.WriteLine("======================");
                            Console.WriteLine(item);
                         
                        }
                          Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();

                        return MenuType.MainMenu;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please input a valid response");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        return MenuType.GetStoreOrder;
                    }
                    
                    return MenuType.GetStoreOrder;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.GetStoreOrder;
            }
            
        }
    }
}