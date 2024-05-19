using Cinema.Core.Domain.DTO.Seance;
using Cinema.Core.Domain.Entities;
using Cinema.Core.Domain.ServiceContracts;
using Cinema.Core.ServiceContracts;
using Cinema.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Cinema.UI.Services
{
    public sealed class SeanceService : ISeanceService
    {
        private readonly ApplicationDbContext _context;
        public SeanceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SeanceResponse> CreateSeanceAsync(SeanceAddRequest seance)
        {
            var dbSeance = seance.ToSeance();
            await _context.seances.AddAsync(dbSeance);
            await _context.SaveChangesAsync();
            return dbSeance.ToSeanceResponse();
        }

        public async Task DeleteSeanceAsync(int id)
        {
            _context.seances.Remove(await _context.seances.FindAsync(id) ?? throw new ArgumentException("Invalid seance response"));
            await _context.SaveChangesAsync();
        }

        public async Task<SeanceResponse> GetSeanceAsync(int id)
        {
            var seance = await _context.seances.FindAsync(id) ?? throw new ArgumentException($"Seance not found. Id: {id}", nameof(id));
            return seance.ToSeanceResponse();
        }

        public async Task<ICollection<SeanceResponse>> GetSeancesAsync()
        {
            var seances = await _context.seances.ToListAsync();
            return seances.Select(seance => seance.ToSeanceResponse()).ToList();
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _context.seances.AnyAsync(e => e.Id == id);
        }

        public async Task<SeanceResponse> UpdateSeanceAsync(SeanceUpdateRequest seance)
        {
            var dbSeance = seance.ToSeance();
            _context.seances.Update(dbSeance);
            await _context.SaveChangesAsync();
            return dbSeance.ToSeanceResponse();
        }
    }
}
