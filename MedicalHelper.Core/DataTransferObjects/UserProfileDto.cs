namespace MedicalHelper.Core.DataTransferObjects
{
    public class UserProfileDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DataOfBirth { get; set; }
        public string Address { get; set; }

        public Guid UserId { get; set; }

    }
}
