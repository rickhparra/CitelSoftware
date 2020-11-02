using CST.WebApp.MVC.Models;
using CST.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CST.WebApp.MVC.Controllers
{
    public class ProdutoController : MainController
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;

        public ProdutoController(IProdutoService produtoService,
                                 ICategoriaService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }

        [HttpGet]        
        [Route("")]
        [Route("produtos")]
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.ObterTodos();
            return View(produtos);
        }

        [HttpGet]
        [Route("adicionar-produto")]
        public async Task<IActionResult> Registro()
        {
            var categorias = await _categoriaService.ObterTodos();
            ViewBag.ListaCategorias = categorias.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() });

            return View();
        }

        [HttpPost]
        [Route("adicionar-produto")]
        public async Task<IActionResult> Registro(ProdutoViewModel produto)
        {
            var categorias = await _categoriaService.ObterTodos();
            ViewBag.ListaCategorias = categorias.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() });

            if (!ModelState.IsValid) return View(produto);

            var resposta = await _produtoService.Adicionar(produto);

            if (ResponsePossuiErros(resposta)) return View(produto);

            return RedirectToAction("Index", "Produto");
        }

        [HttpGet]
        [Route("detalhe-produto/{id}")]
        public async Task<IActionResult> Detalhe(Guid id)
        {
            var produto = await _produtoService.ObterPorId(id);
            var categoria = await _categoriaService.ObterPorId(Guid.Parse(produto.CategoriaId));

            produto.Categoria = categoria;

            return View(produto);
        }

        [HttpGet]
        [Route("atualizar-produto/{id}")]
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var produto = await _produtoService.ObterPorId(id);
            var categorias = await _categoriaService.ObterTodos();
            ViewBag.ListaCategorias = categorias.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() });

            return View(produto);
        }

        [HttpPost]
        [Route("atualizar-produto/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, ProdutoViewModel produto)
        {
            var categorias = await _categoriaService.ObterTodos();
            ViewBag.ListaCategorias = categorias.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() });

            if (!ModelState.IsValid) return View(produto);
            if (id != produto.Id)
            {
                AdicionarErroValidacao("Erro ao atualizar! ID inválido.");
                return View(produto);
            }

            var resposta = await _produtoService.Atualizar(produto);

            if (ResponsePossuiErros(resposta)) return View(produto);

            return RedirectToAction("Index", "Produto");
        }

        [HttpGet]
        [Route("deletar-produto/{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var produto = await _produtoService.ObterPorId(id);
            var categorias = await _categoriaService.ObterTodos();
            ViewBag.ListaCategorias = categorias.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() });

            return View(produto);
        }

        [HttpPost]
        [Route("deletar-produto/{id}")]
        public async Task<IActionResult> Deletar(Guid id, ProdutoViewModel produto)
        {
            var categorias = await _categoriaService.ObterTodos();
            ViewBag.ListaCategorias = categorias.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() });
            
            if (id != produto.Id)
            {
                AdicionarErroValidacao("Erro ao deletar! ID inválido.");
                return View(produto);
            }

            var resposta = await _produtoService.Deletar(id);

            if (ResponsePossuiErros(resposta)) return View(produto);

            return RedirectToAction("Index", "Produto");
        }
    }
}