using System.Data.SqlClient;
using ShoppingModel;

namespace ShoppingDL
{
    /// <summary>
    /// CUSTOMER SQL REPOSITORY
    /// </summary>

    public class SQLRepository_p : IRepository_p
    {

        private readonly string _connectionStrings;
        public SQLRepository_p(string p_connectionStrings)
        {
         _connectionStrings = p_connectionStrings;
        }
        // Adding product
        public Product AddProduct(Product b_product)
        {
            string sqlQuery = @"insert into Product values(@ProductID, @ProductName, @ProductDescription, @ProductQuantity, @ProductPrice,)";
 
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@productID", b_product.ProductID);
                command.Parameters.AddWithValue("@productName", b_product.ProductName);
                command.Parameters.AddWithValue("@productDescription", b_product.ProductDescription);
                command.Parameters.AddWithValue("@productQuantity", b_product.ProductQuantity);
                command.Parameters.AddWithValue("@productPrice", b_product.ProductPrice);

                //Executes the SQL statement
                command.ExecuteNonQuery();
            }
            return b_product;
        }


        // Getting all products
        public List<Product> GetAllProduct()
        {
            List<Product> listOfProduct = new List<Product>();

            string sqlQuery = @"SELECT * FROM Product";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                con.Open();

                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfProduct.Add(new Product(){
                        //Zero-based column index
                        ProductID = reader.GetString(0), //It will get column ProductID since that is the very first column of our select statement
                        ProductName = reader.GetString(1), //it will get the ProductName column since it is the second column of our select statement
                        ProductDescription = reader.GetString(2),
                        ProductQuantity = reader.GetInt32(3),
                        ProductPrice = reader.GetInt32(4),
                    });
                }
            }
        return listOfProduct;
       }

       // Getting all products from store

        public List<Product> GetAllProductsFromStore(String b_storeID)
        {
            List<Product> _listOfProducts = new List<Product>();
      string _sqlQuery = @"SELECT product.productID, product.productName, product.productPrice, product.productDescription, product.productQuantity FROM Products product, StoreFront storef, Inventory inv
                          WHERE product.productID = inv.productID 
                            AND storef.storeID = inv.storeID
                            AND storef.storeID = @storeID";

      using (SqlConnection con = new SqlConnection(_connectionStrings))
      {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);
        command.Parameters.AddWithValue("@storeID", b_storeID);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          _listOfProducts.Add(new Product()
          {
            ProductID = reader.GetString(0),
            ProductName = reader.GetString(1),
            ProductDescription = reader.GetString(2),
            ProductQuantity = reader.GetInt32(3),
            ProductPrice = reader.GetInt32(4),
          });
        }
      }

      return _listOfProducts;
        }



        // Getting all storefront by product id
    public List<StoreFront> GetAllStoreFrontsByProductID(String b_productID)
    {
        List<StoreFront> StoreFront = new List<StoreFront>();

      string _sqlQuery = @"SELECT storef.storeID, storef.storeName, storef.storeLocation FROM StoreFront storef, Inventory inv, Products product 
                          WHERE storef.storeID = inv.storeID 
                            AND inv.productID = product.productID
                            AND product.productID = @productID";

      using (SqlConnection con = new SqlConnection(_connectionStrings))
      {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);
        command.Parameters.AddWithValue("@productID", b_productID);

        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
          StoreFront.Add(new StoreFront()
          {
            StoreID = reader.GetString(0),
            StoreName = reader.GetString(1),
            StoreLocation = reader.GetString(2),
          });
        }
      }

       return StoreFront;
        }

        

        public Product GetProductDetailByProductId(String b_productID)
        {
           return GetAllProduct().Where(product => product.ProductID == b_productID).First();
        }


        // Updating product
        public Product UpdateProduct(Product b_product)
        {
        string _sqlQuery = @"UPDATE Product
                          SET productName = @productName, productPrice = @productPrice, productDescription = @productDescription, productQuantity = @productQuantity WHERE productID = @productID";

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        command.Parameters.AddWithValue("@productID", b_product.ProductID);
        command.Parameters.AddWithValue("@productName", b_product.ProductName);
        command.Parameters.AddWithValue("@productDescription", b_product.ProductDescription);
        command.Parameters.AddWithValue("@productQuantity", b_product.ProductQuantity);
        command.Parameters.AddWithValue("@productPrice", b_product.ProductPrice);

        command.ExecuteNonQuery();
      }

      return b_product;
        }

        List<Product> IRepository_p.GetProductsByProductID(string b_productID)
        {
            List<Product> listOfProducts = new List<Product>();

            string sqlQuery = @"select * from product
            where productID = @productID ";
           

            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@productID", b_productID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    listOfProducts.Add(new Product(){
                        //Zero-based column index
                        ProductID = reader.GetString(0), //It will get column ProductID since that is the very first column of our select statement
                        ProductName = reader.GetString(1), //it will get the ProductName column since it is the second column of our select statement
                        ProductDescription = reader.GetString(2),
                        ProductQuantity = reader.GetInt32(3),
                        ProductPrice = reader.GetInt32(4),
                    });

                }

            }

            return listOfProducts;
        }
    }  


     
    /// <summary>
    /// CUSTOMER SQL REPOSITORY
    /// </summary>

    public class SQLRepository_c : IRepository_c
    {

      private readonly string _connectionStrings;
        public SQLRepository_c(string p_connectionStrings)
        {
         _connectionStrings = p_connectionStrings;
        }
        // Adding customer
        public Customer AddCustomer(Customer b_customer)
        {
            string _sqlQuery = @"INSERT INTO Customer
                VALUES(@customerID, @customerName, @customerAddress, @customerEmail)";

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);
        command.Parameters.AddWithValue("@customerID", b_customer.CustomerID);
        command.Parameters.AddWithValue("@customerName", b_customer.CustomerName);
        command.Parameters.AddWithValue("@customerAddress", b_customer.CustomerAddress);
        command.Parameters.AddWithValue("@customerEmail", b_customer.CustomerEmail);
        command.ExecuteNonQuery();
        }

      return b_customer;
        }


       public List<Order> GetOrderByCustomerID(string b_customerID)
    {
            
            string sqlQuery = @"select o.orderID ,o.customerID , o.storeID , o.storeLocation , o.totalPrice from Customer c 
                            inner join customer_orders co on c.customerID = co.customerID 
                            inner join Orders o on o.orderID = co.orderID 
                            where c.customerID = @customerID";
            List<Order> listOfOrder = new List<Order>();
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@customerID", b_customerID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfOrder.Add(new Order(){
                        //Reader column is NOT based on table structure but based on what your select query statement is displaying
                        OrderID = reader.GetString(0),
                        CustomerID = reader.GetString(1),
                        StoreID = reader.GetString(2),
                        StoreLocation = reader.GetString(3),
                        TotalPrice = reader.GetInt32(4)
                    });
                }
            }
            return listOfOrder;
        }

        // Getting all customer
        public List<Customer> GetAllCustomer()
        {
        
        string _sqlQuery = @"SELECT * FROM Customer";
        List<Customer> listOfCustomer = new List<Customer>();

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          listOfCustomer.Add(new Customer()
          {
            CustomerID = reader.GetString(0),
            CustomerName = reader.GetString(1),
            CustomerAddress = reader.GetString(2),
            CustomerEmail = reader.GetString(3),
            Orders = GetOrderByCustomerID(reader.GetString(0))
          });
        }
      }

      return listOfCustomer;
      }

        // Updating customer
        public Customer UpdateCustomer(Customer b_customer)
        {
            string _sqlQuery = @"UPDATE Customer SET customerName = @customerName, customerAddress = @customerAddress, customerEmail = @customerEmail, WHERE customerID = @customerID";

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        command.Parameters.AddWithValue("@customerID", b_customer.CustomerID);
        command.Parameters.AddWithValue("@customerName", b_customer.CustomerName);
        command.Parameters.AddWithValue("@customerAddress", b_customer.CustomerAddress);
        command.Parameters.AddWithValue("@customerEmail", b_customer.CustomerEmail);
        
       
        command.ExecuteNonQuery();
      }

      return b_customer;
      }

    }



    /// <summary>
    /// ORDER SQL REPOSITORY
    /// </summary>

    public class SQLRepository_o : IRepository_o
    {

        private readonly string _connectionStrings;
        public SQLRepository_o(string p_connectionStrings)
        {
         _connectionStrings = p_connectionStrings;
        }

        private SQLRepository_v inventory_v;
        private SQLRepository_p _productP;


        public Order AddOrder(Order b_order)
        {
           string _sqlQuery = @"INSERT INTO Orders
                  VALUES(@orderID, @customerID, @storeID, @storeLocation, @TotalPrice)";

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        command.Parameters.AddWithValue("@orderID", b_order.OrderID);
        command.Parameters.AddWithValue("@customerID", b_order.CustomerID);
        command.Parameters.AddWithValue("@storeID", b_order.StoreID);
        command.Parameters.AddWithValue("@storeLocation", b_order.StoreLocation);
        command.Parameters.AddWithValue("@totalPrice", b_order.TotalPrice);

        command.ExecuteNonQuery();
        }

        return b_order;
        }



    public List<LineItem> GetAllLineItems()
    {
      string _sqlQuery = @"SELECT * FROM LineItems
                          WHERE orderID = @orderID";
      List<LineItem> listOfLineItems = new List<LineItem>();
     
      using (SqlConnection con = new SqlConnection(_connectionStrings))
      {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          listOfLineItems.Add(new LineItem()
          {
            ProductID = reader.GetString(0),
            OrderID = reader.GetString(3),
            ProductQuantity = reader.GetInt32(2),
            ProductName = reader.GetString(1)
          });
        }
      }

      return listOfLineItems;

    }


    public List<LineItem> GetLineItemsByOrderId(String b_orderID)
        {
            List<LineItem> listOfLineItem = new List<LineItem>();
            
            string sqlQuery = @"SELECT * FROM lineItems
                          WHERE orderID = @orderID";
            
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@orderID", b_orderID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfLineItem.Add(new LineItem(){
                        //Reader column is NOT based on table structure but based on what your select query statement is displaying
                        ProductID = reader.GetString(0),
                        OrderID = reader.GetString(3),
                        ProductQuantity = reader.GetInt32(2),
                        ProductName = reader.GetString(1)
                    });
                }
            }
            return listOfLineItem;
        }



        public List<Order> GetAllOrder()
        {
            string _sqlQuery = @"SELECT * FROM Orders";
        List<Order> listOfOrders = new List<Order>();

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          listOfOrders.Add(new Order()
          {
            OrderID = reader.GetString(0),
            CustomerID = reader.GetString(1),
            StoreID = reader.GetString(2),
            StoreLocation = reader.GetString(3),
            TotalPrice = reader.GetInt32(4),
            LineItems = GetLineItemsByOrderId(reader.GetString(0))
          });
        }
      }

      return listOfOrders;
      }

        public List<Order> GetOrderByStoreID(string b_StoreID)
        {
            string _sqlQuery = @"SELECT * FROM Orders
                          WHERE storeID = @storeID";
        List<Order> listOfOrder = new List<Order>();

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);
        command.Parameters.AddWithValue("@storeID", b_StoreID);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          listOfOrder.Add(new Order()
          {
            OrderID = reader.GetString(0),
            CustomerID = reader.GetString(1),
            StoreID = reader.GetString(2),
            StoreLocation = reader.GetString(3),
            TotalPrice = reader.GetInt32(4),
            //LineItems = GetLineItemsByOrderId(reader.GetInt32(0)),
          });
        }
      }

      return listOfOrder;
      }


        public List<LineItem> GetLineItemByOrderID(string b_orderID)
        {   
            string sqlQuery = @"select l.lineitemID ,l.orderID , l.productID , l.productName , l.productQuantity from LineItems l 
                            inner join orders_lineitems ol on o.orderID = ol.orderID 
                            inner join LineItems l on l.lineitemID = ol.lineitemID 
                            where o.orderID = @orderID";
            List<LineItem> listOfLineItem = new List<LineItem>();
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@orderID", b_orderID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfLineItem.Add(new LineItem(){
                        //Reader column is NOT based on table structure but based on what your select query statement is displaying
                        LineItemID = reader.GetString(0),
                        OrderID = reader.GetString(1),
                        ProductID = reader.GetString(2),
                        ProductName = reader.GetString(3),
                        ProductQuantity = reader.GetInt32(4)
                    });
                }
            }
            return listOfLineItem;
        
        }
    }

    
    /// <summary>
    /// STORE SQL REPOSITORY
    /// </summary>
    public class SQLRepository_s : IRepository_s
    {

      private readonly string _connectionStrings;
        public SQLRepository_s(string p_connectionStrings)
        {
         _connectionStrings = p_connectionStrings;
        }

      public StoreFront AddStoreFront(StoreFront b_storefront)
      {
            string _sqlQuery1 = @"INSERT INTO StoreFront
                        VALUES(@storeID, @storeName, @storeLocation)";


      using (SqlConnection con = new SqlConnection(_connectionStrings))
      {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery1, con);

        command.Parameters.AddWithValue("@storeID", b_storefront.StoreID);
        command.Parameters.AddWithValue("@storeName", b_storefront.StoreName);
        command.Parameters.AddWithValue("@storeLocation", b_storefront.StoreLocation);

        command.ExecuteNonQuery();
      }

        return b_storefront;
      }
