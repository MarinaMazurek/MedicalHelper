using MedicalHelper.Data.Abstractions.Repositories;
using MedicalHelper.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Data.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<UserProfile> UserProfiles { get; }
        IRepository<Visit> Visits { get; }
        IRepository<Medicine> Medicines { get; }
        IRepository<Vaccination> Vaccinations { get; }

        //IRepository<Role> Roles { get; }

        Task<int> Commit();
    }
}
