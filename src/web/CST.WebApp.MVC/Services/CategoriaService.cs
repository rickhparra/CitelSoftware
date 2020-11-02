using CST.WebApp.MVC.Extensions;
using CST.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CST.WebApp.MVC.Services
{
    public class CategoriaService : Service, ICategoriaService
    {
        private readonly HttpClient _httpClient;

        public CategoriaService(HttpClient httpClient,
                                   IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CategoriaUrl);
            _httpClient = httpClient;
        }

        public async Task<ResponseResult> Adicionar(CategoriaViewModel categoria)
        {
            var itemContent = ObterConteudo(categoria);

            var response = await _httpClient.PostAsync("/adicionar-categoria/", itemContent);

            if (!TratarErrosResponse(response)) 
                return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> Atualizar(CategoriaViewModel categoria)
        {
            var itemContent = ObterConteudo(categoria);

            var response = await _httpClient.PatchAsync("/atualizar-categoria/", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> Deletar(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"/deletar-categoria/{id}");

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<CategoriaViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/categoria/{id}");

            TratarErrosResponse(response);

            if ((int)response.StatusCode == 204) return new CategoriaViewModel();

            return await DeserializarObjetoResponse<CategoriaViewModel>(response);
        }

        public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("/categorias");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<CategoriaViewModel>>(response);
        }
    }
}