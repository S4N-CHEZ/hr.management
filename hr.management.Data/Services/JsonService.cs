using hr.management.Data.Interfaces;
using System.Text.Json;

namespace hr.management.Data.Services
{
    public class JsonService<T> : ISerializationService<T>
    {
        public IEnumerable<T> ReadData(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<T>();

            var json = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(json))
                return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public void WriteData(string filePath, IEnumerable<T> items)
        {
            var json = JsonSerializer.Serialize(items, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, json);
        }
    }
}
