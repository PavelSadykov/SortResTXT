




using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
namespace вопрос_1;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите строку с числами и буквами:");
        string input = Console.ReadLine();

        // Используем регулярное выражение для поиска чисел в строке
        string pattern = @"-?\d+"; // Шаблон для поиска чисел (может быть отрицательными)
        MatchCollection matches = Regex.Matches(input, pattern);

        // Создаем список для хранения чисел
        List<int> numbersList = new List<int>();

        // Извлекаем числа из найденных совпадений и добавляем в список
        foreach (Match match in matches)
        {
            if (int.TryParse(match.Value, out int number))
            {
                numbersList.Add(number);
            }
        }

        // Сортируем список чисел
        numbersList.Sort();

        // Выводим отсортированный результат на консоль
        Console.WriteLine("Отсортированный результат:");
        foreach (int number in numbersList)
        {
            Console.WriteLine(number);
        }

        // Записываем отсортированный результат в текстовый файл
        string outputFile = "sorted_numbers.txt";
        File.WriteAllLines(outputFile, numbersList.Select(n => n.ToString()));

        Console.WriteLine($"Результат сохранен в файле {outputFile}");
    }
}
