using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Data.Abstractions.Repositories
{
    public interface IVisitRepository : IRepository<Visit>
    {        
        Task<List<Visit>> GetAllVisitsByUserIdAsync(Guid id);
    }
}
