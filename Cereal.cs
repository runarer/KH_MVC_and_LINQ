

class CerealAisle
{
    Cereal[] Cereals {get;}

    public CerealAisle(string[] csvLines)
    {
        Cereals = [..csvLines.Select(l => new Cereal(l))];
    }

    public static string GetManufacturer(char c) => c switch
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

class Cereal
{
    string name {get;}
    string mfr {get;}
    bool cold {get;}
    int calories {get;} 
    int protein {get;} 
    int fat {get;} 
    int sodium {get;} 
    double fiber {get;} 
    double carbo {get;} 
    int sugars {get;} 
    int potass {get;} 
    int vitamins {get;} 
    int shelf {get;} 
    int weight {get;} 
    double cups {get;} 
    decimal rating {get;} 

    public Cereal(string csvLine)
    {
        string[] parsedValues = csvLine.Split(',',StringSplitOptions.RemoveEmptyEntries);
        name = parsedValues[0];
        mfr = CerealAisle.GetManufacturer(parsedValues[1][0]); 
        cold = parsedValues[2] == "C";
        calories = int.Parse(parsedValues[3]);
        protein = int.Parse(parsedValues[4]); 
        fat = int.Parse(parsedValues[5]); 
        sodium = int.Parse(parsedValues[6]); 
        fiber = Double.Parse(parsedValues[7]); 
        carbo = Double.Parse(parsedValues[8]); 
        sugars = int.Parse(parsedValues[9]); 
        potass = int.Parse(parsedValues[10]); 
        vitamins = int.Parse(parsedValues[11]); 
        shelf = int.Parse(parsedValues[12]); 
        weight = int.Parse(parsedValues[13]); 
        cups = Double.Parse(parsedValues[14]); 
        rating = Decimal.Parse(parsedValues[15]);
    }
}
