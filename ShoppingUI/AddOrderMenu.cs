using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class AddOrderMenu : IMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddPokeMenu
        private static Order _newOrder = new Order();

        //Dependency Injection
        //==========================
        
        private IOrderBL _orderBL;
        public AddOrderMenu(IOrderBL b_orderBL)
        {
            _orderBL = b_orderBL;
        }

        //==========================

        public void Display()
        {
            Console.WriteLine("Enter order information");
            Console.WriteLine("[2] Order id - " + _newOrder.OrderID);
            Console.WriteLine("[3] Customer id - " + _newOrder.CustomerID);
            Console.WriteLine("[4] Store id - " + _newOrder.StoreID);
            Console.WriteLine("[5] Store location - " + _newOrder.StoreLocation);
            Console.WriteLine("[6] Total price - " + _newOrder.TotalPrice);
            //Console.WriteLine("[7] Line items - " + _newOrder.LineItems);
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.GeneralMenu;
                case "1":
                      Log.Information("Adding order \n" + _newOrder);
                        _orderBL.AddOrder(_newOrder);
                        Console.WriteLine("Order placed");
                        Log.Information("Successful at adding the order!");
                        Console.WriteLine("Please press Enter to go back to the previous menu");
                        Console.ReadLine();
                    return MenuType.GeneralMenu;
                    
                case "2":
                    Console.WriteLine("Please enter the order id!");
                    _newOrder.OrderID = Console.ReadLine();
                    return MenuType.AddOrder;
                case "3":
                    Console.WriteLine("Please enter the customer id!");
                   _newOrder.CustomerID = Console.ReadLine();
                    return MenuType.AddOrder;
                case "4":
                    Console.WriteLine("Please enter the store id!");
                    _newOrder.StoreID = Console.ReadLine();
                    return MenuType.AddOrder;
                case "5":
                    Console.WriteLine("Please enter the store location!");
                    _newOrder.StoreLocation = Console.ReadLine();
                    return MenuType.AddOrder;
                case "6":
                    Console.WriteLine("Please enter the total price!");
                    _newOrder.TotalPrice = Convert.ToInt32(Console.ReadLine());
                    return MenuType.AddOrder;
                
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddOrder;
            }
        }
    }
}