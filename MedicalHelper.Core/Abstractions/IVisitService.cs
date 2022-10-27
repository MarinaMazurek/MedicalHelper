using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Core.Abstractions
{
    public interface IVisitService
    {
        Task AddAsync(VisitDto visitDto);

        Task DeleteVisitByIdAsync(Guid id);

        Task<List<VisitDto>> GetAllVisitsAsync(Guid id);        
    }
}
