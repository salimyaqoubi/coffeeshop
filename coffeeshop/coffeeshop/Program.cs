using System;

class CoffeeShopProgram
{
    // Menu items and their prices
    static string[] menuItems = { "Americano", "Latte", "Cappuccino" };
    static double[] menuPrices = { 2.50, 3.00, 3.50 };

    static void Main()
    {
        Console.WriteLine("Welcome to the Coffee Shop!");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            DisplayMenu();

            Console.Write("Select an option (1-4, 0 to exit): ");
            int option = GetUserChoice(0, 4);

            switch (option)
            {
                case 1:
                    // Place order
                    var (selectedCoffee, size, hasSugar, hasMilk) = PlaceOrder();
                    double totalCost = CalculateCost(selectedCoffee, size, hasSugar, hasMilk);
                    DisplayOrderSummary(selectedCoffee, size, hasSugar, hasMilk, totalCost);
                    break;
                case 2:
                    // View menu
                    DisplayMenu();
                    break;
                case 3:
                    // View order history (not implemented in this basic version)
                    Console.WriteLine("Order history is not available in this version.");
                    break;
                case 4:
                    // View exit
                    Console.WriteLine("Thank you for visiting the Coffee Shop! Have a great day!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Function to display the coffee menu
    static void DisplayMenu()
    {
        for (int i = 0; i < menuItems.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {menuItems[i]} - ${menuPrices[i]:F2}");
        }
    }

    // Function to place an order and return order details
    static (string, string, bool, bool) PlaceOrder()
    {
        Console.Write("Select a coffee (1-3): ");
        int coffeeChoice = GetUserChoice(1, menuItems.Length);

        Console.WriteLine("Customizations:");
        Console.WriteLine("1. Small\n2. Medium\n3. Large");
        Console.Write("Select a size (1-3): ");
        int sizeChoice = GetUserChoice(1, 3);

        Console.Write("Do you want sugar? (yes/no): ");
        bool hasSugar = GetYesNoAnswer();

        Console.Write("Do you want milk? (yes/no): ");
        bool hasMilk = GetYesNoAnswer();

        return (menuItems[coffeeChoice - 1], GetSize(sizeChoice), hasSugar, hasMilk);
    }

    // Function to calculate the total cost based on customizations
    static double CalculateCost(string selectedCoffee, string size, bool hasSugar, bool hasMilk)
    {
        double basePrice = menuPrices[Array.IndexOf(menuItems, selectedCoffee)];
        double totalCost = basePrice;

        // Additional cost for size
        totalCost += (GetSizeMultiplier(size) - 1) * 0.50;

        // Additional cost for sugar
        if (hasSugar)
        {
            totalCost += 0.25;
        }

        // Additional cost for milk
        if (hasMilk)
        {
            totalCost += 0.50;
        }

        return totalCost;
    }

    // Function to display the order summary
    static void DisplayOrderSummary(string selectedCoffee, string size, bool hasSugar, bool hasMilk, double totalCost)
    {
        Console.WriteLine($"Your Order Summary: {selectedCoffee} ({size})" +
            $"{(hasSugar ? " with sugar" : "")}{(hasMilk ? " with milk" : "")}");
        Console.WriteLine($"Total Cost: ${totalCost:F2}");
        Console.WriteLine("Thank you for ordering!");
    }

    // Function to get a valid choice from the user
    static int GetUserChoice(int minValue, int maxValue)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < minValue || choice > maxValue)
        {
            Console.Write($"Invalid input. Please enter a number between {minValue} and {maxValue}: ");
        }
        return choice;
    }

    // Function to get a valid yes/no answer from the user
    static bool GetYesNoAnswer()
    {
        string answer;
        do
        {
            answer = Console.ReadLine().ToLower();
        } while (answer != "yes" && answer != "no");

        return answer == "yes";
    }

    // Function to get the size string based on user's choice
    static string GetSize(int sizeChoice)
    {
        switch (sizeChoice)
        {
            case 1:
                return "Small";
            case 2:
                return "Medium";
            case 3:
                return "Large";
            default:
                return "";
        }
    }

    // Function to get the multiplier for the selected size
    static int GetSizeMultiplier(string size)
    {
        switch (size.ToLower())
        {
            case "small":
                return 1;
            case "medium":
                return 2;
            case "large":
                return 3;
            default:
                return 0;
        }
    }
}
