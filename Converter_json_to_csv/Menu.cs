using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter_json_to_csv
{    
    public static class Menu
    {        
        public static void Welcome()
        {
            Console.WriteLine("******** Converter_json_to_csv ********");
            Console.WriteLine(" Программа для конвертирования конвертирования json файла с массивом объектов в csv файл.\n");
        }
        public static void Selection()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Сделайте выбор действия");
            Console.WriteLine("-i Ввод пути к входному файлу json");
            Console.WriteLine("-o Ввод пути к выходному файлу csv");
            Console.WriteLine("-s Ввод вида разделителя полей csv(например, запятая или точка с запятой)");
            Console.WriteLine("-e Ввод вида выходной кодировки файла");
            Console.WriteLine("-x Запуск конвертации");
            Console.WriteLine("-q Завершение работы программы");
            Console.WriteLine("-----------------------------------------");
        }

        public static void EventMenu(string select)
        {
            ConverterFile.Notify = (message) => Console.WriteLine(message);
            if (select.Contains("-i"))
            {
                Console.WriteLine("Введите путь к входному файлу json");
                string input = Console.ReadLine();
                ConverterFile.InputPath(input); 
                Selection();

            }

            if (select.Contains("-o"))
            {
                Console.WriteLine("Введите путь к к выходному файлу csv или пробел, если его необходимо создать");
                string output = Console.ReadLine();
                if (output == " ") ConverterFile.OutputPath();
                else ConverterFile.OutputPath(output);
                Selection();
            }

            if (select.Contains("-s"))
            {
                Console.WriteLine("Введите вид разделителя полей csv(например: , или ;)");
                var x=Console.ReadKey();
                ConverterFile.delimiter = x.KeyChar;
                Console.WriteLine();
                Selection();
            }

            if (select.Contains("-e"))
            {
                Console.WriteLine("По умолчанию используется кодировки UTF8. Для выбора другой кодировки введите ее наименование");                
                ConverterFile.encoder = Encoding.GetEncoding(Console.ReadLine());
                Console.WriteLine();
                Selection();
            }

            if (select.Contains("-x"))
            {
                Console.WriteLine("Читаю json");
                List<Goods> json=ConverterFile.ReadJson();
                Console.WriteLine("Конвертирую из json в csv");
                ConverterFile.ConverterCSV(ConverterFile.delimiter, json);
                Console.WriteLine("Конвертация закончена");
                Console.Write("Нажмите любую клавишу для выхода");
                Console.ReadKey();
                Environment.Exit(0);
            }

            if (select.Contains("-q"))
            {
                Environment.Exit(0);
            }
        }

        private static void ConsoleMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}