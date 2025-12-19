string filename = "./cereal.csv";

Cereals? cereals=null;
try {
    cereals = Reader.ReadCerealFile(filename);
} 
catch (FileNotFoundException ex)
{
    Console.WriteLine($"File {filename} not found.",ex);
}

string userInput = string.Empty;
while(userInput != "q" || userInput != "Q")
{
    CerealView.DisplayMenu();    
}

Console.WriteLine("FFF");
