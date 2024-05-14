using Cinema.Core.Domain.DTO.Ticket;
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
        public Task<bool> IsExistAsync(int id);
        public Task<UserResponse> GetUserAsync(int id);
        public Task<ICollection<UserResponse>> GetUserAsync();
        public Task<UserResponse> CreateUserAsync(UserAddRequest user);
        public Task<UserResponse> UpdateUserAsync(UserUpdateRequest user);
        public Task DeleteUserAsync(int id);

        //old
        /*public Task<UserResponse> AddUser(UserAddRequest aDD);
        public Task<UserResponse>? GetUserAsync(int UserId);
        public Task<UserResponse> UpdateUserAsync(UserUpdateRequest update);
        public Task<bool> IsUserExistAsync(int id);
        public Task DeleteUserAsync(int id);*/
    }
}