/*
        public List<Product> GetAllProductsFromStore(string b_storeID)
        {
            List<Product> _listOfProducts = new List<Product>();
      string _sqlQuery = @"SELECT product.productID, product.productName, product.productPrice, product.productDescription FROM Products product, StoreFront storef, Inventory inv
                          WHERE product.productID = inv.productID 
                            AND storef.storeID = inv.storeID
                            AND storef.storeID = @storeID";

      using (SqlConnection con = new SqlConnection("Server=tcp:shopd.database.windows.net,1433;Initial Catalog=ShopDBDemo;Persist Security Info=False;User ID=shopAdmin;Password=Nanabinta@6;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
      {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);
        command.Parameters.AddWithValue("@storeID", b_storeID);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          _listOfProducts.Add(new Product()
          {
            ProductID = reader.GetString(0),
            ProductName = reader.GetString(1),
            ProductDescription = reader.GetString(2),
            ProductPrice = reader.GetInt32(3),
          });
        }
      }

      return _listOfProducts;
      }
*/
      public List<StoreFront> GetAllStoreFront()
      {
             
      string _sqlQuery1 = @"SELECT * FROM StoreFront";
      List<StoreFront> listOfStoreFront = new List<StoreFront>();

      using (SqlConnection con = new SqlConnection(_connectionStrings))
      {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery1, con);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          listOfStoreFront.Add(new StoreFront()
          {
            StoreID = reader.GetString(0),
            StoreName = reader.GetString(1),
            StoreLocation = reader.GetString(2),
            Orders = GetOrderByStoreFrontID(reader.GetString(0)),
            Products = GetProductByStoreFrontID(reader.GetString(0)),
          });
        }
        }
         return listOfStoreFront;
        }

        public List<StoreFront> GetStoreFrontByStoreID(string b_storeID)
        {
            List<StoreFront> listOfStoreFront = new List<StoreFront>();
            
            string sqlQuery = @"SELECT * FROM StoreFront
                          WHERE storeID = @storeID";
            
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeID", b_storeID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfStoreFront.Add(new StoreFront(){
                        //Reader column is NOT based on table structure but based on what your select query statement is displaying
                        StoreID = reader.GetString(0),
                        StoreName = reader.GetString(1),
                        StoreLocation = reader.GetString(2),
                    });
                }
            }
            return listOfStoreFront;
        }
        
        
        // Getting order by storefront ID
        public List<Order> GetOrderByStoreFrontID(string b_storefrontID)
        {
            
            string sqlQuery = @"select o.orderID ,o.customerID , o.storeID , o.storeLocation , o.totalPrice from StoreFront s 
                            inner join storeFront_orders so on s.storeID = so.storeID 
                            inner join Orders o on o.orderID = so.orderID 
                            where s.storeID = @storeID";
            List<Order> listOfOrder = new List<Order>();
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeID", b_storefrontID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfOrder.Add(new Order(){
                        //Reader column is NOT based on table structure but based on what your select query statement is displaying
                        OrderID = reader.GetString(0),
                        CustomerID = reader.GetString(1),
                        StoreID = reader.GetString(2),
                        StoreLocation = reader.GetString(3),
                        TotalPrice = reader.GetInt32(4)
                    });
                }
            }
            return listOfOrder;
        }

         // Getting product by storefront ID
        public List<Product> GetProductByStoreFrontID(string b_storefrontID)
        {
            
            string sqlQuery = @"select p.productID ,p.productName , p.productDescription , p.productQuantity , p.productPrice from StoreFront s
                            inner join storeFront_product sp on s.storeID = sp.storeID 
                            inner join Product p on p.productID = sp.productID 
                            where s.storeID = @storeID";
            List<Product> listOfProduct = new List<Product>();
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeID",  b_storefrontID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfProduct.Add(new Product(){
                        //Reader column is NOT based on table structure but based on what your select query statement is displaying
                        ProductID = reader.GetString(0), //It will get column ProductID since that is the very first column of our select statement
                        ProductName = reader.GetString(1), //it will get the ProductName column since it is the second column of our select statement
                        ProductDescription = reader.GetString(2),
                        ProductQuantity = reader.GetInt32(3),
                        ProductPrice = reader.GetInt32(4),
                    });
                }
            }
            return listOfProduct;
        }

         // Getting inventory by storefront ID
        public List<Inventory> GetInventoryByStoreFrontID(string b_storefrontID)
        {
            
            string sqlQuery = @"select i.inventoryID ,i.storeID ,i.storeName ,i.productID ,i.productName ,i.productQuantity from StoreFront s
                            inner join storeFront_inventory si on s.storeID = si.storeID 
                            inner join Inventory i on i.inventoryID = si.inventoryID 
                            where s.storeID = @storeID";
            List<Inventory> listOfInventory = new List<Inventory>();
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeID",  b_storefrontID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfInventory.Add(new Inventory(){
                        //Reader column is NOT based on table structure but based on what your select query statement is displaying
                        InventoryID = reader.GetString(0),
                        StoreID = reader.GetString(1),
                        StoreName = reader.GetString(2),
                        ProductID = reader.GetString(3),
                        ProductName = reader.GetString(4),
                        ProductQuantity = reader.GetInt32(5),
                    });
                }
            }
            return listOfInventory;
        }


        public StoreFront UpdateStoreFront(StoreFront b_storefront)
        {
            
            string _sqlQuery = @"UPDATE StoreFront 
                        SET storeName = @storeName,
                          storeLocation = @storeLocation
                        WHERE storeID = @storeID";

         using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);
        command.Parameters.AddWithValue("storeID", b_storefront.StoreID);
        command.Parameters.AddWithValue("@storeName", b_storefront.StoreName);
        command.Parameters.AddWithValue("@storeLocation", b_storefront.StoreLocation);
        

        command.ExecuteNonQuery();
      }

        return b_storefront;
        }
    }
    
   


   public class SQLRepository_i : IRepository_i
   {
        private readonly string _connectionStrings;
        public SQLRepository_i (string p_connectionStrings)
        {
         _connectionStrings = p_connectionStrings;
        }

        public LineItem AddLineItems(LineItem b_lineitems)
        {
            string sqlQuery = @"insert into Product values(@LineItemID, @OrderID, @ProductID, @ProductName, @ProductQuantity)";
 
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@lineitemID", b_lineitems.LineItemID);
                command.Parameters.AddWithValue("@orderID", b_lineitems.OrderID);
                command.Parameters.AddWithValue("@productID", b_lineitems.ProductID);
                command.Parameters.AddWithValue("@productName", b_lineitems.ProductName);
                command.Parameters.AddWithValue("@productQuantity", b_lineitems.ProductQuantity);


                //Executes the SQL statement
                command.ExecuteNonQuery();
            }

            return b_lineitems;
        }


         public List<LineItem> GetAllLineItems()
        {
            List<LineItem> listOfLineItems = new List<LineItem>();

            string sqlQuery = @"SELECT * FROM LineItems";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                con.Open();

                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfLineItems.Add(new LineItem(){
                        //Zero-based column index
                        LineItemID = reader.GetString(0), //It will get column ProductID since that is the very first column of our select statement
                        OrderID = reader.GetString(1), //it will get the ProductName column since it is the second column of our select statement
                        ProductID = reader.GetString(2),
                        ProductName = reader.GetString(3),
                        ProductQuantity = reader.GetInt32(4),
                    });
                }
            }
        return listOfLineItems;
       }


    }



    public class SQLRepository_v : IRepository_v
    {
    
     private readonly string _connectionStrings;
        public SQLRepository_v (string p_connectionStrings)
        {
         _connectionStrings = p_connectionStrings;
        }

        public Inventory AddInventory(Inventory b_inventory)
        {
             string _sqlQuery = @"INSERT INTO Inventory
                          VALUES(@inventoryID, @storeID, @storeName, @productID, @productName, @productQuantity)";

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        command.Parameters.AddWithValue("@inventoryID", b_inventory.InventoryID);
        command.Parameters.AddWithValue("@storeID", b_inventory.StoreID);
        command.Parameters.AddWithValue("@storeName", b_inventory.StoreName);
        command.Parameters.AddWithValue("@productID", b_inventory.ProductID);
        command.Parameters.AddWithValue("@productName", b_inventory.ProductName);
        command.Parameters.AddWithValue("@productQuantity", b_inventory.ProductQuantity);

        command.ExecuteNonQuery();
      }

      return b_inventory;
      }


        public List<Inventory> GetAllOfInventory()
        {
            List<Inventory> listOfInventory = new List<Inventory>();

        string _sqlQuery = @"SELECT * FROM Inventory";

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          listOfInventory.Add(new Inventory()
          {
            InventoryID = reader.GetString(0),
            StoreID = reader.GetString(1),
            StoreName = reader.GetString(2),
            ProductID = reader.GetString(3),
            ProductName = reader.GetString(4),
            ProductQuantity = reader.GetInt32(5),
          });
        }
        return listOfInventory;
        }
        }

        public List<Inventory> GetAllProductByProductID(string b_productID)
        {
             List<Inventory> listOfInventory = new List<Inventory>();

        string _sqlQuery = @"SELECT @productName FROM Inventory 
                           WHERE @productID = productID";

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          listOfInventory.Add(new Inventory()
          {
            //InventoryID = reader.GetString(0),
            //StoreID = reader.GetString(1),
            //StoreName = reader.GetString(2),
            ProductID = reader.GetString(3),
            ProductName = reader.GetString(4),
            //ProductQuantity = reader.GetInt32(5),
          });
        }
        return listOfInventory;
        }
        }

        public List<Inventory> GetInventoryByStoreID(string b_StoreID)
        {
            List<Inventory> listOfInventory = new List<Inventory>();
            
            string sqlQuery =  @"SELECT * FROM inventory
                          WHERE storeID = @storeID";
            
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeID", b_StoreID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfInventory.Add(new Inventory(){
                        //Reader column is NOT based on table structure but based on what your select query statement is displaying
                        InventoryID = reader.GetString(0),
                        StoreID = reader.GetString(1),
                        StoreName = reader.GetString(2),
                        ProductID = reader.GetString(3),
                        ProductName = reader.GetString(4),
                        ProductQuantity = reader.GetInt32(5)
                    });
                }
            }
          return listOfInventory;
      }

      
    
     public void ReplenishProduct(string b_inventory, string b_quantity)
    {
      string _sqlQuery = @"UPDATE Inventory
                          SET productQuantity = productQuantity + @productQuantity
                          WHERE inventoryID = @inventoryID";

      using (SqlConnection con = new SqlConnection(_connectionStrings))
      {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);
        command.Parameters.AddWithValue("@productQuantity", b_quantity);
        command.Parameters.AddWithValue("@inventoryID", b_inventory);

        command.ExecuteNonQuery();
      }
      }
    }
}



    
    

