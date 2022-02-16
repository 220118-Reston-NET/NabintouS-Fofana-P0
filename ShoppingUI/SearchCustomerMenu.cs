using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class SearchCustomerMenu : IMenu
    {
        private ICustomerBL _customerBL;
        public SearchCustomerMenu(ICustomerBL c_customerBL)
        {
            _customerBL = c_customerBL;
        }

        public void Display()
        {
            Console.WriteLine("Please select an option to filter the customer database");
            Console.WriteLine("[1] By Name");
            Console.WriteLine("[0] Go back");
        }
        
        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.GeneralMenu;
                case "1":
            
                    //Logic to grab user input
                    Console.WriteLine("Please enter a name");
                    string name = Console.ReadLine();

                    //Logic to display the result
                   //List<Customer> listOfCustomer = new List<Customer>();
                   List<Customer> listOfCustomer = _customerBL.SearchCustomerByName(name);
                    
                    foreach (var item in listOfCustomer)
                    {
                        Console.WriteLine("================");
                        Console.WriteLine(item);
                    }
                    
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return  MenuType.GeneralMenu;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.SearchCustomer;

            }
            
        }

    
    }
}
