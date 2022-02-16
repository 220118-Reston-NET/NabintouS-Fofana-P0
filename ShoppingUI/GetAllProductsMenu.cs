using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class GetAllProductsMenu : IMenu
    {
        private List<Product> _listOfProduct;
        private IProductBL _productBL;
        public GetAllProductsMenu(IProductBL b_productBL)
        {
            _productBL = b_productBL;
            _listOfProduct = _productBL.GetAllProduct();
        }
        public void Display()
        {
            foreach (var item in _listOfProduct)
            {
                Console.WriteLine("====================");
                Console.WriteLine(item);
            }
            Console.WriteLine(" ");
            Console.WriteLine("[Let's search product by product ID");
            Console.WriteLine(" ");
            Console.WriteLine("[1] Select product by ID");
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
                    Console.WriteLine("Enter product ID:");

                    try
                    {
                        string productID = Console.ReadLine();
                        List<Product> listOfProduct = _productBL.GetProductsByProductID(productID);
                        foreach (var item in listOfProduct)
                        {
                            Console.WriteLine("======================");
                            Console.WriteLine(item);
                            return MenuType.PlaceOrder;
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
                        return MenuType.GeneralMenu;
                    }
                    
                    return MenuType.GetAllProducts;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.GetAllProducts;
            }
        }
    }
}