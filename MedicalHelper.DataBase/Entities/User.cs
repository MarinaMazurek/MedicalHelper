using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.DataBase.Entities
{
    public class User : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual List<Visit> Visits { get; set; }
        public virtual List<Vaccination> Vaccinations { get; set; }
    }
}
