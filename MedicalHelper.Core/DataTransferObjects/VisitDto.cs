using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Core.DataTransferObjects
{
    public class VisitDto
    {
        public Guid Id { get; set; }
        public string SpecializationOfDoctor { get; set; }
        public string FullNameOfDoctor { get; set; }
        public DateTime DateTime { get; set; }

        public Guid UserId { get; set; }
        
    }
}
