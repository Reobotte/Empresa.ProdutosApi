using Empresa.ProdutosApi.Domains.Entities.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Empresa.ProdutosApi.ApplicationServices.ValueObjects
{
    public class ProdutoIdVo : ProdutoVo, IEntityBase
    {
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [DisplayName("Id")]
        public Guid Id{ get; set; }

        internal ProdutoIdVo() { }

        internal ProdutoIdVo(Guid id) =>
            Id = id;
    }
}
