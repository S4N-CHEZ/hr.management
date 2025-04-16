namespace hr.management.SerializationService.Interfaces
{
    public interface ISerializationService<T>
    {
        IEnumerable<T> ReadFile(string filePath);
        void WriteFile(string filePath, IEnumerable<T> items);
    }

}
