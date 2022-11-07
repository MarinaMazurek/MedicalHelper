namespace MedicalHelper.Models
{
    public class MedicineViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string SpecializationOfDoctor { get; set; }
        public DateTime VisitDateTime { get; set; }
        public Guid VisitId { get; set; }
    }
}
