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
    ICollection<Caravan> caravans = await utilities.LoadAllCaravans();
    Console.WriteLine($"There are {caravans.Count} Caravans awaiting you");
}

Console.WriteLine("See ya later Partner");
