using CST.Produtos.API.Models;
using CST.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CST.WebAPI.Core.Identidade;
using Microsoft.AspNetCore.Authorization;

namespace CST.Produtos.API.Controllers
{    
    [Authorize]
    public class ProdutoController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }        

        [HttpPost("adicionar-produto")]
        [ClaimsAuthorize("site", "admin")]
        public async Task<ActionResult> Registrar(Produto produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            _produtoRepository.Adicionar(produto);

            if (await _produtoRepository.UnitOfWork.Commit())
                return CustomResponse(produto);

            AdicionarErroProcessamento("Erro ao salvar as informações.");
            return CustomResponse();
        }

        [HttpPatch("atualizar-produto")]
        [ClaimsAuthorize("site", "admin")]
        public async Task<ActionResult> Atualizar(Produto produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            _produtoRepository.Atualizar(produto);

            if (await _produtoRepository.UnitOfWork.Commit())
                return CustomResponse(produto);

            AdicionarErroProcessamento("Erro ao salvar as informações.");
            return CustomResponse();
        }

        [HttpDelete("deletar-produto/{id}")]
        [ClaimsAuthorize("site", "admin")]
        public async Task<ActionResult> Deletar(Guid id)
        {
            var produto = await _produtoRepository.ObterPorId(id);

            _produtoRepository.Deletar(produto);

            if (await _produtoRepository.UnitOfWork.Commit())
                return CustomResponse(produto);

            AdicionarErroProcessamento("Erro ao deletar.");
            return CustomResponse();
        }

        [HttpGet("produtos")]
        [ClaimsAuthorize("site", "admin")]
        public async Task<IEnumerable<Produto>> Index()
        {
            return await _produtoRepository.ObterTodos();
        }

        [HttpGet("produto/{id}")]
        [ClaimsAuthorize("site", "admin")]
        public async Task<Produto> CategoriaDetalhe(Guid id)
        {
            return await _produtoRepository.ObterPorId(id);
        }
    }
}