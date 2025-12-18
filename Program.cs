
string[] lines;

try
{
    lines = File.ReadAllLines("./cereal.csv");
    Console.WriteLine(lines[0]);
} catch (FileNotFoundException ex)
{
    Console.WriteLine("File not found. This program requires 'cereal.csv' from 80-cereal from Kaggle.");
    Console.WriteLine(ex.Message);
    System.Environment.Exit(2);
} catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    System.Environment.Exit(1);
}
