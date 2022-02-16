using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class GetCustomerOrder : IMenu
    {
        private List<Customer> _listOfCustomer;
        private ICustomerBL _customerBL;
        public GetCustomerOrder(ICustomerBL b_customerBL)
        {
            _customerBL = b_customerBL;
            _listOfCustomer = _customerBL.GetAllCustomer();
        }
        public void Display()
        {
            foreach (var item in _listOfCustomer)
            {
                Console.WriteLine("====================");
                Console.WriteLine(item);
            }
            Console.WriteLine("[1] Select Order by Id");
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
                    Console.WriteLine("Enter CustomerID:");

                    try
                    {
                        string customerID = Console.ReadLine();
                        List<Order> _listOfOrder = _customerBL.GetOrderByCustomerID(customerID);
                        foreach (var item in _listOfOrder)
                        {
                            Console.WriteLine("======================");
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();

                        return MenuType.GeneralMenu;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please input a valid response");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        return MenuType.GetCustomerOrder;
                    }
                    
                    return MenuType.GetCustomerOrder;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.GetCustomerOrder;
            }
        }
    }
}