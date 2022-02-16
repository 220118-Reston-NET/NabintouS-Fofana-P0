using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class AddLineItemsMenu : IMenu
    {

        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddPokeMenu
        private static LineItem _newLineItem = new LineItem();
    
        //Dependency Injection
        //==========================
        
        private ILineItemsBL _LineItemsBL;
        public AddLineItemsMenu(ILineItemsBL b_LienItemsBL)
        {
           _LineItemsBL = b_LienItemsBL;
        }
        

        //==========================
        public void Display()
        {
            Console.WriteLine("Enter product informations");
            Console.WriteLine("[6] Product quantity - " + _newLineItem.ProductQuantity);
            Console.WriteLine("[5] Product name - " + _newLineItem.ProductName);
            Console.WriteLine("[4] Product ID - " + _newLineItem.ProductID);
            Console.WriteLine("[3] Order ID - " + _newLineItem.OrderID);
            Console.WriteLine("[2] LineItem ID - " + _newLineItem.LineItemID);
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
                    Log.Information("Adding product \n" + _newLineItem);
                        _LineItemsBL .AddLineItems(_newLineItem);
                        Log.Information("Successful at product!");
                    return MenuType.ManagerMainMenu;
                case "2":
                    Console.WriteLine("Please enter the lineitems id!");
                    _newLineItem.LineItemID = Console.ReadLine();
                    return MenuType.AddLineItemsMenu;
                case "3":
                    Console.WriteLine("Please enter the order id!");
                    _newLineItem.OrderID = Console.ReadLine();
                    return MenuType.AddLineItemsMenu;
                case "4":
                    Console.WriteLine("Please enter the product id!");
                    _newLineItem.ProductID = Console.ReadLine();
                    return MenuType.AddLineItemsMenu;
                case "5":
                    Console.WriteLine("Please enter the product name!");
                    _newLineItem.ProductName = Console.ReadLine();
                    return MenuType.AddLineItemsMenu;
                 case "6":
                    Console.WriteLine("Please enter the product quantity!");
                    _newLineItem.ProductQuantity = Console.ReadLine();
                    return MenuType.AddLineItemsMenu;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddLineItemsMenu;
            }
        }
    }
}