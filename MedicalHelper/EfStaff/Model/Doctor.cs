namespace MedicalHelper.EfStaff.Model
{
    public class Doctor: BaseModel
    {
        public string FullName { get; set; }
        public string Specialization { get; set; }
                
    }

    public enum Doctors
    {
        therapist,
        surgeon,
        dental,
        neurologist,
        ophthalmologist,
        otolaryngologist
    }       

}
