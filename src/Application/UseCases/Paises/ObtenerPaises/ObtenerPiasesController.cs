using Application.Common.Result;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Paises.ObtenerPaises;

[Route("api/v1/paises")]
[ApiController]
public class ObtenerPiasesController(ObtenerPaisesHandler handler) : ControllerBase
{
    private readonly ObtenerPaisesHandler _handler = handler;

    [HttpGet]
    public Task<IActionResult> Get()
    {
        return _handler.Handle().ToActionResult();
    }
}

