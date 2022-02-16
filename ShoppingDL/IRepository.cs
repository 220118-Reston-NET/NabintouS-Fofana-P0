using ShoppingModel;

namespace ShoppingDL
{
    // Product Interface repository
    public interface IRepository_p
    {
        /// <summary>
        /// Adding product to the database
        /// </summary>
        /// <param name="b_product"></param>
        /// <returns></returns>
        Product AddProduct(Product b_product);

         /// <summary>
         /// Getting all product
         /// </summary>
         /// <returns></returns>
        List<Product> GetAllProduct(); 
        Product UpdateProduct(Product b_product);
        List<Product> GetProductsByProductID(string b_productID);

        List<Product> GetAllProductsFromStore(string b_storeID);
        List<StoreFront> GetAllStoreFrontsByProductID(string b_productID);

        Product GetProductDetailByProductId(string b_productID);
    }

    // Customer Interface repository
    public interface IRepository_c
    {
        Customer AddCustomer(Customer b_customer);
        List<Customer> GetAllCustomer();  
        Customer UpdateCustomer(Customer b_customer);   
        List<Order> GetOrderByCustomerID(string b_customerID);
        
    }

    
    // Order Interface repository
     public interface IRepository_o
    {
        Order AddOrder(Order b_order);
        //LineItem PlaceOrder(LineItem b_lineItems, string b_orderID);
        List<Order> GetAllOrder();  
        List<Order> GetOrderByStoreID(string b_StoreID);
        List<LineItem> GetLineItemsByOrderId(string b_orderID);
        List<LineItem> GetAllLineItems();
        List<LineItem> GetLineItemByOrderID(string b_orderID);

    }

    
    // Storefront Interface repository
     public interface IRepository_s
    {
        StoreFront AddStoreFront(StoreFront b_storefront);
        List<StoreFront> GetAllStoreFront();  
        StoreFront UpdateStoreFront(StoreFront b_storefront); 
        //List<Product> GetAllProductsFromStore(string b_storeID);
        List<StoreFront> GetStoreFrontByStoreID (string b_storeID);

        List<Order> GetOrderByStoreFrontID(string b_storeID);

         List<Product> GetProductByStoreFrontID(string b_storeID);
        List<Inventory> GetInventoryByStoreFrontID(string b_storeID);
    }

    
    public interface IRepository_i
    {
        LineItem AddLineItems(LineItem b_lineitems);
        List<LineItem> GetAllLineItems(); 
    }
    // Inventory Interface repository
    public interface IRepository_v
    {
        Inventory AddInventory(Inventory b_inventory);
      //  List<Inventory> GetAllProductsFromStore(string b_storeID);
        //List<Inventory> GetAllProduct();
        void ReplenishProduct(string b_inventory, string b_quantity);
        List<Inventory> GetAllOfInventory();
        List<Inventory> GetInventoryByStoreID(string b_storeID);
        List<Inventory> GetAllProductByProductID(string b_productID);
    }
    
}


