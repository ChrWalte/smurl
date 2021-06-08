using System;

namespace smurl.domain.Entities
{
    public class Link
    {
        public Guid Identifier { get; set; }
        public string Url { get; set; }
        public string Slug { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}