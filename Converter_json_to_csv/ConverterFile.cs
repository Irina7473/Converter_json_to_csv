using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection;
using CsvHelper;

namespace Converter_json_to_csv    
{
    public static class ConverterFile
    {
        public static event Action<string> Notify;
        private static string _inputPath;  // I:\Test tasks\Converter_json_to_csv\Converter_json_to_csv\testConverter.json
        private static string _outputPath; // I:\Test tasks\Converter_json_to_csv\Converter_json_to_csv\testConverter1.csv

        /*
        private static bool FindPath(string path)
        {
            if (File.Exists(path)) return true;
            else
            {
                Notify?.Invoke($"{path} не найден.");
                return false;
            }
        }*/

        public static void InputPath(string path)
        {
            if (File.Exists(path))
            {
                _inputPath = path;
                Notify?.Invoke($"{path} найден.");
            }
            else Notify?.Invoke($"{path} не найден.");
                
        }
        public static void OutputPath(string path)
        {            
            if (File.Exists(path))
            {
                _outputPath = path;
                Notify?.Invoke($"{path} найден.");
            }
            else Notify?.Invoke($"{path} не найден.");
        }

        public static void OutputPath()
        {
            //string output = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "\\testConverter.csv");
            string output = @"I:\Test tasks\Converter_json_to_csv\Converter_json_to_csv" + "\\testConverter.csv";            
            File.Create(output);
            OutputPath (output);
        }

        public static Dictionary<string, string> inputJson()
        {
            string text = "";
            try
            {
                text = File.ReadAllText(_inputPath);
                Notify?.Invoke($"{_inputPath} прочитан.");
            }
            catch (FileNotFoundException)
            {
                Notify?.Invoke($"{_inputPath} не найден.");
                return null;
            }
            catch (IOException)
            {
                Notify?.Invoke($"При открытии файла {_inputPath} произошла ошибка ввода-вывода.");
                return null;
            }
            catch (NotSupportedException)
            {
                Notify?.Invoke($"Параметр {_inputPath} задан в недопустимом формате.");
                return null;
            }
            catch
            {
                Notify?.Invoke($"Неизвестная ошибка при чтении {_inputPath}");
                return null;
            }

            try
            {
                Dictionary<string, string> Json = JsonSerializer.Deserialize<Dictionary<string, string>>(text);


                Notify?.Invoke($"Данные из {_inputPath} загружены.");
                return Json;
            }
            catch (JsonException)
            {
                Notify?.Invoke($"Недопустимый JSON {_inputPath}");
                return null;
            }
            catch (NotSupportedException)
            {
                Notify?.Invoke("Совместимые объекты JsonConverter для TValue или его сериализуемых членов отсутствуют.");
                return null;
            }
            catch
            {
                Notify?.Invoke($"Неизвестная ошибка при сериализации {_inputPath}");
                return null;
            }
        }
    }
}

 