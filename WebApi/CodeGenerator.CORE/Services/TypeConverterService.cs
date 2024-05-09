using CodeGenerator.DOMAIN.Interfaces;
using CodeGenerator.DOMAIN.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.CORE.Services
{
    public class TypeConverterService : ITypeConverterService
    {

        private readonly Dictionary<string, string> TypeMapping = new Dictionary<string, string>
        {
            { "image", "byte[]" },
            { "text", "string" },
            { "ntext", "string" },
            { "varchar", "string" },
            { "nvarchar", "string" },
            { "char", "string" },
            { "nchar", "string" },
            { "sysname", "string" },
            { "uniqueidentifier", "Guid" },
            { "date", "DateTime" },
            { "time", "TimeSpan" },
            { "datetime2", "DateTime" },
            { "datetime", "DateTime" },
            { "datetimeoffset", "DateTimeOffset" },
            { "tinyint", "byte" },
            { "smallint", "short" },
            { "int", "int" },
            { "smalldatetime", "DateTime" },
            { "real", "float" },
            { "money", "decimal" },
            { "smallmoney", "decimal" },
            { "decimal", "decimal" },
            { "numeric", "decimal" },
            { "float", "double" },
            { "bit", "bool" },
            { "bigint", "long" },
            { "binary", "byte[]" },
            { "timestamp", "byte[]" },
        };

        public IList<Column> ConvertToCSharpType(IList<Column> columns)
        {
            foreach(var column in columns)
            {
                column.ColumnType.name = TypeMapping.TryGetValue(column.ColumnType.name.ToLower(), out var csharpType) ? csharpType : "object";
            }

            return columns;
        }
    }
}
