using System.Data.SqlClient;
using ShoppingModel;

namespace ShoppingDL
{
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
            Orders = GetOrderByCustomerID(reader.GetString(4))
          });
        }
      }

      return listOfCustomer;
      }

    }

}