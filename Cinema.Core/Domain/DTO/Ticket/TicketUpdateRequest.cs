
namespace Cinema.Core.Domain.DTO.Ticket
{
    public class TicketUpdateRequest
    {
        public TicketUpdateRequest() {}
        public TicketUpdateRequest(int seatNumber, decimal price, bool isAvailable, int seanceId, Guid userId) 
        {
            SeatNumber = seatNumber;
            Price = price;
            IsAvailable = isAvailable;
            SeanceId = seanceId;
            UserId = userId;
        }
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int SeanceId { get; set; }
        public Guid UserId { get; set; }
        public Entities.Ticket ToTicket()
        {
            return new Entities.Ticket()
            {
                Id = this.Id,
                SeatNumber = this.SeatNumber,
                Price = this.Price,
                IsAvailable = this.IsAvailable,
                SeanceId = this.SeanceId,
                UserId = this.UserId
            };
        }
    }
}
