namespace MedicalHelper.EfStaff.Model
{
    public class Medicine:BaseModel
    { 
        public string Name { get; set; }
        public int Cost { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
