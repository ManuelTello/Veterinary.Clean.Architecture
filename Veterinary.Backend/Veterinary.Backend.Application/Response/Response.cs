using System.Runtime.CompilerServices;

namespace Veterinary.Backend.Application.Response
{
    public sealed class Response<T>
    {
        public T? Data { get; init; }
        
        public Dictionary<string, string> Errors { get; init; }

        private Response(T? data, Dictionary<string, string> errors)
        {
            this.Data = data;
            this.Errors = errors;
        }

        public static Response<T> Create(T? data, Dictionary<string, string> errors)
        {
            var response = new Response<T>(data,errors);
            return response;
        }
    }
}

