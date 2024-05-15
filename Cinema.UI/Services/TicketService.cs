using Cinema.Core.Domain.DTO.Ticket;
using Cinema.Core.Domain.ServiceContracts;
using Cinema.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Core.ServiceContracts.DTO.Services
{
    public sealed class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;
        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TicketResponse> CreateTicketAsync(TicketAddRequest ticket)
        {
            var dbTicket = ticket.ToTicket();
            await _context.Tickets.AddAsync(dbTicket);
            await _context.SaveChangesAsync();
            return dbTicket.ToTicketResponse();
        }

        public async Task DeleteTicketAsync(int id)
        {
            _context.Tickets.Remove(await _context.Tickets.FindAsync(id) ?? throw new ArgumentException("Invalid ticket response"));
            await _context.SaveChangesAsync();
        }

        public async Task<TicketResponse> GetTicketAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id) ?? throw new ArgumentException($"Ticket not found. Id: {id}", nameof(id));
            return ticket.ToTicketResponse();
        }

        public async Task<ICollection<TicketResponse>> GetTicketsAsync()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return tickets.Select(ticket => ticket.ToTicketResponse()).ToList();
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _context.Tickets.AnyAsync(e=> e.Id == id); 
        }

        public async Task<TicketResponse> UpdateTicketAsync(TicketUpdateRequest ticket)
        {
            var dbTicket = ticket.ToTicket();
            _context.Tickets.Update(dbTicket);
            await _context.SaveChangesAsync();
            return dbTicket.ToTicketResponse();
        }
    }
}
