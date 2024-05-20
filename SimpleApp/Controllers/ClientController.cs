using Application.Clients.Commands.AddClient;
using Application.Clients.Queries.GetClients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApp.Controllers;

[Route("client")]
public class ClientController(IMediator mediator) : ControllerBase
{
    [HttpGet("clients")]
    [ProducesResponseType(typeof(IEnumerable<ClientModel>),200)]
    public async Task<IActionResult> GetAllClients()
    {
        return Ok(await mediator.Send(new GetClientsQuery())) ;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateClient(AddClientCommand command)
    {
        await mediator.Send(command);
        return Ok(new {status="Created"}) ;
    }
}