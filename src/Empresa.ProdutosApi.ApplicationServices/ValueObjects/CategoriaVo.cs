using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Empresa.ProdutosApi.ApplicationServices.ValueObjects
{
    public class CategoriaVo
    {
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [DisplayName("Id")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatória!")]
        [StringLength(80, ErrorMessage = "A {0} deve ter possuir entre {2} a {1} caracteres!", MinimumLength = 3)]
        [DisplayName("Categoria")]
        public string Descricao { get; set; }
    }
}
