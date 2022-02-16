using ShoppingModel;

namespace ShoppingDL
{
public interface IRepository_c
    {
        Customer AddCustomer(Customer b_customer);
        List<Customer> GetAllCustomer();  
        List<Order> GetOrderByCustomerID(string b_customerID);
        
    }
}