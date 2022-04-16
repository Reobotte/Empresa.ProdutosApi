using AutoMapper;
using Empresa.ProdutosApi.ApplicationServices.Interfaces;
using Empresa.ProdutosApi.ApplicationServices.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.ProdutosApi.Controllers
{
    // ToDo: Implementar gerenciamento para controle de versão
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoApplicationService _service;

        public ProdutosController(IProdutoApplicationService service) =>
            _service = service;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProdutoIdVo>))]
        public async Task<IActionResult> Get() =>
            Ok(await _service.GetAll());

        [HttpGet("categoria")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProdutoCategoriaVo>))]
        public async Task<IActionResult> GetProdutosCategoria([FromQuery] Guid? categoriaId) =>
            Ok(await _service.GetProdutosCategoria(categoriaId));

        [HttpGet("categoria/{produtoId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProdutoCategoriaVo>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetProdutoCategoria(Guid produtoId)
        {
            var response = await _service.GetProdutoCategoria(produtoId);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ProdutoIdVo))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _service.Get(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(ProdutoVo))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post(
        [FromBody] ProdutoVo produtoVo, [FromServices] IMapper _mapper)
        {
            if (produtoVo == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.Insert(_mapper.Map<ProdutoIdVo>(produtoVo));
            if (result.Result.HasErrors)
                return Resultado(result: result.Result.Errors);

            return GetCreatedAtRoute(produtoIdVo: result.ProdutoIdVo);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(ProdutoIdVo))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProdutoIdVo produtoIdVo)
        {
            if (id != produtoIdVo.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.Update(produtoIdVo);
            if (result.Result.HasErrors)
                return Resultado(result: result.Result.Errors);

            return GetCreatedAtRoute(produtoIdVo: result.ProdutoIdVo);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _service.Delete(id);
            if (response.HasErrors)
                return Resultado(result: response.Errors);

            return NoContent();
        }

        #region Private Methods

        private CreatedAtRouteResult GetCreatedAtRoute(ProdutoIdVo produtoIdVo)
        {
            return CreatedAtRoute(
                "DefaultApi",
                new { produto = produtoIdVo, get = GetLink(id: produtoIdVo.Id) });
        }

        private string GetLink(Guid id) =>
            new StringBuilder(Url.Link("DefaultApi", new { id }))
                .Replace("%2F", "/")
                .ToString();

        private IActionResult Resultado(IEnumerable<string> result)
        {
            AddModelError(result.ToList());
            return BadRequest(ModelState);
        }

        private void AddModelError(List<string> erros) =>
            erros.ToList()
                .ForEach(erro => ModelState.AddModelError(string.Empty, erro));

        #endregion
    }
}
