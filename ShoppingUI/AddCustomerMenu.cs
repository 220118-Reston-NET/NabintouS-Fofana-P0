using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class AddCustomerMenu : IMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddCustomerMenu
        private static Customer _newCustomer = new Customer();

        //Dependency Injection
        //==========================
        
        private ICustomerBL _customerBL;
        public AddCustomerMenu(ICustomerBL b_customerBL)
        {
            _customerBL = b_customerBL;
        }
    
        //==========================
    
        public void Display()
        {
            Console.WriteLine("Enter Customer information");
            Console.WriteLine("[5] Address - " + _newCustomer.CustomerAddress);
            Console.WriteLine("[4] Email - " + _newCustomer.CustomerEmail);
            Console.WriteLine("[3] Name - " + _newCustomer.CustomerName);
            Console.WriteLine("[2] ID - " + _newCustomer.CustomerID);
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
                    
                    Log.Information("Adding new customer " + _newCustomer);
                        _customerBL.AddCustomer(_newCustomer);
                        Console.WriteLine("Customer added");
                        Log.Information("Successful at adding customer!");
                        Console.WriteLine("Please press Enter to go back to the previous menu");
                        Console.ReadLine();
                    return MenuType.ManagerMainMenu;
                case "2":
                    Console.WriteLine("Please enter the customer id!");
                    _newCustomer.CustomerID = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "3":
                    Console.WriteLine("Please enter the customer name!");
                    _newCustomer.CustomerName = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "4":
                    Console.WriteLine("Please enter the customer Email!");
                    _newCustomer.CustomerEmail = Console.ReadLine();
                    return MenuType.AddCustomer;
                case "5":
                    Console.WriteLine("Please enter the customer address!");
                    _newCustomer.CustomerAddress = Console.ReadLine();
                    return MenuType.AddCustomer;
               
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddCustomer;
            }
        }
   }
}