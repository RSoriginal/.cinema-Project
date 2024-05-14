using Cinema.Core.Domain.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.ServiceContracts
{
    public interface IUserService
    {    
        public Task<UserResponse> AddUser(UserADD aDD);
        public Task<UserResponse>? GetUserAsync(int UserId);
        public Task<UserResponse> UpdateUserAsync(UserUpdate update);
        public Task<bool> IsUserExistAsync(int id);
        public Task DeleteUserAsync(int id);

       

    }
}
