using MediatR;
using Microsoft.AspNetCore.Mvc;
using Veterinary.Backend.Application.Commands;
using Veterinary.Backend.WebAPI.Contracts;

namespace Veterinary.Backend.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OwnersController : ControllerBase
    {
        private readonly ISender _sender;

        public OwnersController(ISender sender)
        {
            this._sender = sender;
        }

        [HttpPost]
        public IActionResult CreateOwner([FromBody] CreateOwnerContract contract)
        {
            var command = new CreateOwnerCommand(contract.FullName, contract.Email, contract.PhoneNumber);
            var result = this._sender.Send(command);
            return Ok();
        }
    }
}

