namespace ShopUI
{
    public enum MenuType
    {
        GeneralMenu,
        StoreManagerMainMenu,
        StoreCustomerMainMenu,
        Exit,
        
        AddProduct,
        SearchProduct,
        AddCustomer,
        SearchCustomer,
        AddOrder,
        AddStoreFront,
        AddLineItems,
        AddInventory,
        ViewInventory,
        PlaceOrder,
        PlaceOrderMenu,  
        AddProductQuality,
        GetStoreOrder,
        GetStoreProduct,
        OrderHistory,
        GetProduct,
        GetStoreProducts,
        GetProductDetail,
        StoreCustomerMenu,
        StoreManagerMenu,
        GetCustomerOrder,
        listOfStores,
        ReplenishInventory,
        ViewInventoryStoreByID,
    
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

    //}
    
}