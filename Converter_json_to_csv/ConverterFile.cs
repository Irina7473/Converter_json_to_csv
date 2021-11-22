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
        public static Action<string> Notify;
        private static string _inputPath;  // I:\Test tasks\Converter_json_to_csv\Converter_json_to_csv\testConverter.json                                           
        private static string _outputPath; // I:\Test tasks\Converter_json_to_csv\Converter_json_to_csv\testConverter.csv
        public static char delimiter = ';';
        public static Encoding encoder = Encoding.UTF8;

        public static void InputPath(string path)
        {
            if (File.Exists(path))
            {
                _inputPath = path;
                Notify?.Invoke($"{path} найден.");
            }
            else if (Path.IsPathFullyQualified(path))
            {
                _inputPath = Path.GetFullPath(path); //Не знаю какой каталог текущий
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
            else if (Path.IsPathFullyQualified(path))
            {
                _inputPath = Path.GetFullPath(path); //Не знаю какой каталог текущий
                Notify?.Invoke($"{path} найден.");
            }
                else Notify?.Invoke($"{path} не найден.");
        }

        public static void OutputPath()
        {
            string namePath=Path.GetFileNameWithoutExtension(_inputPath);
            string dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string output = $@"{dirPath}\{namePath}.csv";            
            File.Create(output).Close();
            OutputPath (output);
        }

        public static List<Goods> ReadJson()
        {           
            try
            {
                if (File.Exists(_inputPath))
                {
                    using var file = new FileStream(_inputPath, FileMode.Open);
                    List<Goods> Json = JsonSerializer.DeserializeAsync<List<Goods>>(file).Result;
                    Notify?.Invoke($"Данные из {_inputPath} загружены.");
                    return Json;
                }
                else
                {
                    Notify?.Invoke("json файл не существует");
                    return null;
                }
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

        public static void ConverterCSV(char delimiter, List<Goods> json)
        {
           
            if (File.Exists(_outputPath))
            {                
                using (StreamWriter sw = new StreamWriter(_outputPath, false, encoder))
                {
                    sw.WriteLine("Name" + delimiter + "Price" + delimiter + "Amount");
                    foreach (var line in json)
                    {
                        var text = line.Name + delimiter + line.Price + delimiter + line.Amount;
                        sw.WriteLine(text);
                    }
                }
            }
            else Notify?.Invoke("csv файл не существует");
        }
    }
} 