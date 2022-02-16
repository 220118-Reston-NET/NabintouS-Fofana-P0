namespace ShoppingModel
{
public class LineItem
{
    public string LineItemID{ get; set;}
    public string OrderID { get; set; }
    public string ProductID { get; set; }
    public string ProductName { get; set; }
    public string ProductQuantity { get; set; }

     public LineItem()
        {
            LineItemID = "";
            OrderID = "";
            ProductID = "";
            ProductName = "";
            ProductQuantity = "";
        }
        
        //ToString() method is the string version of your object
        public override string ToString()
        {
            return $"LineItemID: {LineItemID}\nOrderID: {OrderID}\nProductID: {ProductID}\nProductName: {ProductName}\nProductQuantity: {ProductQuantity}";
        }
        
}
}