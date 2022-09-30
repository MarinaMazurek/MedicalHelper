using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Core.DataTransferObjects
{
    public class MedicineDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public double FullCost { get; set; }

        public Guid VisitId { get; set; }
        
    }
}
