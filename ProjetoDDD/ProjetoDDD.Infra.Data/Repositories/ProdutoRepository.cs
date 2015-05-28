using System.Linq;
using ProjetoDDD.Domain.Entities;
using System.Collections.Generic;
using ProjetoDDD.Domain.Interfaces.Repositories;

namespace ProjetoDDD.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscarPorNome(string Nome)
        {
            return Db.Produtos.Where(p => p.Nome.Contains(Nome));
        }
    }
}
