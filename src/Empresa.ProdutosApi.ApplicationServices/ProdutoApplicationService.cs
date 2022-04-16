using AutoMapper;
using Empresa.ProdutosApi.ApplicationServices.Interfaces;
using Empresa.ProdutosApi.ApplicationServices.ValueObjects;
using Empresa.ProdutosApi.Domains.CQRS.Commands.ProdutoCommands;
using Empresa.ProdutosApi.Domains.CQRS.Core.Validations;
using Empresa.ProdutosApi.Infra.Data.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.ProdutosApi.ApplicationServices
{
    public class ProdutoApplicationService
        : IProdutoApplicationService
    {
        private readonly IProdutoQueryRepository _query;
        private readonly ICategoriaServices _categoriaServices;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProdutoApplicationService(
            IProdutoQueryRepository query,
            ICategoriaServices categoriaServices,
            IMapper mapper,
            IMediator mediator)
        {
            _query = query;
            _categoriaServices = categoriaServices;
            _mediator = mediator;
            _mapper = mapper;
        }

        #region Query

        public async Task<IEnumerable<ProdutoIdVo>> GetAll() =>
            _mapper.Map<IEnumerable<ProdutoIdVo>>(
                await _query.GetAll());

        public async Task<IEnumerable<ProdutoCategoriaVo>> GetProdutosCategoria(Guid? categoriaId)
        {
            if (categoriaId == null)
            {
                return (
                    from produto in _mapper.Map<IEnumerable<ProdutoCategoriaVo>>(await _query.GetAll())
                        join cat in await _categoriaServices.GetAll() on produto.CategoriaId equals cat.Id
                        into catTemp
                    from categoria in catTemp.DefaultIfEmpty()
                    select new ProdutoCategoriaVo
                    {
                        Id = produto.Id,
                        Descricao = produto.Descricao,
                        Preco = produto.Preco,
                        Status = produto.Status,
                        CategoriaId = produto.CategoriaId,
                        Categoria = categoria
                    }
                ).ToList();
            }
            else
            {
                return (
                    from produto in _mapper.Map<IEnumerable<ProdutoCategoriaVo>>(await _query.GetAll())
                        join cat in await _categoriaServices.GetAll() on produto.CategoriaId equals cat.Id
                        into catTemp
                    where produto.CategoriaId == categoriaId
                    from categoria in catTemp.DefaultIfEmpty()
                    select new ProdutoCategoriaVo
                    {
                        Id = produto.Id,
                        Descricao = produto.Descricao,
                        Preco = produto.Preco,
                        Status = produto.Status,
                        CategoriaId = produto.CategoriaId,
                        Categoria = categoria
                    }
                ).ToList();
            }
        }

        public async Task<ProdutoCategoriaVo> GetProdutoCategoria(Guid id)
        {
            var categoria = _mapper.Map<ProdutoCategoriaVo>(await _query.Get(id));
            if (categoria?.CategoriaId != null)
                categoria.Categoria = await _categoriaServices.Get(Guid.Parse(categoria.CategoriaId.ToString()));            
            return categoria;
        }

        public async Task<ProdutoIdVo> Get(Guid id) =>
            _mapper.Map<ProdutoIdVo>(
                await _query.Get(id));

        #endregion

        #region CRUD

        public async Task<ResultVo> Insert(ProdutoIdVo obj) =>
            await GetResultVo(
                command: _mapper.Map<IncluirProdutoCommand>(obj));

        public async Task<ResultVo> Update(ProdutoIdVo obj) =>
            await GetResultVo(
                command: _mapper.Map<AlterarProdutoCommand>(obj));

        public async Task<IResult> Delete(Guid id) =>
            await _mediator.Send(
                _mapper.Map<ExcluirProdutoCommand>(new ProdutoIdVo(id)));

        private async Task<ResultVo> GetResultVo(ProdutoCommand command) =>
            new ResultVo(
                result: await _mediator.Send(command),
                produtoIdVo: _mapper.Map<ProdutoIdVo>(command));

        #endregion

        public void Dispose() =>
            _query?.Dispose();
    }
}
