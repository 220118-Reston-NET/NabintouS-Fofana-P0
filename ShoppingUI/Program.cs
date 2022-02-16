global using Serilog;
using Microsoft.Extensions.Configuration;
//using ShopBL;
//using ShopDL;
using ShopUI;

/*
//Creating and configuring our logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/user.txt") //We configure our logger to save in this file
    .CreateLogger();

var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

string _connectionStrings = configuration.GetConnectionString("Reference2DBKey");

*/
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
            /*
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
            
        case MenuType.GetStoreProducts:
            Log.Information("Displaying AddOrder Menu to user");
            menu = new GetStoreProducts(new ProductBL(new SQLRepository_p(_connectionStrings)));
            break;
            
        case MenuType.GetProduct:
            Log.Information("Displaying AddOrder Menu to user");
            menu = new GetProduct(new ProductBL(new SQLRepository_p(_connectionStrings)));
            break;
            /*
        case MenuType.GetStoreProducts:
            Log.Information("Displaying AddOrder Menu to user");
            menu = new GetStoreProducts(new ProductBL(new SQLRepository_p(_connectionStrings)));
            break;
            
        
        case MenuType.AddStoreFront:
            Log.Information("Displaying StoreFront Menu to user");
            menu = new AddStoreFrontMenu(new StoreFrontBL(new SQLRepository_s(_connectionStrings)));
            break;   
            
        case MenuType.SearchCustomer:
            Log.Information("Displaying SearchCustomer Menu to user");
            menu = new SearchCustomerMenu(new CustomerBL(new SQLRepository_c(_connectionStrings)));
            break;
            /*
        case MenuType.AddLineItems:
            Log.Information("Displaying SearchCustomer Menu to user");
            menu = new AddLineItemsMenu(new OrderBL(new SQLRepository_o(_connectionStrings)));
            break;
           
        case MenuType.SearchProduct:
            Log.Information("Displaying SearchProduct Menu to user");
            menu = new SearchProductMenu(new ProductBL(new SQLRepository_p(_connectionStrings)));
            break;
            
        case MenuType.AddInventory:
            Log.Information("Displaying Inventory Menu to user");
            menu = new AddInventoryMenu(new InventoryBL(new SQLRepository_v(_connectionStrings)));
            break;
        case MenuType.ViewInventory:
            Log.Information("Displaying Inventory to user");
            menu = new ViewInventory(new InventoryBL(new SQLRepository_v(_connectionStrings)));
            break;
            
        case MenuType.PlaceOrderMenu:
            Log.Information("Displaying product quality to user");
            menu = new PlaceOrderMenu(new OrderBL(new SQLRepository_o(_connectionStrings)));
            break;
            */
            
        case MenuType.StoreCustomerMainMenu:
            Log.Information("Displaying customer mainMenu to user");
            menu = new StoreCustomerMainMenu();
            break;
            
        case MenuType.StoreManagerMainMenu:
            Log.Information("Displaying manager mainMenu to user");
            menu = new StoreManagerMainMenu();
            break;
            /*
        case MenuType.ReplenishInventory:
            Log.Information("Displaying the Replenish Inventory Menu");
            menu = new ReplenishinventoryMenu(new ProductBL(new SQLRepository_p(_connectionStrings)), new InventoryBL(new SQLRepository_v(_connectionStrings)));
            break;
            
        /*
        case MenuType.GetStoreOrder:
            Log.Information("Displaying Customer MainMenu to user");
            menu = new GetStoreOrder(new OrderBL(new Repository_o()));
            break;
            
        case MenuType.OrderHistory:
            Log.Information("Displaying customer order to user");
            menu = new GetCustomerOrder(new OrderBL(new SQLRepository_o(_connectionStrings)));
            break;
            */
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



   

