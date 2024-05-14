using Cinema.Core.Domain.DTO.User;
using Cinema.Core.Domain.ServiceContracts;
using Cinema.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Cinema.UI.Services
{
    public class UserManager : IUserService
    {
        readonly ApplicationDbContext _context;
        readonly IPropositionService_ _propService;
        public UserManager(ApplicationDbContext context, IPropositionService_ propositionService)
        {
            _context = context;
            _propService = propositionService;
        }
        public async Task<UserResponse> AddUser(UserADD aDD)
        {
            if (aDD == null) throw new ArgumentNullException(nameof(aDD));
            if (aDD.id == Guid.Empty) throw new ArgumentException(nameof(aDD.id));

          //  aDD.propositions = await _propService.GetAllPropositionssAsync(aDD.id);
          var dbUser = aDD.ToCinemaUser();
            await _context.CinemaUsers.AddAsync(dbUser);
            await _context.SaveChangesAsync();

            return dbUser.ToUserResponse();

        }

        public async Task DeleteUserAsync(int id)
        {
            _context.Tickets.Remove(await _context.CinemaUsers.FindAsync(id) ?? throw new ArgumentException("Invalid User response"));
            await _context.SaveChangesAsync();
        }

        public Task<UserResponse>? GetUserAsync(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> UpdateUserAsync(UserUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
