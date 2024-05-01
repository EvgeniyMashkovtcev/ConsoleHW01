using System;
using System.Collections;
using System.ComponentModel;


namespace ConsoleHW01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\User\\Desktop\\Test";
            string format = "txt";
            string text = "Hello";


            FindText(path, format, text);

            Console.ReadLine();

        }

        public static void FindText(string path, string format, string text)
        {
            bool textFound = false;

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Каталог не существует");
                return;
            }

            string[] files = Directory.GetFiles(path, $"*.{format}");

            Task[] tasks = new Task[files.Length];
            int index = 0;
            foreach (string file in files)
            {
                tasks[index] = new Task(() =>
                {
                    string fileContent = File.ReadAllText(file);

                    if (fileContent.Contains(text))
                    {
                        textFound = true;
                        Console.WriteLine($"'{text}' найден в файле: {file}");
                    }
                });
                tasks[index].Start();
                index++;
            }

            Task.WaitAll(tasks);

            if (!textFound)
            {
                Console.WriteLine($"'{text}' с форматом '{format}' в каталоге {path} НЕ найден");
            }

        }

    }

    
}

