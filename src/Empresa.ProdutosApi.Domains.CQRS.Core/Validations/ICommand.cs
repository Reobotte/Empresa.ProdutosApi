namespace Empresa.ProdutosApi.Domains.CQRS.Core.Validations
{
    public interface ICommand
    {
        bool IsValid();
    }
}
