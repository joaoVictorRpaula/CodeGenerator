using CodeGenerator.DOMAIN.Interfaces;
using CodeGenerator.DOMAIN.Models;
using CodeGenerator.DOMAIN.Models.Db;
using CodeGenerator.INFRA.Interfaces;
using Microsoft.Extensions.Configuration;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.INFRA.Services
{
    public class GenerateFileService : IGenerateFileService
    {
        private string BaseTemplatePath;
        public GenerateFileService(IConfiguration configuration)
        {
            var currentPath = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            BaseTemplatePath = Path.Combine(currentPath, "CodeGenerator.INFRA", "Templates");
        }

        public async Task ExecuteGenerate(Table table, ApplicationDto applicationDto, Folder rootFolder, IList<Table> tableList)
        {
            await GenerateFile(rootFolder, table, applicationDto, tableList);
        }

        private async Task GenerateFile(Folder folder, Table table, ApplicationDto applicationDto, IList<Table> tableList)
        {
            var codeGeneratorDto = new CodeGeneratorDto
            {
                Application = applicationDto
            };

            if (folder.Files != null && folder.Files.Count > 0)
            {
                foreach (var file in folder.Files)
                {
                    if (file.GenerateFileForEachTable)
                    {
                        foreach(var tableFromList in tableList)
                        {
                            await ExecuteGenerateFile(folder, tableFromList, applicationDto, tableList, file, codeGeneratorDto);
                        }
                    }

                    if (!file.GenerateFileForEachTable)
                    {
                        await ExecuteGenerateFile(folder, table, applicationDto, tableList, file, codeGeneratorDto);
                    }
                }
            }
        }
        private string GetFilePath(Folder folder, FileDto file, Table table, ApplicationDto applicationDto)
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
        private async Task ExecuteGenerateFile(Folder folder, Table table, ApplicationDto applicationDto, IList<Table> tableList, FileDto file, CodeGeneratorDto codeGeneratorDto)
        {
            var resultContent = string.Empty;

            var templatePath = Path.Combine(BaseTemplatePath, applicationDto.ApiVersion, "Templates", file.TemplateName);

            var template = File.ReadAllText(templatePath);

            codeGeneratorDto.Table = table;
            codeGeneratorDto.TableList = tableList;

            var templateExists = Engine.Razor.IsTemplateCached(file.TemplateName, null);

            if (templateExists)
            {
                resultContent = Engine.Razor.Run(file.TemplateName, null, codeGeneratorDto);
            }
            if (!templateExists)
            {
                resultContent = Engine.Razor.RunCompile(template, file.TemplateName, null, codeGeneratorDto);
            }

            var filePath = GetFilePath(folder, file, table, applicationDto);

            await File.WriteAllTextAsync(filePath, resultContent);

            return;
        }
    }
}
