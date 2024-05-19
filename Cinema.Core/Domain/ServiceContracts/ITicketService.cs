﻿using Cinema.Core.Domain.DTO.Ticket;

namespace Cinema.Core.Domain.ServiceContracts
{
    public interface ITicketService
    {
        public Task<bool> IsExistAsync(int id);
        public Task<bool> IsSeatNumberUniqueAsync(int seanceId, int seatNumber);
        public Task<TicketResponse> GetTicketAsync(int id);
        public Task<ICollection<TicketResponse>> GetTicketsAsync();
        public Task<TicketResponse> CreateTicketAsync(TicketAddRequest ticket);
        public Task<TicketResponse> UpdateTicketAsync(TicketUpdateRequest ticket);
        public Task DeleteTicketAsync(int id);
    }
}
