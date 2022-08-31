namespace MedicalHelper.EfStaff.Model
{
    public class Doctor: BaseModel
    {
        public string Name { get; set; }

        public virtual Visit Visit { get; set; }
        public virtual List<Medicine> Medicines { get; set; }

    }
}
