using CodeGenerator.DOMAIN.Models.Db;
using CodeGenerator.INFRA.Default;

namespace CodeGenerator.INFRA.Interfaces
{
    public interface IDbService
    {
        Task<IList<Table>> GetTables(DefaultContext context);
    }
}
