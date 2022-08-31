namespace MedicalHelper.EfStaff.Model
{
    public class Visit : BaseModel 
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
