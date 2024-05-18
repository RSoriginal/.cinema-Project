using Cinema.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.DTO.Propositions
{
    public class PropositionUpdateRequest
    {
        public PropositionUpdateRequest()
        {
        }

        public PropositionUpdateRequest(int id, string description, decimal discount, int movieId) 
        {
            Id = id;
            Description = description;
            Discount = discount;
            MovieId = movieId;

        }
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal Discount { get; set; }
        public int MovieId { get; set; }


        public Proposition ToProposition()
        {
            return new Proposition()
            {
                Id = this.Id,
                Description = this.Description,
                Discount = this.Discount,
                MovieId = this.MovieId
            };
        }
    }
}
