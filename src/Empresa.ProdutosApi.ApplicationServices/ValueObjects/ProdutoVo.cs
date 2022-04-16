using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Empresa.ProdutosApi.ApplicationServices.ValueObjects
{
    public class ProdutoVo
    {
        [Required(ErrorMessage = "A {0} é obrigatória!")]
        [StringLength(80, ErrorMessage = "A {0} deve ter possuir entre {2} a {1} caracteres!", MinimumLength = 3)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [JsonConverter(typeof(StringEnumConverter))]
        [DisplayName("Status")]
        public EnumStatus Status { get; set; }

        [DisplayName("Categoria")]
        public Guid? CategoriaId { get; set; }
    }
}
