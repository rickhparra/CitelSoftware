using CST.Categoria.API.Models;
using CST.WebAPI.Core.Controllers;
using CST.WebAPI.Core.Identidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CST.Categoria.API.Controllers
{    
    [Authorize]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpPost("adicionar-categoria")]
        [ClaimsAuthorize("site", "admin")]
        public async Task<ActionResult> Registrar(Categorias categoria)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            _categoriaRepository.Adicionar(categoria);

            if (await _categoriaRepository.UnitOfWork.Commit())
                return CustomResponse();

            AdicionarErroProcessamento("Erro ao salvar as informações.");
            return CustomResponse();
        }

        [HttpPatch("atualizar-categoria")]
        [ClaimsAuthorize("site", "admin")]
        public async Task<ActionResult> Atualizar(Categorias categoria)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            _categoriaRepository.Atualizar(categoria);

            if (await _categoriaRepository.UnitOfWork.Commit())
                return CustomResponse(categoria);

            AdicionarErroProcessamento("Erro ao salvar as informações.");
            return CustomResponse();
        }

        [HttpDelete("deletar-categoria/{id}")]
        [ClaimsAuthorize("site", "admin")]
        public async Task<ActionResult> Deletar(Guid id)
        {
            var categoria = await _categoriaRepository.ObterPorId(id);

            _categoriaRepository.Deletar(categoria);

            if (await _categoriaRepository.UnitOfWork.Commit())
                return CustomResponse(categoria);

            AdicionarErroProcessamento("Erro ao deletar.");
            return CustomResponse();
        }

        [HttpGet("categorias")]
        [ClaimsAuthorize("site", "admin")]
        public async Task<IEnumerable<Categorias>> Index()
        {
            return await _categoriaRepository.ObterTodos();
        }
        
        [HttpGet("categoria/{id}")]
        [ClaimsAuthorize("site", "admin")]
        public async Task<Categorias> CategoriaDetalhe(Guid id)
        {            
            return await _categoriaRepository.ObterPorId(id);
        }
    }
}