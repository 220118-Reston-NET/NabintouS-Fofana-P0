namespace ShoppingModel
{
public class Product
{
    public string ProductID { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }

    public int ProductQuantity { get; set; }
    public int ProductPrice { get; set; }
    
        //Default constructor to add default values to the properties
        public Product()
        {
            ProductID = "";
            ProductName = "";
            ProductDescription = "";
            ProductQuantity = 0;
            ProductPrice = 0;
        }

        //ToString() method 
        public override string ToString()
        {
            return $"ProductID: {ProductID}\nProductName: {ProductName}\nProductDescription: {ProductDescription}\nProductPrice: {ProductPrice}\nProductQuantity: {ProductQuantity}";
        }
    }
}
