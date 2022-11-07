using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Core.DataTransferObjects
{
    public class VisitDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SpecializationOfDoctor { get; set; }
        public Doctor Specialization { get; set; }
        public string FullNameOfDoctor { get; set; }
        public DateTime DateTime { get; set; }
        public List<Medicine> Medicines { get; set; }
        public Guid UserId { get; set; }
    }
}
