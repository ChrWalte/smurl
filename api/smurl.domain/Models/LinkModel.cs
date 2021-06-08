using System;

namespace smurl.domain.Models
{
    public class LinkModel
    {
        public Guid Identifier { get; set; }
        public string Url { get; set; }
        public string Slug { get; set; }
    }
}