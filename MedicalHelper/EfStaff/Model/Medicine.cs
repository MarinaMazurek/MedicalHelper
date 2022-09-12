namespace MedicalHelper.EfStaff.Model
{
    public class Medicine:BaseModel
    { 
        public string Name { get; set; }
        public double Cost { get; set; }       
        public double FullCost { get; set; }
        public int VisitId { get; set; }
        public Visit Visit { get; set; }
    }
}
