using CST.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CST.Produtos.API.Models
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Deletar(Produto produto);
    }
}