using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Core.Domain.DTO.Propositions;
using System.Threading.Tasks;
using Cinema.Core.Domain.DTO.Seance;

namespace Cinema.Core.Domain.ServiceContracts
{
    public interface IPropositionService
    {
        public Task<bool> IsExistAsync(int id);
        public Task<PropositionResponse> GetPropositionAsync(int id);
        public Task<ICollection<PropositionResponse>> GetPropositionAsync();
        public Task<PropositionResponse> CreatePropositionAsync(PropositionAddRequest proposition);
        public Task<PropositionResponse> UpdatePropositionAsync(PropositionUpdateRequest proposition);
        public Task DeletePropositionAsync(int id);

        //old 
        /*public Task<PropositionResponse?> AddPropositionAsync(PropositionAddRequest? addProp);
        public Task<PropositionResponse>? GetPropositionAsync(int propositionID);        
        public Task<List<PropositionResponse>> GetAllPropositionssAsync(Guid? UserID);
        public Task<bool> RemovePropositionAsync(PropositionResponse? proposition);
        public Task<bool> ClearPropositionAsync(Guid? UserID);*/
    }
}
