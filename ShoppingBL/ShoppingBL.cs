using ShoppingModel;
using ShoppingDL;

namespace ShoppingBL
{
    public class ProductBL : IProductBL
    {
        private IRepository_p _repo_p;
        public ProductBL(IRepository_p p_repo_p)
        {
            _repo_p = p_repo_p;
        }

        public Product AddProduct(Product b_product)
        {
         List<Product> listOfProduct = _repo_p.GetAllProduct();
         return _repo_p.AddProduct(b_product);
            
        }
            // //return the filtered/another list
            

        public List<Product> GetAllProduct()
        {
           return _repo_p.GetAllProduct();
        }


        public List<Product> GetAllProductsFromStore(string b_storeID)
        {
            return _repo_p.GetAllProductsFromStore(b_storeID);
        }


        public List<StoreFront> GetAllStoreFrontsByProductID(string b_productID)
        {
            return _repo_p.GetAllStoreFrontsByProductID(b_productID);
        }

        public Product GetProductDetail(string b_productID)
        {
             List<Product> _listOfProduct = GetAllProduct();

            return _listOfProduct.Where(p => p.ProductID == b_productID).First();
        }


        public List<Product> SearchProduct(string p_name)
        {
             {
            List<Product> listOfProduct = _repo_p.GetAllProduct();


            // LINQ library
            return listOfProduct
                        .Where(product => product.ProductName.Contains(p_name)) //Where method is designed to filter a collection based on a condition
                        .ToList(); //ToList method just converts into a list collection that our method needs to return
        
           }
        }

        

        public List<Product> GetProductsByProductID(string b_productID)
        {
            return _repo_p.GetProductsByProductID(b_productID);
        }

        public Product UpdateProduct(Product b_product)
        {
            List<Product> listOfProduct = GetAllProduct()
                                       .Where(p => p.ProductID != b_product.ProductID).ToList();
            if (listOfProduct.Any(product => product.ProductName == b_product.ProductName))
            {
            throw new Exception("Already in the store database!");
            }
            return _repo_p.UpdateProduct(b_product);
        }

        
    }


    
    /// <summary>
    /// CUSTOMER BL
    /// </summary>
    public class CustomerBL: ICustomerBL
    {
        private IRepository_c _repo_c;
        public CustomerBL(IRepository_c p_repo_c)
        {
            _repo_c = p_repo_c;
        }

        public Customer AddCustomer(Customer b_customer)
        {
             //return _repo_c.AddCustomer(b_customer);
             //List<Customer> listOfCustomer = new List<Customer>();
             List<Customer> listOfCustomer = _repo_c.GetAllCustomer();

            return _repo_c.AddCustomer(b_customer);
        }

        public List<Customer> GetAllCustomer()
        {
            return _repo_c.GetAllCustomer();
        }

        public Customer GetCustomerInfoByID(string b_customerID)
        {
            Customer customerDetail = GetAllCustomer().Where(b => b.CustomerID == b_customerID).First();

            return customerDetail;
        }

        public List<Order> GetOrderByCustomerID(string b_customerID)
        {
            return _repo_c.GetOrderByCustomerID(b_customerID);
        }

        public Customer UpdateCustomer(Customer b_customer)
        {
            List<Customer> listOfCustomer = GetAllCustomer().Where(b => b.CustomerID != b_customer.CustomerID).ToList();
            if (listOfCustomer.Any(b => b.CustomerName == b_customer.CustomerName))
            {
            throw new Exception("Already in the store database!");
            }
            return _repo_c.UpdateCustomer(b_customer);
        }


        public List<Customer> SearchCustomerByName(string p_name)
        {
            {
            List<Customer> listOfCustomer = _repo_c.GetAllCustomer();

            // LINQ library
            return listOfCustomer
                        .Where(customer => customer.CustomerName.Contains(p_name)) //Where method is designed to filter a collection based on a condition
                        .ToList(); //ToList method just converts into a list collection that our method needs to return
         
            }
        }

        
    }


    /// <summary>
    /// ORDER BL
    /// </summary>
     public class OrderBL : IOrderBL
    {
        private IRepository_o _repo_o;
        public OrderBL(IRepository_o p_repo_o)
        {
            _repo_o = p_repo_o;
        }
  
        // Adding order
        public Order AddOrder(Order b_order)
        {
            
            List<Order> listOfOrder = _repo_o.GetAllOrder();
            if(listOfOrder.Count < 500)
            {
                return _repo_o.AddOrder(b_order);
            }
            else
            {
                throw new Exception("You cannot have more than 500 orders!");
            }
        
        }

        
        // Getting all orders
        public List<Order> GetAllOrder()
        {
            return _repo_o.GetAllOrder();
        }

        
        // Getting all orders by customer id
        public List<Order> GetAllOrderByCustomerID(string b_customerID)
        {
            List<Order> customerOrders = new List<Order>();

           customerOrders = _repo_o.GetAllOrder().Where(order => order.CustomerID == b_customerID).ToList();

           return customerOrders;
        }

        
        // Getting order by order id
        public Order GetOrderByOrderID(string b_orderID)
        {
            Order orderDetails = GetAllOrder().Where(b => b.OrderID == b_orderID).First();

            return orderDetails;
        }

        
        // Getting order by store id
        public List<Order> GetOrderByStoreID(string b_StoreID)
        {
            List<Order>ordersbystore = new List<Order>();

           ordersbystore = _repo_o.GetAllOrder().Where(order => order.StoreID == b_StoreID).ToList();

           return ordersbystore;
        }

