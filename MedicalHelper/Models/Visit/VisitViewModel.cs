using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Models.Visit
{
    public class VisitViewModel
    {
        public Doctor Specialization { get; set; }
        public string FullNameOfDoctor { get; set; }
        public DateTime DateTime { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }
        //public virtual List<Medicine> Medicines { get; set; }
    }
}
