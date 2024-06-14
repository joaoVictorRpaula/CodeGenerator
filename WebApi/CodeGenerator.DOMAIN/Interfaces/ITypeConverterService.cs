using CodeGenerator.DOMAIN.Models;
using CodeGenerator.DOMAIN.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Interfaces
{
    public interface ITypeConverterService
    {
        IList<Table> ConvertType(IList<Table> tables, string languageType);
        IList<string> GetAvailableLanguages();
    }
}
