

string filename = "./cereal.csv";

Cereals? cereals=null;
try {
    cereals = Reader.ReadCerealFile(filename);
} 
catch (FileNotFoundException ex)
{
    Console.WriteLine($"File {filename} not found.",ex);
}

string? userInput = string.Empty;
while(userInput != "q" && userInput != "Q")
{
    CerealView.DisplayMenu();
    userInput = Console.ReadLine();
    if(string.IsNullOrEmpty(userInput))
        continue;
    if(userInput.Length == 1) {
        switch(userInput[0]) 
        {
            // List all cereals
            case '1':
                CerealView.ListCereals(cereals?.GetListOfCereals() ?? []);
                break;

            // List all cereals best served cold
            case '2':
                CerealView.ListCereals(cereals?.GetListOfCereals(true) ?? []);
                break;

            // List all cereals best served hot
            case '3':
                CerealView.ListCereals(cereals?.GetListOfCereals(false) ?? []);
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
                break;
        }
        CerealView.DisplayContinueMessage();
        string? anyKey = Console.ReadLine();
    }
}

