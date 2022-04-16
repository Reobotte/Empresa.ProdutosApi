namespace Empresa.ProdutosApi.Domains.CQRS.Validations
{
    class ProdutoCommandValidate : ProdutoValidate
    {
        internal ProdutoCommandValidate()
        {
            ValidarId();
            ValidarDescricao();
            ValidarPreco();
            ValidarAtivo();
            ValidarCategoriaId();
        }
    }
}
