using CST.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CST.WebApp.MVC.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
        Task<ProdutoViewModel> ObterPorId(Guid id);
        Task<ResponseResult> Adicionar(ProdutoViewModel produto);
        Task<ResponseResult> Atualizar(ProdutoViewModel produto);
        Task<ResponseResult> Deletar(Guid id);
    }
}