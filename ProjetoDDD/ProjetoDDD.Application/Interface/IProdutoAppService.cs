using System.Collections.Generic;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Application.Interface
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
