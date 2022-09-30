using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.DataBase.Entities
{
    public class Visit : IBaseEntity
    {
        public Guid Id { get; set; }
        public string SpecializationOfDoctor { get; set; }
        public string FullNameOfDoctor { get; set; }
        public DateTime DateTime { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public virtual List<Medicine> Medicines { get; set; }
    }
}
