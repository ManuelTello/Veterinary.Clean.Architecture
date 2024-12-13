using AutoMapper;
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

        private readonly IMapper _mapper;

        public OwnersController(ISender sender, IMapper mapper)
        {
            this._sender = sender;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] CreateOwnerContract contract)
        {
            try
            {
                var command = new CreateOwnerCommand(contract.FullName, contract.Email, contract.PhoneNumber, contract.Identification);
                var response = await this._sender.Send(command);
                if (response.Errors.Count > 0)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception exception)
            {
                return StatusCode(500);
            }
        }
    }
}