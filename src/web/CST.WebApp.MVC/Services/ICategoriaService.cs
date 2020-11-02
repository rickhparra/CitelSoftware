using CST.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CST.WebApp.MVC.Services
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaViewModel>> ObterTodos();
        Task<CategoriaViewModel> ObterPorId(Guid id);
        Task<ResponseResult> Adicionar(CategoriaViewModel categoria);
        Task<ResponseResult> Atualizar(CategoriaViewModel categoria);
        Task<ResponseResult> Deletar(Guid id);
    }
}