using OregonTrail.Models;

Console.WriteLine("******* Welcome to the Oregon Trail! *******");
Console.WriteLine("----------------------------------------------");
Console.WriteLine("** You are a Caravan Manager, your job is to **");
Console.WriteLine("** take inventory of Caravans passing through **");
Console.WriteLine("----------------------------------------------");
Console.WriteLine("Are you ready to see the Caravans today? (y/n)");
string work = Console.ReadLine();
Utilities utilities = new Utilities(new CaravanContext());
if (work == "y")
{
    List<Caravan> caravans = await utilities.LoadAllCaravans();
    Console.WriteLine($"There are {caravans.Count} Caravan(s) awaiting you");
    Console.WriteLine("Which Caravan would you like to inspect?");
    for (int i = 0; i < caravans.Count; i++)
    {
        Console.WriteLine($"{i + 1}. '{caravans[i].Name}'");
    }
    int index = int.Parse(Console.ReadLine());
    string userSelection;
    Console.WriteLine($"In Caravan '{caravans[index - 1].Name}', what would you like to do?");
    do
    {
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("1. Count how many wagons?");
        Console.WriteLine("2. Count of passangers in each wagon?");
        Console.WriteLine("3. List of Destinations");
        Console.WriteLine("4. Average Age of all passengers");
        Console.WriteLine("5. Average age of each wagon");
        Console.WriteLine("6. List of all name associated with their wagon");
        Console.WriteLine("9. Quit Application");
        Console.WriteLine("-----------------------------------------");

        userSelection = Console.ReadLine();
        int caravanId = caravans[index - 1].CaravanId;

        switch (userSelection)
        {
            case "1":
                utilities.CountOfWagons(caravanId);
                break;
            case "2":
                utilities.PassengersPerWagon(caravanId);
                break;
            case "3":
                utilities.UniqueDestinations(caravanId);
                break;
            case "4":
                utilities.AverageAgeOfAll(caravanId);
                break;
            case "5":
                utilities.AverageAgeEachWagon(caravanId);
                break;
            case "6":
                utilities.PassengerAndWagonNames(caravanId);
                break;
            case "9":
                break;
            default:
                Console.WriteLine("Invalid Selection. Please Try Again");
                break;
        }
    }
    while (userSelection != "9");
}

Console.WriteLine("See ya later Partner");
