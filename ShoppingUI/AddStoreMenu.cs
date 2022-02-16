using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class AddStoreFrontMenu : IMenu
    {
        //static non-access modifier 
        private static StoreFront _newStoreFront = new StoreFront();

        //Dependency Injection
        //==========================
        
        private IStoreFrontBL _storefrontBL;
        public AddStoreFrontMenu(IStoreFrontBL b_storefrontBL)
        {
            _storefrontBL = b_storefrontBL;
        }
        
        //==========================

        public void Display()
        {
            Console.WriteLine("Enter Store information");
            Console.WriteLine("[4] Store Address - " + _newStoreFront.StoreLocation);
            Console.WriteLine("[3] Store Name - " + _newStoreFront.StoreName);
            Console.WriteLine("[2] Store id - " + _newStoreFront.StoreID);
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.ManagerMainMenu;
                case "1":
                     Log.Information("Adding Store front information \n" + _newStoreFront);
                        _storefrontBL.AddStoreFront(_newStoreFront);
                        Console.WriteLine("Store added");
                        Log.Information("Successful at adding Store front information!");
                        Console.WriteLine("Please press Enter to go back to the previous menu");
                        Console.ReadLine();
                    return MenuType.ManagerMainMenu;
                case "2":
                    Console.WriteLine("Please enter the store id!");
                    _newStoreFront.StoreID = Console.ReadLine();
                    return MenuType.AddStoreFront;
                case "3":
                    Console.WriteLine("Please enter the store name!");
                    _newStoreFront.StoreName = Console.ReadLine();
                    return MenuType.AddStoreFront;
                case "4":
                    Console.WriteLine("Please enter the store location!");
                    _newStoreFront.StoreLocation = Console.ReadLine();
                    return MenuType.AddStoreFront;
                    
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddStoreFront;
            }
        }
    }
}