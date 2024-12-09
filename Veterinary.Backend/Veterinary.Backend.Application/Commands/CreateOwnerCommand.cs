using FluentResults;
using MediatR;

namespace Veterinary.Backend.Application.Commands
{
    public record CreateOwnerCommand(
        string FullName,
        string Email,
        string PhoneNumber
    ):IRequest<Result>;
}