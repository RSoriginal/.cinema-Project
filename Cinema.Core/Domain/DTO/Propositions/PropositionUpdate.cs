using Cinema.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.DTO.Propositions
{
    internal class PropositionUpdate
    {


        public PropositionUpdate(int id, string description, decimal discount, int movieId, Movie? Movie) 
        {
            Id = id;
            Description = description;
            Discount = discount;
            MovieId = movieId;
            movie = Movie;

        }
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal Discount { get; set; }
        public int MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public Movie? movie { get; set; }

        public string Title { get; set; }


        public Proposition ToProposition()
        {
            var prop = new Proposition()
            {
                Id = this.Id,
                Description = this.Description,
                Discount = this.Discount,
                MovieId = this.MovieId,
                movie = this.movie
            };

            return prop;
        }
    }
}
