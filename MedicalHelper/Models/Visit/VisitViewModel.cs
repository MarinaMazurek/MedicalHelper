using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Models.Visit
{
    public class VisitViewModel
    {
        public Guid Id { get; set; }
        public Doctor Specialization { get; set; }
        public string FullNameOfDoctor { get; set; }
        public DateTime DateTime { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }
        public List<Medicine> Medicines { get; set; }
    }
}
