using hr.management.Data.Interfaces;
using System.Xml.Serialization;

namespace hr.management.Data.Services
{
    public class XmlService<T> : ISerializationService<T>
    {
        public IEnumerable<T> ReadData(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<T>();

            var xml = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(xml))
                return new List<T>();

            using var stringReader = new StringReader(xml);

            var serializer = new XmlSerializer(typeof(List<T>));

            return (List<T>?)serializer.Deserialize(stringReader) ?? new List<T>();
        }

        public void WriteData(string filePath, IEnumerable<T> items)
        {
            var serializer = new XmlSerializer(typeof(List<T>));

            using var stringWriter = new StringWriter();

            serializer.Serialize(stringWriter, items);

            File.WriteAllText(filePath, stringWriter.ToString());
        }
    }
}
