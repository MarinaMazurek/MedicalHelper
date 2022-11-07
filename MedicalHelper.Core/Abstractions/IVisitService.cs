using MedicalHelper.Core.DataTransferObjects;

namespace MedicalHelper.Core.Abstractions
{
    public interface IVisitService
    {
        Task AddAsync(VisitDto visitDto);
        Task DeleteVisitByIdAsync(Guid id);
        Task<List<VisitDto>> GetAllVisitsAsync(Guid id);
        Task<VisitDto> GetVisitByIdAsync(Guid id);
    }
}
