﻿using Cinema.Core.Domain.DTO.Ticket;
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
        public Task<UserResponse> AddUser(UserAddRequest aDD);
        public Task<UserResponse>? GetUserAsync(int UserId);
        public Task<UserResponse> UpdateUserAsync(UserUpdateRequest update);
        /*public Task<bool> IsUserExistAsync(int id);*/
        public Task DeleteUserAsync(int id);
    }
}
