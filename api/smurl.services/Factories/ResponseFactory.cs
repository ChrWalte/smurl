using smurl.domain.Entities;

namespace smurl.services.Factories
{
    public static class ResponseFactory
    {
        public static Response InitializeResponse(string status, string message, object value)
            => new Response
            {
                Status = status,
                Message = message,
                Value = value
            };
    }
}
