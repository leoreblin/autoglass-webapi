using Autoglass.Backend.Application.Fornecedores.Repositories;
using Autoglass.Backend.Core.Entities;
using Autoglass.Backend.Data.SQL.Interfaces;

namespace Autoglass.Backend.Data.SQL.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}
