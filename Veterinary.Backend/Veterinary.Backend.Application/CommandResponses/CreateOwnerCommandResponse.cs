namespace Veterinary.Backend.Application.CommandResponses
{
    public record CreateOwnerCommandResponse(
        Guid? Id,
        Dictionary<string, string> Errors
    );
}