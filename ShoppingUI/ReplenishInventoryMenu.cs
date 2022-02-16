using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class Replenishinventory : IMenu
    {

        //Dependency injection
        private List<StoreFront> _listOfStoreFront;
        private IStoreFrontBL _storefrontBL;
        public Replenishinventory(IStoreFrontBL b_listOfStoreFront)
        {
            _storefrontBL = b_listOfStoreFront;
             _listOfStoreFront = _storefrontBL.GetAllStoreFront();
        }

        public void Display()
        {   
            Console.WriteLine("HERE ARE ALL STORES");
              
            foreach (var item in _listOfStoreFront)
            {
                Console.WriteLine("====================");
                Console.WriteLine(item);
                Console.WriteLine(" ");   
                
            }
            Console.WriteLine("[1] Select store by ID");
                Console.WriteLine("[0] Go Back");
                Console.WriteLine(" ");

        }

        public MenuType UserChoice()
        {

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    
                    Console.WriteLine("CHOOSE THE STORE YOU WANT TO REPLENISH");
                    Console.WriteLine("Enter store ID");
                    string storeID = Console.ReadLine();
                    _storefrontBL.GetStoreFrontByStoreID(storeID);
                    
                    
                    Console.WriteLine("Store inventory has been replenished!");
                    Log.Information("Item successfully replenished.");
                    Console.ReadLine();
                    return MenuType.Replenishinventory;
                case "0":
                    Log.Information("Back to the main menu.");
                    return MenuType.GeneralMenu;
                default:
                    Console.WriteLine("You entered an illegal character! Please try again.");
                    Log.Warning("User entered an illegal menu option.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    return MenuType.Replenishinventory;
            }
        }

    }

}