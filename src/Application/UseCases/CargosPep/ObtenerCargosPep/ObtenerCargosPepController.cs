using Application.Common.Result;
using Application.UseCases.CargosPep.ObtenerCargosPep;
using Microsoft.AspNetCore.Mvc;

namespace Application.UseCases.CargosPep.ObtenerParentescos;

[Route("api/v1/cargos-pep")]
[ApiController]
public class ObtenerCargosPepController(ObtenerCargosPepHandler handler) : ControllerBase
{
    private readonly ObtenerCargosPepHandler _handler = handler;

    [HttpGet]
    [EndpointSummary("Consulta catálogo de cargos PEP activos")]
    public Task<IActionResult> Get()
    {
        return _handler.Handle().ToActionResult();
    }
}

