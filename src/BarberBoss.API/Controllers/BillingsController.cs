using BarberBoss.Application.UseCases.Billings.Create;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillingsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseBillingShortJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(
        [FromServices] ICreateBillingUseCase useCase,
        [FromBody] RequestBillingJson request)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }
}
