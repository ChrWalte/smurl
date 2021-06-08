using smurl.domain.Entities;
using System;

namespace smurl.services.Factories
{
    public static class LinkFactory
    {
        public static Link InitializeLink(string url, string slug)
        {
            var timeStamp = DateTime.Now;

            return new Link
            {
                Identifier = Guid.NewGuid(),
                Url = url,
                Slug = slug,
                Created = timeStamp,
                Updated = timeStamp
            };
        }
    }
}