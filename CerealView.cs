
using System.Text;

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
        StringBuilder sb =  new StringBuilder();
        
        sb.Append($"{cereal.Name} is made by {cereal.MFR} and is best served {((cereal.Cold) ? "cold" :"hot" )}. \n");
        sb.Append($"One serving is {cereal.Cups} cups and weights {cereal.Weight} ounces, and contains {cereal.Calories} calories.\n");
        sb.Append("Nutrients:\n");
        
        if(cereal.Fat == 0)
            sb.Append("Unknown");
        else
            sb.Append(cereal.Fat);
        sb.Append(" grams fats\n");

        if(cereal.Sugars == 0)
            sb.Append("Unknown");
        else
            sb.Append(cereal.Sugars);
        sb.Append(" grams sugars\n");
        
        if(cereal.Fiber == 0)
            sb.Append("Unknown");
        else
            sb.Append(cereal.Fiber);
        sb.Append(" grams fibers\n");
        
        if(cereal.Sodium == 0)
            sb.Append("Unknown");
        else
            sb.Append(cereal.Sodium);
        sb.Append(" grams Salt\n");
        
        sb.Append($"\nThis cereal is rated {cereal.Rating}");
        Console.WriteLine(sb.ToString());
    }
}