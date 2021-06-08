using smurl.domain.Entities;
using smurl.domain.Models;
using smurl.services.Factories;
using smurl.services.Interfaces;
using System;
using System.Threading.Tasks;
using smurl.data.Interfaces;
using smurl.services.Shared;

namespace smurl.services.Services
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _linkRepository;
        private readonly IClickRepository _clickRepository;

        public LinkService(ILinkRepository linkRepository, IClickRepository clickRepository)
        {
            _linkRepository = linkRepository;
            _clickRepository = clickRepository;
        }

        public async Task<Response> GetLinkAsync(string slug)
        {
            var link = await _linkRepository.GetLinkAsync(slug);

            if (link == null)
                return ResponseFactory.InitializeResponse(
                    ResponseConstants.Failed, "No link found with given slug.", slug);

            var click = ClickFactory.InitializeClick(link.Identifier);
            await _clickRepository.CreateClickAsync(click);

            return ResponseFactory.InitializeResponse(
                ResponseConstants.Success, "Link retrieved by slug.", link);
        }

        public async Task<Response> CreateLinkAsync(LinkModel linkModel)
        {
            if (string.IsNullOrWhiteSpace(linkModel.Slug))
                linkModel.Slug = Utilities.RandomSlug(5);

            var checkExistingLink = await _linkRepository.GetLinkAsync(linkModel.Slug);

            if (checkExistingLink != null)
                return ResponseFactory.InitializeResponse(
                    ResponseConstants.Failed, "Slug already taken.", linkModel);

            var link = LinkFactory.InitializeLink(linkModel.Url, linkModel.Slug);
            await _linkRepository.CreateLinkAsync(link);

            return ResponseFactory.InitializeResponse(
                ResponseConstants.Success, "Link created successfully.", link);
        }

        public async Task<Response> UpdateLinkAsync(LinkModel linkModel)
        {
            return null;
        }

        public async Task<Response> DeleteLinkAsync(Guid identifier)
        {
            var link = await _linkRepository.DeleteLinkAsync(identifier);
            return ResponseFactory.InitializeResponse(
                ResponseConstants.Success, "Link deleted successfully.", link);
        }
    }
}