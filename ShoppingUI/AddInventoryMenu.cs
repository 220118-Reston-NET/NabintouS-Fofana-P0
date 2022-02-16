using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class AddInventoryMenu : IMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddInventoryMenu
        private static Inventory _newInventory = new Inventory();

        //Dependency Injection
        //==========================
        
        private IInventoryBL _inventoryBL;
        public AddInventoryMenu(IInventoryBL b_inventoryBL)
        {
            _inventoryBL = b_inventoryBL;
        }
    
        //==========================
    
        public void Display()
        {
            Console.WriteLine("Enter Inventory information");
            Console.WriteLine("[7] Product quantity - " + _newInventory.ProductQuantity);
            Console.WriteLine("[6] Product name - " + _newInventory.ProductName);
            Console.WriteLine("[5] Product ID - " + _newInventory.ProductID);
            Console.WriteLine("[4] Store ID - " + _newInventory.StoreID);
            Console.WriteLine("[3] Store name - " + _newInventory.StoreName);
            Console.WriteLine("[2] Inventory ID - " + _newInventory.InventoryID);
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
                   _inventoryBL.AddInventory(_newInventory);
                    return MenuType.ManagerMainMenu;
                case "2":
                    Console.WriteLine("Please enter the inventory id!");
                    _newInventory.InventoryID = Console.ReadLine();
                    return MenuType.AddInventory;
                case "3":
                    Console.WriteLine("Please enter the store name!");
                    _newInventory.StoreName = Console.ReadLine();
                    return MenuType.AddInventory;
                case "4":
                    Console.WriteLine("Please enter the store id!");
                    _newInventory.StoreID = Console.ReadLine();
                    return MenuType.AddInventory;
                case "5":
                    Console.WriteLine("Please enter the product id!");
                    _newInventory.ProductID = Console.ReadLine();
                    return MenuType.AddInventory;
                case "6":
                    Console.WriteLine("Please enter the product name!");
                    _newInventory.ProductName = Console.ReadLine();
                    return MenuType.AddInventory;
                case "7":
                    Console.WriteLine("Please enter products quantity!");
                    _newInventory.ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    return MenuType.AddInventory;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.AddInventory;
            }
        }
    }
}