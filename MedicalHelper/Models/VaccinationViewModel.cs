using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MedicalHelper.Models
{
    public class VaccinationViewModel
    {
        public string Name { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }

}
