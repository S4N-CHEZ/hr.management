using hr.management.DataStoragesService.Models;
using hr.management.SerializationService.Interfaces;

namespace hr.management.DataStoragesService.Storages
{
    public class DepartmentStorage
    {
        private readonly ISerializationService<Department> _departmentFileRepo;
        private readonly string _filePath;

        public DepartmentStorage(ISerializationService<Department> departmentFileRepo, string filePath)
        {
            _departmentFileRepo = departmentFileRepo;
            _filePath = filePath;
        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentFileRepo.ReadFile(_filePath);
        }

        public Department? GetById(int id)
        {
            var all = _departmentFileRepo.ReadFile(_filePath);
            return all.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Department department)
        {
            var all = _departmentFileRepo.ReadFile(_filePath).ToList();
            var newId = all.Any() ? all.Max(e => e.Id) + 1 : 1;

            department.Id = newId;

            all.Add(department);

            _departmentFileRepo.WriteFile(_filePath, all);
        }
    }
}
