namespace MedicalHelper.Core.DataTransferObjects
{
    public class VaccinationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }

    }
}
