using Cinema.Core.Domain.DTO.User;
using Cinema.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.DTO.Propositions
{
    public class PropositionResponse
    {


        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal Discount { get; set; }
        public int MovieId { get; set; }

       
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != typeof(PropositionResponse)) return false;

            PropositionResponse? toCompare = obj as PropositionResponse;
            if (toCompare == null) return false;

            return toCompare.Id == Id &&
                toCompare.Description == Description &&
                toCompare.Discount == Discount;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string? ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public AddProposition ToAddRequest()
        {
            return new AddProposition(Description, Discount, MovieId);
        }


    }


    public static class PropositionExtentions
    {
        static PropositionResponse ToPropositionResponse(this Proposition proposition)
        {
            return new PropositionResponse
            {
                Id = proposition.Id,
                Description = proposition.Description,
                Discount = proposition.Discount,
                MovieId = proposition.MovieId
            };
        }
    }
}
