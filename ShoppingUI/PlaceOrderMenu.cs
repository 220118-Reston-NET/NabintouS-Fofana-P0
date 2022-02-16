using ShoppingBL;
using ShoppingModel;

namespace ShoppingUI
{
    public class PlaceOrderMenu : IMenu
    {
        private static Customer _newCustomer = new Customer();
        private static Order _newOrder = new Order();
        private static StoreFront _newStore = new StoreFront();
        private LineItem _newLineItem = new LineItem();

        //Dependency injection
        private ICustomerBL _customerBL;
        
        public PlaceOrderMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
           
        }

        public void Display()
        {
            Console.WriteLine("===Place Order Menu===");
            Console.WriteLine("Did you want to place an order?");
            Console.WriteLine("Enter Y for yes or N for no:");
        }

        public MenuType UserChoice()
        {
            throw new NotImplementedException();
        }
    }
}