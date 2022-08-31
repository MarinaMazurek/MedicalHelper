namespace MedicalHelper.EfStaff.Model
{
    public class UserProfile: BaseModel
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DataOfBirth { get; set; }
        public string AvatarUrl { get; set; }
        public string Address { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
