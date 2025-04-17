using hr.management.Data.Interfaces;
using hr.management.Data.Models;

namespace hr.management.Data.Services
{
    public class EmployeeDataService
    {
        private readonly ISerializationService<Employee> _employeeFileRepo;
        private readonly string _filePath;

        public EmployeeDataService(ISerializationService<Employee> employeeFileRepo, string filePath)
        {
            _employeeFileRepo = employeeFileRepo;
            _filePath = filePath;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeFileRepo.ReadData(_filePath);
        }

        public Employee? GetById(int id)
        {
            var all = _employeeFileRepo.ReadData(_filePath);
            return all.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee employee)
        {
            var all = _employeeFileRepo.ReadData(_filePath).ToList();
            int newId = all.Any() ? all.Max(e => e.Id) + 1 : 1;
            employee.Id = newId;
            all.Add(employee);
            _employeeFileRepo.WriteData(_filePath, all);
        }

        public void Delete(int id)
        {
            var all = _employeeFileRepo.ReadData(_filePath).ToList();
            var existing = all.FirstOrDefault(e => e.Id == id);
            if (existing != null)
            {
                all.Remove(existing);
                _employeeFileRepo.WriteData(_filePath, all);
            }
        }

        public void Update(Employee employee)
        {
            var all = _employeeFileRepo.ReadData(_filePath).ToList();
            var existing = all.FirstOrDefault(e => e.Id == employee.Id);
            if (existing != null)
            {
                existing.FirstName = employee.FirstName;
                existing.LastName = employee.LastName;
                existing.Position = employee.Position;
                existing.DepartmentId = employee.DepartmentId;

                _employeeFileRepo.WriteData(_filePath, all);
            }
        }

        public void MoveDepartment(int employeeId, int newDepartmentId)
        {
            var all = _employeeFileRepo.ReadData(_filePath).ToList();
            var existing = all.FirstOrDefault(e => e.Id == employeeId);
            if (existing != null)
            {
                existing.DepartmentId = newDepartmentId;
                _employeeFileRepo.WriteData(_filePath, all);
            }
        }

        public void ChangePosition(int employeeId, string newPosition)
        {
            var all = _employeeFileRepo.ReadData(_filePath).ToList();
            var existing = all.FirstOrDefault(e => e.Id == employeeId);
            if (existing != null)
            {
                existing.Position = newPosition;
                _employeeFileRepo.WriteData(_filePath, all);
            }
        }
    }
}
