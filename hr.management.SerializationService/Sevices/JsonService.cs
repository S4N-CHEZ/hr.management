using hr.management.SerializationService.Interfaces;
using System.Text.Json;

namespace hr.management.SerializationService.Sevices
{
    public class JsonService<T> : ISerializationService<T>
    {
        public IEnumerable<T> ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<T>();

            var json = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(json))
                return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public void WriteFile(string filePath, IEnumerable<T> items)
        {
            var json = JsonSerializer.Serialize(items, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, json);
        }
    }
}
