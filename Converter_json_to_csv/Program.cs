using System;

namespace Converter_json_to_csv
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.Welcome();
            Menu.Selection();
            string select = "";
            do
            {
                select = Console.ReadLine();
                Menu.EventMenu(select);
            } while (!select.Contains("-g"));
        }
    }
}
