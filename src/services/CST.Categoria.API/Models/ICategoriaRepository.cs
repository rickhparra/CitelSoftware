using CST.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CST.Categoria.API.Models
{
    public interface ICategoriaRepository : IRepository<Categorias>
    {
        Task<IEnumerable<Categorias>> ObterTodos();
        Task<Categorias> ObterPorId(Guid id);
        void Adicionar(Categorias produto);
        void Atualizar(Categorias produto);
        void Deletar(Categorias produto);
    }
}