using Empresa.ProdutosApi.Domains.Entities.Interfaces;
using Empresa.ProdutosApi.Domains.Enumerated;
using System;

namespace Empresa.ProdutosApi.Domains.Entities
{
    public class Produto : EntityBase, IProduto
    {
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public EnumStatus Status { get; private set; }
        public Guid? CategoriaId { get; private set; }

        private Produto() : base() {}

        protected Produto(Guid id)
            : base(id) { }

        protected Produto(string descricao, decimal preco, EnumStatus status, Guid? categoriaId) =>
            Set(
                descricao: descricao, 
                preco: preco, 
                status: status,
                categoriaId: categoriaId);

        protected Produto(Guid id, string descricao, decimal preco, EnumStatus status, Guid? categoriaId)
            : base(id) =>
                Set(
                    descricao: descricao,
                    preco: preco,
                    status: status,
                    categoriaId: categoriaId);

        public Produto(IProduto entity) : base(entity.Id) =>
            Set(
                descricao: entity.Descricao,
                preco: entity.Preco,
                status: entity.Status,
                categoriaId: entity.CategoriaId);

        private void Set(string descricao, decimal preco, EnumStatus status, Guid? categoriaId)
        {
            Descricao = descricao;
            Preco = preco;
            Status = status;
            CategoriaId = categoriaId;
        }

        public override string ToString() =>
            Id.ToString() + "  -  " + Descricao;
    }
}
