using Cinema.Core.Domain.DTO.Seance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.ServiceContracts
{
    public interface ISeanceService
    {
        public Task<bool> IsExistAsync(int id);
        public Task<SeanceResponse> GetSeanceAsync(int id);
        public Task<ICollection<SeanceResponse>> GetSeancesAsync();
        public Task<SeanceResponse> CreateSeanceAsync(SeanceAddRequest movie);
        public Task<SeanceResponse> UpdateSeanceAsync(SeanceUpdateRequest movie);
        public Task DeleteSeanceAsync(int id);
    }
}
