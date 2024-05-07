namespace Cinema.Core.Domain.DTO.Ticket
{
    public class TicketAddRequest
    {
        public TicketAddRequest(int seatNumber, decimal price, bool isAvailable, int seanceId, Guid userId)
        {
            SeatNumber = seatNumber;
            Price = price;
            IsAvailable = isAvailable;
            SeanceId = seanceId;
            UserId = userId;
        }

        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int SeanceId { get; set; }
        public Guid UserId { get; set; }

        public Entities.Ticket ToTicket()
        {
            return new Entities.Ticket()
            {
                SeatNumber = this.SeatNumber,
                Price = this.Price,
                IsAvailable = this.IsAvailable,
                SeanceId = this.SeanceId,
                UserId = this.UserId
            };
        }

    }
}
