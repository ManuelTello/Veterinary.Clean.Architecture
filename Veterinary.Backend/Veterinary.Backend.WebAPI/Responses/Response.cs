namespace Veterinary.Backend.WebAPI.Responses
{
    public record Response
    {
        public string Message { get; init; }

        public Dictionary<string, string> Errors { get; init; }

        private Response(string message, Dictionary<string, string> errors)
        {
            this.Message = message;
            this.Errors = errors;
        }

        public static Response Create(string message, Dictionary<string, string> errors)
        {
            var response = new Response( message, errors);
            return response;
        }
    }
}