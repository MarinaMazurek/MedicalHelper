namespace MedicalHelper.EfStaff.Model
{
    public class Medicine:BaseModel
    { 
        public string NameOfMedicine { get; set; }
        public int Cost { get; set; }

        public int VisitId { get; set; }
        public Visit Visit { get; set; }
    }
}
