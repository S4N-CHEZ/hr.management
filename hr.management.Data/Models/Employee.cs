namespace hr.management.Data.Models
{
    public class Employee
    {
        #region Свойства

        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;

        #endregion
    }
}
