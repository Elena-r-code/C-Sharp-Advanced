using Newtonsoft.Json;
using System;
using System.IO;
using Task1.Domain;


namespace Task1
{
    public class DataBase
    {
        private string _folderPath;
        private string _filePath;
        public DataBase()
        {
            _folderPath = @"..\..\..\Data";
            _filePath = _folderPath + $"\\Dogs.json";

            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
            Dog[] data = ReadFileContent();
            if(data == null)
            {
                Dog[] dogs = new Dog[0] { };
                WriteInFile(dogs);
            }
        }

        private Dog[] ReadFileContent()
        {           

            using (StreamReader streamReader = new StreamReader(_filePath))
            {
                string result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Dog[]>(result);
            }
            
        }

        private void WriteInFile(Dog[] dogs)
        {
            using (StreamWriter streamWriter = new StreamWriter(_filePath))
            {

                string jsonString = JsonConvert.SerializeObject(dogs);
                streamWriter.WriteLine(jsonString);
            }
        }

        public void Insert(Dog dog)
        {
            Dog[] data = ReadFileContent();
            Array.Resize(ref data, data.Length + 1);
            data[data.Length - 1] = dog;
            WriteInFile(data);
        }

        public void GetAll()
        {
            foreach (Dog dog in ReadFileContent())
            {
                Console.WriteLine(dog.PrintInfo());
            }
        }
    }
}
