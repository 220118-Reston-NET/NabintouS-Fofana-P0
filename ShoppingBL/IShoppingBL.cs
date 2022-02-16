 using ShoppingModel;

namespace ShoppingBL
{
 public interface IProductBL
    {   
        Product AddProduct(Product b_product);
        List<Product> SearchProduct(string p_name); 
        Product UpdateProduct(Product b_product);
        List<Product> GetAllProduct();
        List<Product> GetAllProductsFromStore(string b_storeID);
        Product GetProductDetail(string b_productID);
        //List<Product> GetProductsByStoreID(string b_StoreID);

        List<Product> GetProductsByProductID(string b_productID);
        List<StoreFront> GetAllStoreFrontsByProductID(string b_productID);
        
    }


     public interface ICustomerBL
    {
        Customer AddCustomer(Customer b_customer);
        Customer UpdateCustomer(Customer b_customer);
        List<Customer> GetAllCustomer();
        Customer GetCustomerInfoByID(string b_customerID);
        List<Customer> SearchCustomerByName(string p_name);   
        List<Order> GetOrderByCustomerID(string b_customerID); 
       
    }


     public interface IOrderBL
    {
        Order AddOrder(Order b_order);
        LineItem PlaceOrder(LineItem b_lineItems, int orderID);
        List<Order> GetAllOrder();
        List<Order> GetOrderByStoreID(string b_StoreID);
        Order GetOrderByOrderID(string b_orderID);
        List<Order> GetAllOrderByCustomerID(string b_customerID);
        List<LineItem> GetLineItemByOrderID(string b_orderID); 

         
    }


     public interface IStoreFrontBL
    {
        StoreFront AddStoreFront(StoreFront b_storefront);
        StoreFront UpdateStoreFront(StoreFront b_storefront);
        List<StoreFront> SearchStoreFront(string p_name);
        List<StoreFront> GetAllStoreFront();
        List<StoreFront> GetStoreFrontByStoreID(string b_storeID);

        List<Order> GetOrderByStoreFrontID(string b_storeID);
        List<Product> GetProductByStoreFrontID(string b_storeID);
        List<Inventory> GetInventoryByStoreFrontID(string b_storeID);
        
    }

    
     public interface ILineItemsBL
    {
        LineItem AddLineItems(LineItem b_lineitems);
        List<LineItem> GetAllLineItems();
    }

    public interface IInventoryBL
    {
        Inventory AddInventory(Inventory b_inventory);
        List<Inventory> SearchInventory(string p_name);
        List<Inventory> GetAllOfInventory();
        
        void ReplenishProduct(string b_inventoryID, string b_quantity);

        List<Inventory> GetInventoryByStoreID(string b_storeID);

        List<Inventory> GetAllProductByProductID(string b_productID);
    }


}