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
        private readonly ITypeConverterService typeConverterService;
        public DbService(ITypeConverterService typeConverterService)
        {
            this.typeConverterService = typeConverterService;
        }

        public async Task<List<Table>> GetTables(DefaultContext context)
        {
            var tables = await context.Tables
                .AsNoTracking()
                .Where(x => x.type_desc == "USER_TABLE" && x.name != "sysdiagrams")
                .Include(x => x.Columns)
                    .ThenInclude(x => x.ColumnType)

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

            foreach (var table in tables)
            {
                table.Columns = this.typeConverterService.ConvertToCSharpType(table.Columns);
            }

            return tables;
        }
    }
}
