using System;
using System.Collections;
using System.ComponentModel;


namespace ConsoleHW01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            FindText("C:\\Users\\User\\Desktop\\Testt", "txt", "Hello");



            
        }

        public static bool FindText(string path, string format, string text)
        {
            bool textFound = false;

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Каталог не существует");
                return textFound;
            }

            string[] files = Directory.GetFiles(path, $"*.{format}");

            foreach (string file in files)
            {
                string fileContent = File.ReadAllText(file);

                if (fileContent.Contains(text))
                {
                    textFound = true;
                    Console.WriteLine($"'{text}' найден в файле: {file}");
                }
            }

            if (!textFound)
            {
                Console.WriteLine($"'{text}' с форматом '{format}' в каталоге {path} НЕ найден");
            }

            return textFound;
        }

    }

    
}

