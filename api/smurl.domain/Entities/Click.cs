using System;

namespace smurl.domain.Entities
{
    public class Click
    {
        public Guid Identifier { get; set; }
        public Guid LinkIdentifier { get; set; }
        public DateTime Clicked { get; set; }
    }
}