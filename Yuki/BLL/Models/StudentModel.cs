using BLL.DLL;

namespace BLL.Models
{
    public class StudentModel
    {
        private Student? Student { get; set; }

        public int? Id { get => Student?.Id; }

        public string? Name { get => Student?.Name; }

        public string? Surname { get => Student?.Surname;}

        public DateTime? BirthDate { get => Student?.BirthDate; }

        public decimal? Gpa { get => Student?.Gpa; }

        public string? FullName { get => $"{Student?.Name} {Student?.Surname}"; }
    }
}
