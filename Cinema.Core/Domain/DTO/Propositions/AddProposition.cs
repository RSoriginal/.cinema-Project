using Cinema.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.DTO.Propositions
{
    public class AddProposition
    {

        public string Description { get; set; } = null!;
        public decimal Discount { get; set; }
        public int MovieId { get; set; }

        public Guid UserId { get; set; }
        public string Title { get; set; }

        public AddProposition(string description, decimal discount, int movieId)
        {
            Description = description;
            Discount = discount;
            MovieId = movieId;
        }

        public Proposition ToProposition()
        {
            var proposition = new Proposition()
            {

            Description = this.Description,
            Discount = this.Discount,
            MovieId = this.MovieId
        };


            
            return proposition;
        }
    }
}

