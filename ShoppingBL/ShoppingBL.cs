using ShoppingModel;
using ShoppingDL;

namespace ShoppingBL
{
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

             if (listOfCustomer.Count < 20)
             {
                 return _repo_c.AddCustomer(b_customer);
             }
             else
             {
                 throw new Exception("You cannot have more than 20 customers!");
             }
            return _repo_c.AddCustomer(b_customer);
        }
    }
}