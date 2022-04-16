using System;

namespace Empresa.ProdutosApi.ApplicationServices.ValueObjects
{
    public class ProdutoCategoriaVo : ProdutoIdVo
    {
        public CategoriaVo Categoria { get; set; }

        internal ProdutoCategoriaVo() { }

        internal ProdutoCategoriaVo(Guid id) 
            : base(id) { }
    }
}
