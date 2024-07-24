using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Title = "FilterFeeder";
        try
        {
            Console.Write("\nВведите путь к файлу со СТАРЫМИ никами: ");
            var oldFilePath = Console.ReadLine().Replace("\"", "");
            Console.Write("Введите путь к файлу с НОВЫМИ никами: ");
            var newFilePath = Console.ReadLine().Replace("\"", "");
            string outputFilePath = "unique_logins.txt";

            HashSet<string> oldLogins = new HashSet<string>(File.ReadLines(oldFilePath));

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (string login in File.ReadLines(newFilePath))
                {
                    if (!oldLogins.Contains(login))
                    {
                        writer.WriteLine(login);
                    }
                }
            }

            Console.WriteLine("Уникальные логины записаны в файл unique_logins.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        Console.ReadKey();
    }
}