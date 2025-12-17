using Application.Common.Result;
using Contracts.Parentesco;
using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases.Parentescos.ObtenerParentescos;

public class ObtenerParentescosHandler(IParentescoRepository repository)
{
    private readonly IParentescoRepository _repository = repository;
    
    public async Task<Resultado<List<ParentescoResponse>>> Handle()
    {
        return await ObtenerParentescos()
            .Bind(MapearParentescos);

        async Task<Resultado<List<Parentesco>>> ObtenerParentescos()
        {
            return await _repository.ObtenerTodosAsync();
        }

        Resultado<List<ParentescoResponse>> MapearParentescos(List<Parentesco> paises)
        {
            return paises.Select(ObtenerParentescosMapper.Mapear).ToList();
        }
    }
}
