namespace MedicalHelper.Models.UserProfile
{
    public class UserProfileViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DataOfBirth { get; set; }
        public string AvatarUrl { get; set; }
        public string Address { get; set; }
    }
}
