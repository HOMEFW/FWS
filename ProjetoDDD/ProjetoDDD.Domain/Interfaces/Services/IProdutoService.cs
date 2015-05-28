using System.Collections.Generic;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Domain.Interfaces.Services
{
    public interface IProdutoService: IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
