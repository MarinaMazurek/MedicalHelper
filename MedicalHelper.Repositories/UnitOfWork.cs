using MedicalHelper.Data.Abstractions;
using MedicalHelper.Data.Abstractions.Repositories;
using MedicalHelper.DataBase;
using MedicalHelper.DataBase.Entities;

namespace MedicalHelper.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedicalHelperDbContext _dbContext;

        public IMedicineRepository Medicines { get; }
        public IUserRepository Users { get; }
        public IUserProfileRepository UserProfiles { get; }
        public IVaccinationRepository Vaccinations { get; }
        public IVisitRepository Visits { get; }
        public IRepository<Role> Roles { get; }

        public UnitOfWork(MedicalHelperDbContext dbContext,
            IMedicineRepository medicines,
            IUserRepository users,
            IUserProfileRepository userProfiles,
            IVaccinationRepository vaccinations,
            IVisitRepository visits,
            IRepository<Role> roles)
        {
            _dbContext = dbContext;
            Medicines = medicines;
            Users = users;
            UserProfiles = userProfiles;
            Vaccinations = vaccinations;
            Visits = visits;
            Roles = roles;
        }

        public async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
