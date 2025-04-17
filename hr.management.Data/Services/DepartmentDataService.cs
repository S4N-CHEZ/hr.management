using hr.management.Data.Interfaces;
using hr.management.Data.Models;

namespace hr.management.Data.Services
{
    internal class DepartmentDataService
    {
        #region Поля

        private readonly ISerializationService<Department> _departmentFileRepo;
        private readonly string _filePath;//TODO: создать EnvService

        #endregion

        public DepartmentDataService(ISerializationService<Department> departmentFileRepo, string filePath)
        {
            _departmentFileRepo = departmentFileRepo;
            _filePath = filePath;
        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentFileRepo.ReadData(_filePath);
        }

        public Department? GetById(int id)
        {
            var all = _departmentFileRepo.ReadData(_filePath);
            return all.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Department department)
        {
            var all = _departmentFileRepo.ReadData(_filePath).ToList();
            var newId = all.Any() ? all.Max(e => e.Id) + 1 : 1;

            department.Id = newId;

            all.Add(department);

            _departmentFileRepo.WriteData(_filePath, all);
        }

        public void Delete(int id)
        {
            var all = _departmentFileRepo.ReadData(_filePath).ToList();
            var existing = all.FirstOrDefault(d => d.Id == id);
            if (existing != null)
            {
                all.Remove(existing);
                _departmentFileRepo.WriteData(_filePath, all);
            }
        }

        public void Update(Department department)
        {
            var all = _departmentFileRepo.ReadData(_filePath).ToList();
            var existing = all.FirstOrDefault(d => d.Id == department.Id);
            if (existing != null)
            {
                existing.Name = department.Name;
                _departmentFileRepo.WriteData(_filePath, all);
            }
        }
    }
}
