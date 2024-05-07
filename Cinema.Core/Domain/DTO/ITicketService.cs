using Cinema.Core.Domain.DTO.Ticket;

namespace Cinema.Core.Domain.DTO
{
    public interface ITicketService
    {
        public Task<bool> IsExistAsync(int id);
        public Task<TicketResponse> GetTicketAsync(int id);
        public Task<ICollection<TicketResponse>> GetTicketsAsync();
        public Task<TicketResponse> CreateTicketAsync(TicketAddRequest ticket);
        public Task<TicketResponse> UpdateTicketAsync(TicketUpdateRequest ticket);
        public Task DeleteTicketAsync(int id);
    }
}
