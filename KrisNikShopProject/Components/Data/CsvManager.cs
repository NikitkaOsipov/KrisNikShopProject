namespace KrisNikShopProject.Components
{
    public class CsvManager
    {

        // TODO fix hardcoded file path
        // const string FILE_NAME = "C:\\Users\\osipo\\BlazorProjects\\KrisNikShopProject\\KrisNikShopProject\\Components\\Data\\FileCsv.csv";

        // Get the path of the current directory
        
        // copilot example
        string currentDirectory = Directory.GetCurrentDirectory();

        // Construct the path to the file
         const string FILE_NAME = Path.Combine(currentDirectory, "FileCsv.txt");

        public static Person[] getFromFile()
        {
            Person[] persons = new Person[3];
            using (var reader = new StreamReader(FILE_NAME))
            {
                int i = 0;
                while(!reader.EndOfStream)
                { 
                    string[] line = reader.ReadLine().Split(",");
                    persons[i] = new Person
                    {
                        Id = int.Parse(line[0]),
                        Name = line[1],
                        Gender = line[2],
                        Country = line[3]
                    };
                    i++;
                }
            }
            return persons;
        }
    }
}
