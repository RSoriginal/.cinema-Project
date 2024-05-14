using Cinema.Core.Domain.DTO.Propositions;
using Cinema.Core.Domain.ServiceContracts;
using Cinema.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Cinema.Core.Domain.Sefvices
{
    internal class PropositionManager : IPropositionService_
    {
        readonly ApplicationDbContext _context;
        public PropositionManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PropositionResponse?> AddPropositionAsync(AddProposition? addProp)
        {
            if (addProp == null) throw new ArgumentNullException(nameof(addProp));

            if (addProp.UserId == Guid.Empty) throw new ArgumentException(nameof(addProp.UserId));
            if (addProp.MovieId < 0) throw new ArgumentException(nameof(addProp.MovieId));

            if ((await _context.CinemaUsers.Include(x => x.Propositions).Where(x => x.Id == addProp.UserId).FirstAsync())
                .Propositions.Where(x => x.MovieId == addProp.MovieId).Count() > 0)
            {
                return null;
            }

          

            var newProposition = await _context.propositions.AddAsync(new Entities.Proposition()
            {
                Description = addProp.Description,
                MovieId = addProp.MovieId,
                Discount = addProp.Discount
            });

            await _context.SaveChangesAsync();
            await newProposition.Reference(x => x.Movie).LoadAsync();
            await newProposition.Reference(x => x.Description).LoadAsync();
            return newProposition.Entity.ToPropositionResponse();
        }

        public async Task<bool> ClearPropositionAsync(Guid? UserID)
        {
            if (UserID == null) throw new ArgumentNullException(nameof(UserID));

            if ((await _context.propositions.FindAsync(UserID.ToString())) == null) throw new ArgumentException(nameof(UserID));

           
            return true;
        }

        public async Task<List<PropositionResponse>> GetAllPropositionssAsync(Guid? UserID)
        {
            if (UserID == null) throw new ArgumentNullException(nameof(UserID));

            if ((await _context.CinemaUsers.FindAsync(UserID.ToString())) == null) throw new ArgumentException(nameof(UserID));

            return (await _context.propositions.Include(x => x.Id).Where(x => x.UserId == UserID).ToListAsync()).Select(x => x.ToUserResponse()).ToList();
        }

        public async Task<PropositionResponse>? GetPropositionAsync(int propositionID)
        {
            if (propositionID < 0) throw new ArgumentException($"CartProductId {propositionID} can't be lower than 0");

            var Proposition = await _context.propositions.Include(x => x.Movie).ThenInclude(x => x.Description).Where(x => x.Id == propositionID).FirstAsync();
            if (Proposition == null) throw new ArgumentException(nameof(propositionID));

            return Proposition.ToCartPropositionResponse();
        }

        public async Task<bool> RemovePropositionAsync(PropositionResponse? proposition)
        {
            if (proposition == null) throw new ArgumentNullException(nameof(proposition));
            if (proposition.MovieId <0) throw new ArgumentException(nameof(proposition.MovieId));

            var dbProposition = await _context.propositions.Where(x => x.Id == proposition.Id).FirstOrDefaultAsync();
            if (dbProposition == null) return false;

            _context.propositions.Remove(dbProposition);
            await _context.SaveChangesAsync();
            return true;

        }
      

    }
}
