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
            Console.WriteLine("-e Ввод вида выходной кодировки файла (например, utf8 или windows1251)");
            Console.WriteLine("-q Завершение работы программы");
            Console.WriteLine("-----------------------------------------");
        }

        public static void EventMenu(string select)
        {
            ConverterFile.Notify += ConsoleMessage;
            if (select.Contains("-i"))
            {
                //ConverterFile.Notify += ConsoleMessage;
                Console.WriteLine("Введите путь к входному файлу json");
                string input = Console.ReadLine();
                ConverterFile.InputPath(input);                               
                Console.WriteLine("i end");
                Selection();

            }

            if (select.Contains("-o"))
            {
                //ConverterFile.Notify += ConsoleMessage;
                Console.WriteLine("Введите путь к к выходному файлу csv");
                Console.WriteLine("или пробел, если его необходимо создать");
                string output = Console.ReadLine();
                if (output == " ") ConverterFile.OutputPath();
                else ConverterFile.OutputPath(output);
                Console.WriteLine("o end");
                Selection();
            }

            if (select.Contains("-s"))
            {
                
                Selection();
            }

            if (select.Contains("-e"))
            {
                
                Selection();
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