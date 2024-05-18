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
        public Task<PropositionResponse?> AddPropositionAsync(PropositionAddRequest? addProp);
        public Task<PropositionResponse>? GetPropositionAsync(int propositionID);        
/*        public Task<List<PropositionResponse>> GetAllPropositionsAsync(Guid? UserID);*/
        public Task<bool> RemovePropositionAsync(PropositionResponse? proposition);
    }
}
