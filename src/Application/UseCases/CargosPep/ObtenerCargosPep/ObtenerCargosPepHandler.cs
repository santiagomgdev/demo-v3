using Application.Common.Result;
using Application.UseCases.Parentescos.ObtenerParentescos;
using Contracts.CargosPep;
using Contracts.Parentesco;
using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases.CargosPep.ObtenerCargosPep;

public class ObtenerCargosPepHandler(ICargoPepRepository repository)
{
    private readonly ICargoPepRepository _repository = repository;
    
    public async Task<Resultado<List<CargoPepResponse>>> Handle()
    {
        return await ObtenerParentescos()
            .Bind(MapearParentescos);

        async Task<Resultado<List<CargoPep>>> ObtenerParentescos()
        {
            return await _repository.ObtenerTodosAsync();
        }

        Resultado<List<CargoPepResponse>> MapearParentescos(List<CargoPep> cargoPeps)
        {
            return cargoPeps.Select(ObtenerCargosPepMapper.Mapear).ToList();
        }
    }
}
