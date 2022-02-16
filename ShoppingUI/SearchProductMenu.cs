using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class SearchProductMenu : IMenu
    {
        private IProductBL _productBL;
        public SearchProductMenu(IProductBL b_productBL)
        {
            _productBL = b_productBL;
        }

        public void Display()
        {
            Console.WriteLine("Please select an option to filter the products database");
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
                    List<Product> listOfProduct = _productBL.SearchProduct(name);
                    //List<Product> listOfProduct = new List<Product>();
                    
                    foreach (var item in listOfProduct)
                    {
                        Console.WriteLine("================");
                        Console.WriteLine(item);
                    }
                    
                    
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    //return MenuType.PlaceOrderMenu;

                    return MenuType.GeneralMenu;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.SearchProduct;

            }
        }

    }
}
