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
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual List<Visit> Visits { get; set; }
        public virtual List<Vaccination> Vaccinations { get; set; }
    }
}
