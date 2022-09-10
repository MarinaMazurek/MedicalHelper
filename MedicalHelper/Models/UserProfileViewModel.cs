namespace MedicalHelper.Models
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DataOfBirth { get; set; }
        public string AvatarUrl { get; set; }
        public string Address { get; set; }
    }
}
