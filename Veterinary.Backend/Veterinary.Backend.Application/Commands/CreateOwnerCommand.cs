using MediatR;
using Veterinary.Backend.Application.CommandResponses;
using Veterinary.Backend.Application.Response;

namespace Veterinary.Backend.Application.Commands
{
    public record CreateOwnerCommand(
        string FullName,
        string Email,
        string PhoneNumber,
        string Identification
    ) : IRequest<Response<CreateOwnerCommandResponse>>;
}