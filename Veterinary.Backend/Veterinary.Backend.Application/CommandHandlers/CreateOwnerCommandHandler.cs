using FluentResults;
using MediatR;
using Veterinary.Backend.Application.CommandResponses;
using Veterinary.Backend.Application.Commands;
using Veterinary.Backend.Application.Response;
using Veterinary.Backend.Domain.AggregateRoots.Owner;
using Veterinary.Backend.Domain.IRepositories;
using Veterinary.Backend.Domain.ObjectValues;

namespace Veterinary.Backend.Application.CommandHandlers
{
    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, Response<CreateOwnerCommandResponse>>
    {
        private readonly IOwnerRepository _ownerRepository;

        public CreateOwnerCommandHandler(IOwnerRepository ownerRepository)
        {
            this._ownerRepository = ownerRepository;
        }

        public async Task<Response<CreateOwnerCommandResponse>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var errors = new Dictionary<string, string>();
                var id = Guid.NewGuid();
                var dateAddedToTheSystem = DateTime.UtcNow;
                Result<Name> name = Name.Create(request.FullName);
                Result<Email> email = Email.Create(request.Email);
                Result<PhoneNumber> phoneNumber = PhoneNumber.Create(request.PhoneNumber);
                Result<Identification> identification = Identification.Create(request.Identification);
                if(name.IsFailed)
                    errors.Add("Name", name.Errors.First().Message);
                if(email.IsFailed)
                    errors.Add("Email", email.Errors.First().Message);
                if(phoneNumber.IsFailed)
                    errors.Add("PhoneNumber", phoneNumber.Errors.First().Message);
                if(identification.IsFailed)
                    errors.Add("Identification", identification.Errors.First().Message);
                
                if (errors.Count > 0)
                {
                    return Response<CreateOwnerCommandResponse>.Create(null,errors); 
                }
                else
                {
                    Owner owner = new Owner(id,name.Value, email.Value, phoneNumber.Value, identification.Value, dateAddedToTheSystem);                   
                    var guid = await this._ownerRepository.Save(owner, cancellationToken);
                    return Response<CreateOwnerCommandResponse>.Create(new CreateOwnerCommandResponse(guid), errors); 
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}

