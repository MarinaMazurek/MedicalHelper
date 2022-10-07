using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Core.Abstractions
{
    public interface IRoleService
    {
        Task<string> GetRoleNameByIdAsync(Guid id);

        Task<Guid?> GetRoleIdByNameAsync(string name);
    }
}
