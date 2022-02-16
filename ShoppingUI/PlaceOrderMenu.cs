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
            Console.WriteLine("[1] PLACE ORDER");
            Console.WriteLine("[0] Go back");
        }

        public MenuType UserChoice()
        {
            throw new NotImplementedException();
        }
    }
}