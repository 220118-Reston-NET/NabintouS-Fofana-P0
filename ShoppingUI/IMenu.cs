namespace ShoppingUI
{
    public enum MenuType
    {
        MainMenu,
        GeneralMenu,
        ManagerMainMenu,
        CustomerMainMenu,
        Exit,
        AddProduct,
        SearchProduct,
        AddCustomer,
        SearchCustomer,
        AddOrder,
        AddStoreFront,
        AddLineItemsMenu,
        AddInventory,
        ViewInventory,
        ViewInventory2,
        PlaceOrder,
        PlaceOrderMenu,  
        AddProductQuality,
        GetStoreOrder,
        GetStoreProduct,
        OrderHistory,
        GetProduct,
        GetAllProducts,
        GetProductDetail,
        StoreCustomerMenu,
        StoreManagerMenu,
        GetCustomerOrder,
        listOfStores,
        ReplenishInventory,
        ViewInventoryStoreByID,
        Replenishinventory,
        Stores,
        GetOrderLineItem,
        GetOrderLineitems,
        GetStoreFrontOrders,
        GetStoreFrontProducts,
        GetStoreFrontInventory,
    }

    public interface IMenu
    {
        /// <summary>
        /// Will display the menu and user choices in the terminal
        /// </summary>
        void Display();
        
        

        /// <summary>
        /// Will record the user's choice and change/route your menu based on that choice
        /// </summary>
        /// <returns>Return the menu that will change your screen</returns>
         MenuType UserChoice();
    }

    //public interface ICustomerMenu{

    //}
    
}