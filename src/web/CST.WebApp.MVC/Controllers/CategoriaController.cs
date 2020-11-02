using CST.WebApp.MVC.Models;
using CST.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CST.WebApp.MVC.Controllers
{    
    public class CategoriaController : MainController
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]        
        [Route("categorias")]
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.ObterTodos();

            return View(categorias);
        }

        [HttpGet]
        [Route("adicionar-categoria")]
        public IActionResult Registro()
        {
            return View();            
        }

        [HttpPost]
        [Route("adicionar-categoria")]
        public async Task<IActionResult> Registro(CategoriaViewModel categoria)
        {
            if (!ModelState.IsValid) return View(categoria);

            var resposta = await _categoriaService.Adicionar(categoria);

            if (ResponsePossuiErros(resposta)) return View(categoria);

            return RedirectToAction("Index", "Categoria");
        }

        [HttpGet]
        [Route("atualizar-categoria/{id}")]
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var categoria = await _categoriaService.ObterPorId(id);

            return View(categoria);
        }

        [HttpPost]
        [Route("atualizar-categoria/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, CategoriaViewModel categoria)
        {
            if (!ModelState.IsValid) return View(categoria);
            if (id != categoria.Id)
            {
                AdicionarErroValidacao("Erro ao atualizar! ID inválido.");
                return View(categoria);
            }

            var resposta = await _categoriaService.Atualizar(categoria);

            if (ResponsePossuiErros(resposta)) return View(categoria);

            return RedirectToAction("Index", "Categoria");
        }

        [HttpGet]
        [Route("deletar-categoria/{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var categoria = await _categoriaService.ObterPorId(id);

            return View(categoria);
        }

        [HttpPost]
        [Route("deletar-categoria/{id}")]
        public async Task<IActionResult> Deletar(Guid id, CategoriaViewModel categoria)
        {
            if (id != categoria.Id)
            {
                AdicionarErroValidacao("Erro ao deletar! ID inválido.");
                return View(categoria);
            }

            var resposta = await _categoriaService.Deletar(id);

            if (ResponsePossuiErros(resposta)) return View(categoria);

            return RedirectToAction("Index", "Categoria");
        }
    }
}