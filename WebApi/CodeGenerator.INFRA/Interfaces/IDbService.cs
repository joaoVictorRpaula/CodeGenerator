using CodeGenerator.DOMAIN.Models.Db;
using CodeGenerator.INFRA.Default;

namespace CodeGenerator.INFRA.Interfaces
{
    public interface IDbService
    {
        Task<List<Table>> GetTables(DefaultContext context);
    }
}
