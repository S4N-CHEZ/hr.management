using hr.management.DataStoragesService.Models;
using hr.management.SerializationService.Interfaces;

namespace hr.management.DataStoragesService.Storages
{
    public class EmployeeStorage
    {
        private readonly ISerializationService<Employee> _employeeFileRepo;
        private readonly string _filePath;

        public EmployeeStorage(ISerializationService<Employee> employeeFileRepo, string filePath)
        {
            _employeeFileRepo = employeeFileRepo;
            _filePath = filePath;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeFileRepo.ReadFile(_filePath);
        }

        public Employee? GetById(int id)
        {
            var all = _employeeFileRepo.ReadFile(_filePath);
            return all.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee employee)
        {
            var all = _employeeFileRepo.ReadFile(_filePath).ToList();
            int newId = all.Any() ? all.Max(e => e.Id) + 1 : 1;
            employee.Id = newId;
            all.Add(employee);
            _employeeFileRepo.WriteFile(_filePath, all);
        }

    }
}