        // Placing order
        public LineItem PlaceOrder(LineItem b_lineItems, int orderID)
        {
            throw new NotImplementedException();
        }

        
          public List<LineItem> GetLineItemByOrderID(string b_orderID)
        {
            return _repo_o.GetLineItemByOrderID(b_orderID);
        }
        
    }


    /// <summary>
    /// STOREFRONT BL
    /// </summary>
    public class StoreFrontBL : IStoreFrontBL
      {
        private IRepository_s _repo_s;
        public StoreFrontBL(IRepository_s p_repo_s)
        {
            _repo_s = p_repo_s;
        }
        
        public StoreFront AddStoreFront(StoreFront b_storefront)
        {
    
            //List<StoreFront> listOfStoreFront = new List<StoreFront>();
            List<StoreFront> listOfStoreFront = _repo_s.GetAllStoreFront();
            return _repo_s.AddStoreFront(b_storefront);
        }
/*
        public List<Product> GetAllProductsFromStore(string b_storeID)
        {
            return _repo_s.GetAllProductsFromStore(b_storeID);
        }
*/
        public List<StoreFront> GetAllStoreFront()
        {
            return _repo_s.GetAllStoreFront();
        }

        public List<Inventory> GetInventoryByStoreFrontID(string b_storeID)
        {
            return _repo_s.GetInventoryByStoreFrontID(b_storeID);
        }

        public List<Order> GetOrderByStoreFrontID(string b_storeID)
        {
            return _repo_s.GetOrderByStoreFrontID(b_storeID);
        }

        public List<Product> GetProductByStoreFrontID(string b_storeID)
        {
            return _repo_s.GetProductByStoreFrontID(b_storeID);
        }
        

        

        public List<StoreFront> GetStoreFrontByStoreID(string b_storeID)
        {
             return _repo_s.GetStoreFrontByStoreID(b_storeID);
        }

        public StoreFront GetStoreFrontInfoByID(string b_storeID)
        {
            StoreFront storeFrontDetails = GetAllStoreFront().Where(b => b.StoreID == b_storeID).First();

            return storeFrontDetails;
        }


        public List<StoreFront> SearchStoreFront(string p_name)
        {
            List<StoreFront> storeFront = _repo_s.GetAllStoreFront();


            // LINQ library
            return storeFront
                        .Where(storefront => storefront.StoreName.Contains(p_name)) //Where method is designed to filter a collection based on a condition
                        .ToList(); //ToList method just converts into a list collection that our method needs to return
        }


        public StoreFront UpdateStoreFront(StoreFront b_storefront)
        {
          List<StoreFront> listOfStore = GetAllStoreFront().Where(b => b.StoreID == b_storefront.StoreID).ToList();
         if (listOfStore.Any(b => b.StoreName == b_storefront.StoreName))
        {
        throw new Exception("Cannot save store front due to name of store front is already in the store database!");
        }
        return _repo_s.UpdateStoreFront(b_storefront);
        }

        List<StoreFront> IStoreFrontBL.GetStoreFrontByStoreID(string b_storeID)
        {
            return _repo_s.GetStoreFrontByStoreID(b_storeID);
        }
    }


     public class LineItemsBL : ILineItemsBL
    {
        private IRepository_i _repo_i;
        public LineItemsBL(IRepository_i p_repo_i)
        {
            _repo_i = p_repo_i;
        }
  
        // Adding order
        public LineItem AddLineItems(LineItem b_lineitems)
        {
            
            List<LineItem> listOfLineItems = _repo_i.GetAllLineItems();
    
            return _repo_i.AddLineItems(b_lineitems);
        }

        public List<LineItem> GetAllLineItems()
        {
           return _repo_i.GetAllLineItems();
        }

        
    }

     public class InventoryBL : IInventoryBL
    {
        private IRepository_v _repo_v;
        public InventoryBL(IRepository_v p_repo_v)
        {
            _repo_v = p_repo_v;
        }

        public Inventory AddInventory(Inventory b_inventory)
        {
            return _repo_v.AddInventory(b_inventory);
        }

        public List<Inventory> GetAllOfInventory()
        {
            return _repo_v.GetAllOfInventory();
        }


       public List<Inventory> SearchInventory(string p_name)
       {
             
            List<Inventory> listOfInventory = _repo_v.GetAllOfInventory();

            // LINQ library
            return listOfInventory
                        .Where(inventory => inventory.StoreName.Contains(p_name)) //Where method is designed to filter a collection based on a condition
                        .ToList(); //ToList method just converts into a list collection that our method needs to return

        }

/*
        public Inventory GetProductDetail(string b_productID, string b_storeID)
        {
            List<Inventory> listOfInventory = GetAllOfInventory(b_storeID);
            Inventory inventory = new Inventory();

            inventory = listOfInventory
                    .Where(product => product.ProductID == b_productID).First();

            return inventory;
        }

*/
/*
        public List<Inventory> GetAllProductsFromStore(string b_storeID)
        {
            return _repo_v.GetAllProductsFromStore(b_storeID);
        }

*/
        public void ReplenishProduct(string b_inventoryID, string b_quantity)
        {
            _repo_v.ReplenishProduct(b_inventoryID, b_quantity);
        }

        public List<Inventory> GetInventoryByStoreID(string b_storeID)
        {
             return _repo_v.GetInventoryByStoreID(b_storeID);
        }

        public List<Inventory> GetAllProductByProductID(string b_productID)
        {
            return _repo_v.GetInventoryByStoreID(b_productID);
        }

    }

}



    
    


