using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{ 
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterTripJson request)
    {
        try
        {
            var useCase = new RegisterTripUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (JourneyException ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ResourceErrorMessages.UnknownError);
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var useCase = new GetAllTripsUseCase();
        var result = useCase.Execute();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    // [ProducesResponseType(typeof(ResponseTripJson), 200)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var useCase = new GetTripByIdUseCase();
        var response = useCase.Execute(id);
        
        return Ok(response);
    }
}