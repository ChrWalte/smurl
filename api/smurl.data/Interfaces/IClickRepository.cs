using smurl.domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace smurl.data.Interfaces
{
    public interface IClickRepository
    {
        Task<List<Click>> GetClicksAsync(Guid linkIdentifier);

        Task<Click> CreateClickAsync(Click click);

        Task<Click> UpdateClickAsync(Click click);

        Task<Click> DeleteClickAsync(Guid identifier);
    }
}