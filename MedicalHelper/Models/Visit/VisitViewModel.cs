using MedicalHelper.DataBase.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalHelper.Models.Visit
{
    public class VisitViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Doctor Specialization { get; set; }
        public string FullNameOfDoctor { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<SelectListItem> Medicines { get; set; }
    }
}
