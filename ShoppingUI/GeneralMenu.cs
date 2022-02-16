namespace ShoppingUI
{
    public class GeneralMenu : IMenu
    {
        public void Display()
        {
            
            Console.WriteLine("===================================");
            Console.WriteLine("=== WELCOME TO THE ONLINE SHOP! ===");
            Console.WriteLine("===================================");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|   Hope you have a great day!    |");
            Console.WriteLine("|    Please select an option:     |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|    [2] Store Manager Menu       |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|       [1] Customer Menu         |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|           [0] Exit              |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("==================================");
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();
            //switch cases 
            switch (userInput)
            {
                case "0":
                    return MenuType.Exit;
                case "1":
                    return MenuType.CustomerMainMenu;
                case "2":
                    return MenuType.ManagerMainMenu;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.GeneralMenu;
            }
        }
        }
    }
