//using ShopDL;
namespace ShoppingModel
{
public class Order
{
    public string OrderID { get; set; }
    public string CustomerID { get; set; }
    public string StoreID { get; set; }
    public string StoreLocation{get; set;}
    public int TotalPrice { get; set; }
    
     public List<LineItem> _lineitems;
   
    public List<LineItem> LineItems
        {
            get { return _lineitems; }
            set 
            { 
                _lineitems = value;
            }
        }
   
    public Order()
        {
            OrderID = "";
            CustomerID = "";
            StoreID = "";
            StoreLocation = "";
            TotalPrice = 0;
            _lineitems = new List<LineItem>()
            {
                new LineItem()
            };
            
        }
        //ToString() method is the string version of your object
        public override string ToString()
        {
            return $"OrderID: {OrderID}\nCustomerID: {CustomerID}\nStoreID: {StoreID}\nStoreLocation: {StoreLocation}\nTotalPrice: {TotalPrice}";
        }

}
}
