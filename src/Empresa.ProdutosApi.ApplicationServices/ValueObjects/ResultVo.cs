using Empresa.ProdutosApi.Domains.CQRS.Core.Validations;

namespace Empresa.ProdutosApi.ApplicationServices.ValueObjects
{
    public class ResultVo
    {
        public IResult Result { get; set; }
        public ProdutoIdVo ProdutoIdVo { get; set; }
        public ResultVo(IResult result, ProdutoIdVo produtoIdVo)
        {
            Result = result;
            ProdutoIdVo = produtoIdVo;
        }
    }
}
