﻿using System.Text.Json;
using Cinema.Core.Domain.Entities;

namespace Cinema.Core.Domain.DTO.Ticket
{
    public class TicketResponse
    {
        public TicketResponse() { }
        
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int SeanceId { get; set; }
        public Guid? UserId { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != typeof(TicketResponse)) return false;

            TicketResponse? toCompare = obj as TicketResponse;
            if (toCompare == null) return false;

            return toCompare.Id == Id &&
                toCompare.SeanceId == SeanceId &&
                toCompare.UserId == UserId;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string? ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        public TicketUpdateRequest ToUpdateRequest()
        {
            return new TicketUpdateRequest(SeatNumber, Price, IsAvailable, SeanceId, UserId);
        }
    }
    public static class TicketExtensions
    {
        public static TicketResponse ToTicketResponse(this Entities.Ticket ticket)
        {
            return new TicketResponse
            {
                Id = ticket.Id,
                SeatNumber = ticket.SeatNumber,
                Price = ticket.Price,
                IsAvailable = ticket.IsAvailable,
                SeanceId = ticket.SeanceId,               
                UserId = ticket.UserId
            };
        }
    }
}
