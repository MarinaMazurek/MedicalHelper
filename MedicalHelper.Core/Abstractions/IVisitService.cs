using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Core.Abstractions
{
    public interface IVisitService
    {
        Task<Visit> AddAsync(VisitDto visitDto);
        Task DeleteVisitByIdAsync(Guid id);
        Task<List<VisitDto>> GetAllVisitsAsync(Guid id);
        Task<VisitDto> GetVisitByIdAsync(Guid id);
    }
}
