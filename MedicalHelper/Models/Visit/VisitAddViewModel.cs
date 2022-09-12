using MedicalHelper.EfStaff.Model;

namespace MedicalHelper.Models.Visit
{
    public class VisitAddViewModel
    {
        public string SpecializationOfDoctor { get; set; }
        public string FullNameOfDoctor { get; set; }
        public DateTime DateTime { get; set; }  
    }
}
