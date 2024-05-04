using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Core.Domain.DTO.Ticket;

namespace Cinema.Core.Domain.DTO
{
    public interface ITicketService
    {
        public Task<bool> IsExistAsync(int id);
        public Task<TicketResponse> GetTicket(int id);
        public Task<List<TicketResponse>> GetTickets();
        public Task CreateAsync(TicketAddRequest ticket);
        public Task UpdateAsync(TicketUpdateRequest ticket);
        public Task DeleteAsync(TicketResponse ticket);
    }
}
