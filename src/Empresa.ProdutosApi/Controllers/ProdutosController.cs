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

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get() =>
            Ok();

        [HttpGet("categoria")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetProdutosCategoria([FromQuery] Guid? categoriaId) =>
            Ok();

        [HttpGet("categoria/{produtoId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetProdutoCategoria(Guid produtoId) =>
            Ok();

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid id) =>
            Ok();

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post() =>
            Ok();

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(Guid id) =>
            Ok();

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(Guid id) =>
            Ok();

        #region Private Methods

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
