using Cinema.Core.Domain.DTO.Propositions;
using Cinema.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.UI.Areas.Admin.ViewModels
{
    public class PropositionViewModel
    {

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal Discount { get; set; }
        public int MovieId { get; set; }
        public Guid UserId { get; set; }


        public PropositionAddRequest ToPropositionAddRequest()
        {
            return new PropositionAddRequest()
            {
                Description = this.Description,
                Discount = this.Discount,
                MovieId = this.MovieId,
                UserId = this.UserId
            };
        }

        public PropositionUpdateRequest ToPropositionUpdateRequest()
        {
            return new PropositionUpdateRequest()
            {
                Id = this.Id,
                Description = this.Description,
                Discount = this.Discount,
                MovieId = this.MovieId
            };
        }


    }

    public static class PropositionResponceExtensions
    {
        public static PropositionViewModel ToPropositionViewModel(this PropositionResponse response)
        {
            return new PropositionViewModel()
            {
                Id = response.Id,
                Description = response.Description,
                MovieId = response.MovieId,
                Discount = response.Discount

            };
        }
    }
}
