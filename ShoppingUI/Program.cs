// See https://aka.ms/new-console-template for more information
global using Serilog;
using Microsoft.Extensions.Configuration;
using ShoppingBL;
using ShoppingDL;
using ShoppingUI;

//Creating and configuring our logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/user.txt") //We configure our logger to save in this file
    .CreateLogger();

var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

string _connectionStrings = configuration.GetConnectionString("Reference2DBKey");


bool repeat = true;
//IMenu menu = new MainMenu();
IMenu menu = new GeneralMenu();

while (repeat)
{
    Console.Clear();
    menu.Display();
    MenuType ans = menu.UserChoice();
    
    switch (ans)
    {
        
        case MenuType.GeneralMenu:
            Log.Information("Displaying general mainMenu to user");
            menu = new GeneralMenu();
            break;
        case MenuType.AddProduct:
            Log.Information("Displaying AddProduct Menu to user");
            menu = new AddProductMenu(new ProductBL(new SQLRepository_p(_connectionStrings)));
            break;
            
        case MenuType.AddCustomer:
            Log.Information("Displaying AddCustomer Menu to user");
            menu = new AddCustomerMenu(new CustomerBL(new SQLRepository_c(_connectionStrings)));
            break;
            
        case MenuType.AddOrder:
            Log.Information("Displaying AddOrder Menu to user");
            menu = new AddOrderMenu(new OrderBL(new SQLRepository_o(_connectionStrings)));
            break;
            
        case MenuType.GetAllProducts:
            Log.Information("Displaying AddOrder Menu to user");
            menu = new GetAllProductsMenu(new ProductBL(new SQLRepository_p(_connectionStrings)));
            break;
            
        case MenuType.GetOrderLineitems:
            Log.Information("Displaying AddOrder Menu to user");
            menu = new GetOrderLineItem(new OrderBL(new SQLRepository_o(_connectionStrings)));
            break;
            
        case MenuType.GetStoreFrontProducts:
            Log.Information("Displaying AddOrder Menu to user");
            menu = new GetStoreFrontProducts(new StoreFrontBL(new SQLRepository_s(_connectionStrings)));
            break;

        case MenuType.GetStoreFrontInventory:
            Log.Information("Displaying AddOrder Menu to user");
            menu = new GetStoreFrontInventory(new StoreFrontBL(new SQLRepository_s(_connectionStrings)));
            break;
            
        case MenuType.GetStoreFrontOrders:
            Log.Information("Displaying AddOrder Menu to user");
            menu = new GetStoreFrontOrders(new StoreFrontBL(new SQLRepository_s(_connectionStrings)));
            break;
            
        
        case MenuType.AddStoreFront:
            Log.Information("Displaying StoreFront Menu to user");
            menu = new AddStoreFrontMenu(new StoreFrontBL(new SQLRepository_s(_connectionStrings)));
            break;   
            
        case MenuType.SearchCustomer:
            Log.Information("Displaying SearchCustomer Menu to user");
            menu = new SearchCustomerMenu(new CustomerBL(new SQLRepository_c(_connectionStrings)));
            break;
            
        case MenuType.AddLineItemsMenu:
            Log.Information("Displaying SearchCustomer Menu to user");
            menu = new AddLineItemsMenu(new LineItemsBL(new SQLRepository_i(_connectionStrings)));
            break;
           
        case MenuType.SearchProduct:
            Log.Information("Displaying SearchProduct Menu to user");
            menu = new SearchProductMenu(new ProductBL(new SQLRepository_p(_connectionStrings)));
            break;
            
        case MenuType.AddInventory:
            Log.Information("Displaying Inventory Menu to user");
            menu = new AddInventoryMenu(new InventoryBL(new SQLRepository_v(_connectionStrings)));
            break;
        
        case MenuType.PlaceOrderMenu:
            Log.Information("Displaying product quality to user");
            menu = new PlaceOrderMenu(new CustomerBL(new SQLRepository_c(_connectionStrings)));
            break;
        
        case MenuType.CustomerMainMenu:
            Log.Information("Displaying customer mainMenu to user");
            menu = new StoreCustomerMainMenu();
            break;
            
        case MenuType.ManagerMainMenu:
            Log.Information("Displaying manager mainMenu to user");
            menu = new StoreManagerMainMenu();
            break;
            
        case MenuType.Replenishinventory:
            Log.Information("Displaying the Replenish Inventory Menu");
            menu = new Replenishinventory(new StoreFrontBL(new SQLRepository_s(_connectionStrings)));
            break;
            
        
        case MenuType.GetOrderLineItem:
            Log.Information("Displaying Customer MainMenu to user");
            menu = new GetOrderLineItem(new OrderBL(new SQLRepository_o(_connectionStrings)));
            break;
        
        case MenuType.OrderHistory:
            Log.Information("Displaying customer order to user");
            menu = new GetCustomerOrder(new CustomerBL(new SQLRepository_c(_connectionStrings)));
            break;
        case MenuType.Exit:
            Log.Information("Exiting application");
            Log.CloseAndFlush(); //To close our logger resource
            repeat = false;
            break;
        default:
            Console.WriteLine("Page does not exist!");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            break;
    }
}



   
