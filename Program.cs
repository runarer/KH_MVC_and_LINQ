

string filename = "./cereal.csv";

try {
    Cereals cereals = Reader.ReadCerealFile(filename);
    // CerealView cerealView = new();
    Controller controller = new(cereals);
    controller.Run();
} 
catch (FileNotFoundException ex)
{
    Console.WriteLine($"File {filename} not found.",ex);
}

class Controller(Cereals cereals)
{
    public Cereals cereals {get;} = cereals;
    // public CerealView cerealView {get;} = cerealView;
    
    public void Run()
    {
        string? userInput = string.Empty;
        while(userInput != "q" && userInput != "Q")
        {
            CerealView.DisplayMenu();
            userInput = Console.ReadLine();
            if(string.IsNullOrEmpty(userInput))
                continue;

            // For simple input
            if(userInput.Length == 1) {
                switch(userInput[0]) 
                {
                    // List all cereals
                    case '1':
                        CerealView.ListCereals(cereals.GetListOfCereals());
                        break;

                    // List all cereals best served cold
                    case '2':
                        CerealView.ListCereals(cereals.GetListOfCereals(true));
                        break;

                    // List all cereals best served hot
                    case '3':
                        CerealView.ListCereals(cereals.GetListOfCereals(false));
                        break;
                    
                    // List cereals by manufactures
                    case '4': 
                        CerealView.DisplayCerealsByManufacturer(cereals.GetListOfCerealsByMFR());
                        break;
                    case 'q':
                        return;
                    case 'Q':
                        return;            
                    default: 
                        continue;
                }
            } 

            // For longer input, cereal names
            else
            {
                Cereal? cerealInfo = cereals.GetCereal(userInput);
                if(cerealInfo == null)
                {
                    CerealView.DisplayCerealNotFound(userInput);
                } 
                else
                {
                    CerealView.DisplayCerealInfo(cerealInfo);
                }
            }
            CerealView.DisplayContinueMessage();
            _ = Console.ReadKey();
        }
    }

}