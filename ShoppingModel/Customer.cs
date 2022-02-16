namespace ShoppingModel
{
public class Customer
{
    public string CustomerID { get; set;}
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerEmail { get; set; }
 
    private List<Order> _orders { get; set; }
    public List<Order> Orders
        {
            get { return _orders; }
            set 
            { 
                _orders = value;
            }
        }
    
        //Default constructor to add default values to the properties
        public Customer()
        {
            CustomerID = "";
            CustomerName = "";
            CustomerAddress = "";
            CustomerEmail = "";
           
            
             _orders = new List<Order>()
            {
                new Order()
            };
            
        }

        //ToString() method is the string version of your object
        public override string ToString()
        {
            return $"CustomerID: {CustomerID}\nCustomerName: {CustomerName}\nCustomerAddress: {CustomerAddress}\nCustomerEmail: {CustomerEmail}";
        }

    
}
}
