using CodeGenerator.DOMAIN.Models;
using CodeGenerator.DOMAIN.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.INFRA.Interfaces
{
    public interface IPathService
    {
        string BuildFilePath(Folder folder, FileDto file, Table table, ApplicationDto applicationDto);

        string GetBaseTemplatePath(string TemplateTypeName);
    }
}
