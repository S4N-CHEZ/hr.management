namespace hr.management.Data.Interfaces
{
    public interface ISerializationService<T>
    {
        IEnumerable<T> ReadData(string filePath);
        void WriteData(string filePath, IEnumerable<T> items);
    }
}
