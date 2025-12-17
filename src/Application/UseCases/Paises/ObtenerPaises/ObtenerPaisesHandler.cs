using Application.Common.Result;
using Contracts.Paises;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Features.Paises.ObtenerPaises;

public class ObtenerPaisesHandler(IPaisRepository repository)
{
    private readonly IPaisRepository _repository = repository;
    
    public async Task<Resultado<List<PaisResponse>>> Handle()
    {
        return await ObtenerPaises()
            .Bind(MapearPaises);

        async Task<Resultado<List<Pais>>> ObtenerPaises()
        {
            return (await _repository.ObtenerTodosAsync()).ToList();
        }

        Resultado<List<PaisResponse>> MapearPaises(List<Pais> paises)
        {
            return paises.Select(ObtenerPaisesMapper.Mapear).ToList();
        }
    }
}
