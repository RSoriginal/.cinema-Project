using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Core.Domain.Entities
{
    public class Proposition
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal Discount { get; set; }
        public int MovieId {  get; set; }
        [ForeignKey(nameof(MovieId))]
        public Movie? Movie { get; set; }
        public Guid? UserId { get; set; }
    }
}
