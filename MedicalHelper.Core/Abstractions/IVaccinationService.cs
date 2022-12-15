using MedicalHelper.Core.DataTransferObjects;

namespace MedicalHelper.Core.Abstractions
{
    public interface IVaccinationService
    {
        Task AddAsync(VaccinationDto vaccinationDto);

        Task<List<VaccinationDto>> GetAllVaccinationsAsync(Guid id);

    }
}
