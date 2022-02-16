using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class AddProductMenu :  IMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddPokeMenu
        private static Product _newProduct = new Product();

        //Dependency Injection
        //==========================
        
        private IProductBL _productBL;
        public AddProductMenu(IProductBL b_productBL)
        {
            _productBL = b_productBL;
        }
        
        //==========================
        public void Display()
        {
            Console.WriteLine("Enter Product information");
           
            Console.WriteLine("[6] Product Price - " + _newProduct.ProductPrice);
            Console.WriteLine("[5] Product Quantity - " + _newProduct.ProductQuantity);
            Console.WriteLine("[4] Product Description - " + _newProduct.ProductDescription);
            Console.WriteLine("[3] Product Name - " + _newProduct.ProductName);
            Console.WriteLine("[2] Product id - " + _newProduct.ProductID);
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
                         Log.Information("Adding product \n" + _newProduct);
                    
                        _productBL.AddProduct(_newProduct);
                        Console.WriteLine("Product added");
                        Log.Information("Successful at adding product!");
                        Console.WriteLine("Please press Enter to go back to the previous menu");
                        Console.ReadLine();
                    return MenuType.GeneralMenu;
                case "2":
                    Console.WriteLine("Please enter the product id!");
                    _newProduct.ProductID = Console.ReadLine();
                    return MenuType.AddProduct;
                case "3":
                    Console.WriteLine("Please enter the product name!");
                    _newProduct.ProductName = Console.ReadLine();
                    return MenuType.AddProduct;
                case "4":
                    Console.WriteLine("Please enter the product description!");
                    _newProduct.ProductDescription = Console.ReadLine();
                    return MenuType.AddProduct;
                case "5":
                    Console.WriteLine("Please enter Quantity!");
                    _newProduct.ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    return MenuType.AddProduct;
                case "6":
                    Console.WriteLine("Please enter the price!");
                    _newProduct.ProductPrice = Convert.ToInt32(Console.ReadLine());
                    return MenuType.AddProduct;
    
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddProduct;
            }
        }
    }
}