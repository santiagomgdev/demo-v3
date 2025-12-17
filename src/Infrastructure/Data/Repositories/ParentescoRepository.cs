using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Repositories;

public class ParentescoRepository(ApplicationDbContext context) : IParentescoRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Parentesco>> ObtenerTodosAsync()
    {
        return await _context.Parentescos.ToListAsync();
    }
}
