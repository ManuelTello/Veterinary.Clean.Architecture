using FluentResults;
using MediatR;
using Veterinary.Backend.Application.Commands;
using Veterinary.Backend.Domain.AggregateRoots.Owner;
using Veterinary.Backend.Domain.IRepositories;
using Veterinary.Backend.Domain.ObjectValues;

namespace Veterinary.Backend.Application.CommandHandlers
{
    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, Result>
    {
        private readonly IOwnerRepository _ownerRepository;

        public CreateOwnerCommandHandler(IOwnerRepository ownerRepository)
        {
            this._ownerRepository = ownerRepository;
        }

        public async Task<Result> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                IList<string> errorsList = new List<string>();
                var id = Guid.NewGuid();
                if (Name.Create(request.FullName) is not Name newName)
                {

                }
                return Result.Ok();
            }
            catch (Exception exception)
            {
                return Result.Fail(exception.Message);
            }
        }
    }
}

