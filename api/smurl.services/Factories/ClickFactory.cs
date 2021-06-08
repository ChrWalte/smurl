using smurl.domain.Entities;
using System;

namespace smurl.services.Factories
{
    public static class ClickFactory
    {
        public static Click InitializeClick(Guid linkIdentifier)
        {
            var timeStamp = DateTime.Now;

            return new Click
            {
                Identifier = Guid.NewGuid(),
                LinkIdentifier = linkIdentifier,
                Clicked = timeStamp
            };
        }
    }
}