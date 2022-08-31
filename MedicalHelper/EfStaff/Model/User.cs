namespace MedicalHelper.EfStaff.Model
{
    public class User:BaseModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual List<Visit> Visits { get; set; }
        public virtual List<Vaccination> Vaccinations { get; set; }
    }
}
