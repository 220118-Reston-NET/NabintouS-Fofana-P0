namespace ShopModel
{
  public class Inventory
  {
    public string InventoryID { get; set; }
    public string StoreID { get; set; }
    public string StoreName { get; set; }
    public string ProductID { get; set; }
    public string ProductName { get; set; }
    public int ProductQuantity { get; set; }

    public Inventory()
    {
      InventoryID = "";
      StoreID = "";
      StoreName = "";
      ProductID = "";
      ProductName = "";
      ProductQuantity = 0;
    }

    public override string ToString()
    {
      return $"InventoryID: {InventoryID}\nStoreID: {StoreID}\nStoreName: {StoreName}\nProductID: {ProductID}\nProductName: {ProductName}\nProductQuantity: {ProductQuantity}";
    }
  }
}