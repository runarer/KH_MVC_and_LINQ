
class Cereals(Cereal[] cereals)
{
    private Cereal[] _cereals = cereals;

    public IEnumerable<string> GetListOfCereals(){
        return _cereals.Select( m => m.Name );
    }

    public IEnumerable<string> GetListOfCereals(bool cold){
        return _cereals.Where(m => m.Cold == cold).Select(m => m.Name);
    }

    public IEnumerable<IGrouping<string,string>> GetListOfCerealsByMFR()
    {
        return _cereals.GroupBy( cereal => cereal.MFR, cereal => cereal.Name);
    }
}
class Cereal(
        string name,
        string mfr,
        bool cold,
        int calories,
        int protein,
        int fat,
        int sodium,
        double fiber,
        double carbo,
        int sugars,
        int potass,
        int vitamins,
        int shelf,
        double weight,
        double cups,
        decimal rating)
{
    public string Name {get;} = name;
    public string MFR {get;} = mfr;
    public bool Cold {get;} = cold;
    public int Calories {get;} = calories;
    public int Protein {get;} = protein; 
    public int Fat {get;} = fat;
    public int Sodium {get;} = sodium; 
    public double Fiber {get;} = fiber; 
    public double Carbohydrates {get;} = carbo;
    public int Sugars {get;} = sugars;
    public int Potass {get;} = potass; 
    public int Vitamins {get;} = vitamins;
    public int Shelf {get;} = shelf; 
    public double Weight {get;} = weight;
    public double Cups {get;} = cups;
    public decimal Rating {get;} = rating;
}
