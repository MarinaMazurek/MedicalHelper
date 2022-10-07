using MedicalHelper.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Core.Abstractions
{
    public interface IVaccinationService
    {
        Task<List<VaccinationDto>> GetAllVaccinationsAsync(Guid id);
        
    }
}
