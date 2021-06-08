using smurl.domain.Entities;
using smurl.domain.Models;
using System;
using System.Threading.Tasks;

namespace smurl.services.Interfaces
{
    public interface ILinkService
    {
        Task<Response> GetLinkAsync(string slug);

        Task<Response> CreateLinkAsync(LinkModel linkModel);

        Task<Response> UpdateLinkAsync(LinkModel linkModel);

        Task<Response> DeleteLinkAsync(Guid identifier);
    }
}