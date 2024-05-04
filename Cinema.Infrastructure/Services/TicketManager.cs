using Cinema.Core.Domain.DTO;
using Cinema.Core.Domain.DTO.Ticket;
using Cinema.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.ServiceContracts.DTO.Services
{
    public sealed class TicketManager : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public Task CreateAsync(TicketAddRequest ticket)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TicketResponse ticket)
        {
            throw new NotImplementedException();
        }

        public Task<TicketResponse> GetTicket(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TicketResponse>> GetTickets()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TicketUpdateRequest ticket)
        {
            throw new NotImplementedException();
        }
    }
}
