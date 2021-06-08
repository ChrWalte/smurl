using smurl.domain.Entities;
using System;
using System.Threading.Tasks;

namespace smurl.data.Interfaces
{
    public interface ILinkRepository
    {
        Task<Link> GetLinkAsync(string slug);

        Task<Link> CreateLinkAsync(Link link);

        Task<Link> UpdateLinkAsync(Link link);

        Task<Link> DeleteLinkAsync(Guid identifier);
    }
}