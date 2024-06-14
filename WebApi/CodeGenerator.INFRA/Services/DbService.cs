using CodeGenerator.DOMAIN.Interfaces;
using CodeGenerator.DOMAIN.Models.Db;
using CodeGenerator.INFRA.Default;
using CodeGenerator.INFRA.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.INFRA.Services
{
    public class DbService : IDbService
    {
        public async Task<IList<Table>> GetTables(DefaultContext context)
        {
            var tables = await context.Tables
                .AsNoTracking()
                .Where(x => x.type_desc == "USER_TABLE" && x.name != "sysdiagrams")

                .Include(x => x.Columns)
                    .ThenInclude(x => x.ColumnType)
                .Include(x => x.Columns)
                    .ThenInclude(x => x.IndexColumns)
                    .ThenInclude(x => x.Indexes)

                .Include(x => x.ParentRelations)
                    .ThenInclude(x => x.RelatedTable)
                .Include(x => x.ParentRelations)
                    .ThenInclude(x => x.RelatedColumn)
                .Include(x => x.ParentRelations)
                    .ThenInclude(x => x.ParentColumn)

                .Include(x => x.RelatedRelations)
                    .ThenInclude(x => x.ParentTable)
                .Include(x => x.RelatedRelations)
                    .ThenInclude(x => x.ParentColumn)
                .Include(x => x.RelatedRelations)
                    .ThenInclude(x => x.RelatedColumn)

                .AsSplitQuery()
                .ToListAsync();

            return tables;
        }
    }
}
