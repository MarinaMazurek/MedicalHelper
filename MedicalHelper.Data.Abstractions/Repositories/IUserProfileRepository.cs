using MedicalHelper.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Data.Abstractions.Repositories
{
    public interface IUserProfileRepository
    {
        Task<UserProfile?> GetUserProfileByUserIdAsync(Guid userId);
    }
}
