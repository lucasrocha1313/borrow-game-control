using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> UserExists(string userName);
    }
}
