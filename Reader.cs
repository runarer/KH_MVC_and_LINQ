// Reads a csv file and creates 

class Reader
{   
    // Try to read a csv file with cereal info, then parse it 
    public static Cereals ReadCerealFile(string filename)
    {
        Cereal[] cereals = [];
        try
        {
            string[] lines = File.ReadAllLines("./cereal.csv");
            cereals = [..lines[1..].Select(ParseCerealCSVLine)];
        } catch (FileNotFoundException ex)
        {
            throw new FileNotFoundException("This program requires a csv file from Kaggle, 80-cereal.",ex);
        }
        return new Cereals(cereals);
    }

    // Parses a line with info sepereated by , 
    // Use "System.Globalization.CultureInfo.InvariantCulture" to insure doubles uses .
    private static Cereal ParseCerealCSVLine(string line)
    {
        string[] parsedValues = line.Split(',',StringSplitOptions.RemoveEmptyEntries);
        string name = parsedValues[0];
        string mfr = Reader.GetManufacturer(parsedValues[1][0]); 
        bool cold = parsedValues[2] == "C";
        int calories = int.Parse(parsedValues[3]);
        int protein = int.Parse(parsedValues[4]); 
        int fat = int.Parse(parsedValues[5]); 
        int sodium = int.Parse(parsedValues[6]); 
        double fiber = Double.Parse(parsedValues[7], System.Globalization.CultureInfo.InvariantCulture); 
        double carbo = Double.Parse(parsedValues[8], System.Globalization.CultureInfo.InvariantCulture); 
        int sugars = int.Parse(parsedValues[9]); 
        int potass = int.Parse(parsedValues[10]); 
        int vitamins = int.Parse(parsedValues[11]); 
        int shelf = int.Parse(parsedValues[12]); 
        double weight = Double.Parse(parsedValues[13], System.Globalization.CultureInfo.InvariantCulture); 
        double cups = Double.Parse(parsedValues[14], System.Globalization.CultureInfo.InvariantCulture); 
        decimal rating = Decimal.Parse(parsedValues[15], System.Globalization.CultureInfo.InvariantCulture);
        return new Cereal(name,mfr,cold,calories,protein,fat,sodium,fiber,carbo,sugars,potass,vitamins,shelf,weight,cups,rating);    
    }
    
    // These are from the Kaggle page for the csv.
    private static string GetManufacturer(char c) => c switch
    {
        'A' => "American Home Food Products",
        'G' => "General Mills",
        'K' => "Kelloggs",
        'N' => "Nabisco",
        'P' => "Post",
        'Q' => "Quaker Oats",
        'R' => "Ralston Purina",
        _ => "Unknown"
    };
}