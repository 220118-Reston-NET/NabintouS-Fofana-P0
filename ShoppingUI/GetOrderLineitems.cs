using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class GetOrderLineItem : IMenu
    {
        private List<Order> _listOfOrder;
        private IOrderBL _orderBL;
        public GetOrderLineItem(IOrderBL p_orderBL)
        {
            _orderBL = p_orderBL;
            _listOfOrder = _orderBL.GetAllOrder();
        }
        public void Display()
        {
            foreach (var item in _listOfOrder)
            {
                Console.WriteLine("====================");
                Console.WriteLine(item);
            }
            Console.WriteLine("[1] Select order by Id");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();

            //Switch cases are just useful if you are doing a bunch of comparison
            switch (userInput)
            {
                case "0":
                    return MenuType.ManagerMainMenu;
                case "1":
                    Console.WriteLine("Enter OrderID:");

                    try
                    {
                        string orderID = Console.ReadLine();
                        List<LineItem> listOfLineItem = _orderBL.GetLineItemByOrderID(orderID);
                        foreach (var item in listOfLineItem)
                        {
                            Console.WriteLine("======================");
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();

                        return MenuType.ManagerMainMenu;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please input a valid response");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        return MenuType.GetOrderLineItem;
                    }
                    
                    return MenuType.GetOrderLineItem;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.GetOrderLineItem;
            }
        }
    }
}