using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IParentescoRepository
    {
        Task<List<Parentesco>> ObtenerTodosAsync();
    }
}
