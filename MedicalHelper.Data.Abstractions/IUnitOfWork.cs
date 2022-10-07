﻿using MedicalHelper.Data.Abstractions.Repositories;
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
        IUserRepository Users { get; }
        IUserProfileRepository UserProfiles { get; }
        IVisitRepository Visits { get; }
        IMedicineRepository Medicines { get; }
        IVaccinationRepository Vaccinations { get; }
        IRepository<Role> Roles { get; }

        Task<int> Commit();
    }
}
