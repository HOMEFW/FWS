using System.Collections.Generic;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository:IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string Nome);
    }
}
