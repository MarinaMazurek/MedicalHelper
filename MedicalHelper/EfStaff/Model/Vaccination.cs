namespace MedicalHelper.EfStaff.Model
{
    public class Vaccination:BaseModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }  
    }
}
