using Application.Common.Result;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Parentescos.ObtenerParentescos;

[Route("api/v1/parentescos")]
[ApiController]
public class ObtenerParentescosController(ObtenerParentescosHandler handler) : ControllerBase
{
    private readonly ObtenerParentescosHandler _handler = handler;

    [HttpGet]
    [EndpointSummary("Consulta catálogo activo de parentescos")]
    public Task<IActionResult> Get()
    {
        return _handler.Handle().ToActionResult();
    }
}

