class CerealView
{
    public static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("1. List all cereals");
        Console.WriteLine("2. List cereals best served cold.");
        Console.WriteLine("3. List cereals best server warm");
        Console.WriteLine("4. List cereals by manufacturer");
        Console.WriteLine("   Enter name of cereal to show info about it");
        Console.WriteLine("Q. Quit");
    }

    public static void DisplayContinueMessage()
    {
        Console.WriteLine("Press the 'Any key' to go back to menu");
    }

    public static void DisplayCereals(IEnumerable<string> cereals)
    {
        Console.Clear();
        ListCereals(cereals);
        Console.WriteLine();
    }

    public static void ListCereals(IEnumerable<string> cereals)
    {
        foreach(var cereal in cereals)
            Console.WriteLine($"\t{cereal}");
    }

    public static void DisplayCerealsByManufacturer(IEnumerable<IGrouping<string,string>> cereals) 
    {
        foreach(var group in cereals)
        {
            Console.WriteLine(group.Key);
            ListCereals(group);
            Console.WriteLine();
        }
    }

    public static void DisplayCerealNotFound(string cerealName)
    {
        Console.WriteLine();
        Console.WriteLine($"Could not find {cerealName}");
        Console.WriteLine();
    }

    public static void DisplayCerealInfo(Cereal cereal)
    {
        
    }
}