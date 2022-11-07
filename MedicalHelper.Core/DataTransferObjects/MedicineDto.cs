namespace MedicalHelper.Core.DataTransferObjects
{
    public class MedicineDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public Guid VisitId { get; set; }
    }
}
