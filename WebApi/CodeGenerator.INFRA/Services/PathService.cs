using CodeGenerator.DOMAIN.Models;
using CodeGenerator.DOMAIN.Models.Db;
using CodeGenerator.INFRA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.INFRA.Services
{
    public class PathService : IPathService
    {
        private string BaseTemplatePath;

        public PathService()
        {
            var currentPath = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            BaseTemplatePath = Path.Combine(currentPath, "CodeGenerator.INFRA", "Templates");
        }

        public string BuildFilePath(Folder folder, FileDto file, Table table, ApplicationDto applicationDto)
        {
            var filePath = string.Empty;

            if (file.UseTableName)
            {
                filePath = Path.Combine(folder.Path, $"{file.FileNamePrefix}{table.name}{file.FileNameSufix}{file.FileExtension}");
            }
            if (file.UseApplicationName)
            {
                filePath = Path.Combine(folder.Path, $"{file.FileNamePrefix}{applicationDto.ApplicationName}{file.FileNameSufix}{file.FileExtension}");
            }
            if (!file.UseTableName && !file.UseApplicationName)
            {
                string fileName = file.TemplateName.Substring(0, file.TemplateName.LastIndexOf('.'));
                filePath = Path.Combine(folder.Path, $"{file.FileNamePrefix}{fileName}{file.FileNameSufix}{file.FileExtension}");
            }

            return filePath;
        }

        public string GetBaseTemplatePath(string TemplateTypeName)
        {
            var rootFolder = Path.GetDirectoryName(Directory.GetFiles(BaseTemplatePath, "*", SearchOption.AllDirectories)
                .FirstOrDefault(file => Path.GetFileName(file).Equals($"{TemplateTypeName}.cs", StringComparison.OrdinalIgnoreCase)));

            return Path.Combine(rootFolder, "Templates");
        }
    }
}
