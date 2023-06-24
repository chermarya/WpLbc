using System.Text.Json;

namespace Library
{
    public class FileWork
    {
        private string _folder = "../../../../Library/";

        public FileWork(string folder)
        {
            _folder += folder;
        }

        public string[] ReadField(string lvlname, out int x, out int y)
        {
            string path = _folder + @"\" + lvlname + ".txt";
            string[] allLines = File.ReadAllLines(path);
            y = allLines.Length;
            x = allLines[0].ToCharArray().Length;
            return allLines;
        }
    
        public string[] GetNames()
        {
            string[] allNames = Directory.GetFiles(_folder);
            string[] fileNames = new string[allNames.Length];
        
            for (byte i = 0; i < allNames.Length; i++)
            {
                string[] filePath = allNames[i].Split(Convert.ToChar(@"\"));
                string[] fileName = filePath[filePath.Length - 1].Split('.');
                fileNames[i] = fileName[0];
            }

            return fileNames;
        }

        public StreamWriter CreateFile(string name)
        {
            string path = _folder + name + ".txt";
            StreamWriter lvlFile = new StreamWriter(path);
        
            return lvlFile;
        }
    
        public void DeleteFile(string name)
        {
            string path = _folder + name + ".txt";
            File.Delete(path);
        }

        public void SaveField(string name, string[] field)
        {
            File.WriteAllLines(_folder + "/" + name + ".txt", field);
        }

        public void CreateGamer(GamerGeneral gamer)
        {
            string fileName;
            string jsonString;
            
            fileName = _folder + $"players/{gamer.Name}.json"; 
            jsonString = JsonSerializer.Serialize(gamer);
            File.WriteAllText(fileName, jsonString);

            Console.WriteLine(File.ReadAllText(fileName));
        }
    }
}