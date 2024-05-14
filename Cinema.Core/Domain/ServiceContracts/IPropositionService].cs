using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Core.Domain.DTO.Propositions;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.ServiceContracts
{
    public interface IPropositionService_
    {
       public Task<PropositionResponse?> AddPropositionAsync(AddProposition? addProp);
       public Task<PropositionResponse>? GetPropositionAsync(int propositionID);        
       public Task<List<PropositionResponse>> GetAllPropositionssAsync(Guid? UserID);
       public Task<bool> RemovePropositionAsync(PropositionResponse? proposition);
       public Task<bool> ClearPropositionAsync(Guid? UserID);
    }
}
