

string filename = "./cereal.csv";
Controller controller;

// Try to read file and then create the model and the controller.
try {
    Cereals cereals = Reader.ReadCerealFile(filename);
    controller = new(cereals);
} 
catch (FileNotFoundException ex)
{
    Console.WriteLine($"File {filename} not found.",ex);
    return 1;
}

controller.Run();
return 0;

class Controller(Cereals cereals)
{
    public Cereals cereals {get;} = cereals;
    
    public void Run()
    {
        string? userInput = string.Empty;
        while(userInput != "q" && userInput != "Q")
        {
            // Display a menu and wait for input
            CerealView.DisplayMenu();
            userInput = Console.ReadLine()?.Trim();
            if(string.IsNullOrEmpty(userInput))
                continue;

            // For simple input, menu choices
            if(userInput.Length == 1) {
                switch(userInput[0]) 
                {
                    // List all cereals
                    case '1':
                        CerealView.ListCereals(cereals.GetListOfAllCereals());
                        break;

                    // List all cereals best served cold
                    case '2':
                        CerealView.ListCereals(cereals.GetListOfHotOrColdCereals(true));
                        break;

                    // List all cereals best served hot
                    case '3':
                        CerealView.ListCereals(cereals.GetListOfHotOrColdCereals(false));
                        break;
                    
                    // List cereals by manufactures
                    case '4': 
                        CerealView.DisplayCerealsByManufacturer(cereals.GetListOfCerealsByManufacturer());
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
            _ = Console.ReadKey(); // Wait, then return to menu
        }
    }

}