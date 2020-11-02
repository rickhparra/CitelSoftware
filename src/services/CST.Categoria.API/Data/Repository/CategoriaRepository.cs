using CST.Categoria.API.Models;
using CST.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CST.Categoria.API.Data.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly CategoriaContext _context;

        public CategoriaRepository(CategoriaContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Categorias>> ObterTodos()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<Categorias> ObterPorId(Guid id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public void Adicionar(Categorias categoria)
        {
            _context.Categorias.Add(categoria);
        }

        public void Atualizar(Categorias categoria)
        {
            _context.Categorias.Update(categoria);
        }

        public void Deletar(Categorias categoria)
        {
            _context.Categorias.Remove(categoria);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}