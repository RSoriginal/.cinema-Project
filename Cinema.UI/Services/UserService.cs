using Cinema.Core.Domain.DTO.User;
using Cinema.Core.Domain.Entities;
using Cinema.Core.Domain.ServiceContracts;
using Cinema.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Cinema.UI.Services
{
    public sealed class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        readonly IPropositionService _propService;
        public UserService(ApplicationDbContext context, IPropositionService propositionService)
        {
            _context = context;
            _propService = propositionService;
        }
        public async Task<UserResponse> AddUser(UserAddRequest aDD)
        {
            if (aDD == null) throw new ArgumentNullException(nameof(aDD));
/*            if (aDD.id == Guid.Empty) throw new ArgumentException(nameof(aDD.id));*/

          //  aDD.propositions = await _propService.GetAllPropositionssAsync(aDD.id);
          var dbUser = aDD.ToCinemaUser();
            await _context.CinemaUsers.AddAsync(dbUser);
            await _context.SaveChangesAsync();

            return dbUser.ToUserResponse();

        }

        public async Task DeleteUserAsync(int id)
        {
            _context.CinemaUsers.Remove(await _context.CinemaUsers.FindAsync(id) ?? throw new ArgumentException("Invalid User response"));
            await _context.SaveChangesAsync();
        }

        public async Task<UserResponse>? GetUserAsync(int UserId)
        {
            var user = await _context.CinemaUsers.FindAsync(UserId) ?? throw new ArgumentException($"Ticket not found. Id: {UserId}", nameof(UserId));
            return user.ToUserResponse();
        }

/*        public async Task<bool> IsUserExistAsync(int id)
        {
            return await _context.CinemaUsers.AnyAsync(e => e.id == id);
        }*/

        public async Task<UserResponse> UpdateUserAsync(UserUpdateRequest update)
        {
            var dbUser = update.ToCinemaUser();
            _context.CinemaUsers.Update(dbUser);
            await _context.SaveChangesAsync();
            return dbUser.ToUserResponse();
        }
    }
}
