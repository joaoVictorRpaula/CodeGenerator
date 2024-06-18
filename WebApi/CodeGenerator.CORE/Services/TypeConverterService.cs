using CodeGenerator.DOMAIN.Interfaces;
using CodeGenerator.DOMAIN.Models;
using CodeGenerator.DOMAIN.Models.Db;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.CORE.Services
{
    public class TypeConverterService : ITypeConverterService
    {
        public IList<string> GetAvailableLanguages()
        {
            return new List<string> {
                "CSharp",
                "Python",
                "Java",
                "TypeScript"
            };
        }

        public IList<Table> ConvertType(IList<Table> tables, string languageType)
        {
            FieldInfo field = this.GetType().GetField(languageType, BindingFlags.Instance | BindingFlags.NonPublic);

            var typeMapping = new Dictionary<string, string>();

            if (field == null)
            {
                throw new Exception($"Language {languageType} is not supported.");
            }

            if (field.FieldType == typeof(Dictionary<string, string>))
            {
                typeMapping = (Dictionary<string, string>)field.GetValue(this);
            }

            foreach (var table in tables)
            {
                foreach (var column in table.Columns)
                {
                    column.ColumnType.name = typeMapping.TryGetValue(column.ColumnType.name.ToLower(), out var csharpType) ? csharpType : "object";
                }
            }

            return tables;
        }

        private readonly Dictionary<string, string> CSharp = new Dictionary<string, string>
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

        private readonly Dictionary<string, string> TypeScript = new Dictionary<string, string>
        {
            { "image", "Uint8Array" },
            { "text", "string" },
            { "ntext", "string" },
            { "varchar", "string" },
            { "nvarchar", "string" },
            { "char", "string" },
            { "nchar", "string" },
            { "sysname", "string" },
            { "uniqueidentifier", "string" },
            { "date", "Date" },
            { "time", "string" },
            { "datetime2", "Date" },
            { "datetime", "Date" },
            { "datetimeoffset", "string" },
            { "tinyint", "number" },
            { "smallint", "number" },
            { "int", "number" },
            { "smalldatetime", "Date" },
            { "real", "number" },
            { "money", "number" },
            { "smallmoney", "number" },
            { "decimal", "number" },
            { "numeric", "number" },
            { "float", "number" },
            { "bit", "boolean" },
            { "bigint", "number" },
            { "binary", "Uint8Array" },
            { "timestamp", "Uint8Array" },
        };

        private readonly Dictionary<string, string> Python = new Dictionary<string, string>
        {
            { "image", "bytes" },
            { "text", "str" },
            { "ntext", "str" },
            { "varchar", "str" },
            { "nvarchar", "str" },
            { "char", "str" },
            { "nchar", "str" },
            { "sysname", "str" },
            { "uniqueidentifier", "str" },
            { "date", "datetime.date" },
            { "time", "datetime.time" },
            { "datetime2", "datetime.datetime" },
            { "datetime", "datetime.datetime" },
            { "datetimeoffset", "datetime.datetime" },
            { "tinyint", "int" },
            { "smallint", "int" },
            { "int", "int" },
            { "smalldatetime", "datetime.datetime" },
            { "real", "float" },
            { "money", "decimal.Decimal" },
            { "smallmoney", "decimal.Decimal" },
            { "decimal", "decimal.Decimal" },
            { "numeric", "decimal.Decimal" },
            { "float", "float" },
            { "bit", "bool" },
            { "bigint", "int" },
            { "binary", "bytes" },
            { "timestamp", "bytes" },
        };

        private readonly Dictionary<string, string> Java = new Dictionary<string, string>
        {
            { "image", "byte[]" },
            { "text", "String" },
            { "ntext", "String" },
            { "varchar", "String" },
            { "nvarchar", "String" },
            { "char", "String" },
            { "nchar", "String" },
            { "sysname", "String" },
            { "uniqueidentifier", "UUID" },
            { "date", "LocalDate" },
            { "time", "LocalTime" },
            { "datetime2", "LocalDateTime" },
            { "datetime", "LocalDateTime" },
            { "datetimeoffset", "OffsetDateTime" },
            { "tinyint", "byte" },
            { "smallint", "short" },
            { "int", "int" },
            { "smalldatetime", "LocalDateTime" },
            { "real", "float" },
            { "money", "BigDecimal" },
            { "smallmoney", "BigDecimal" },
            { "decimal", "BigDecimal" },
            { "numeric", "BigDecimal" },
            { "float", "double" },
            { "bit", "boolean" },
            { "bigint", "long" },
            { "binary", "byte[]" },
            { "timestamp", "byte[]" },
        };
    }
}
