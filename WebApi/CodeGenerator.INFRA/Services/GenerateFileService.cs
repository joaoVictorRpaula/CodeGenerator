using CodeGenerator.DOMAIN.Interfaces;
using CodeGenerator.DOMAIN.Models;
using CodeGenerator.DOMAIN.Models.Db;
using CodeGenerator.INFRA.Interfaces;
using CodeGenerator.INFRA.Templates.CSR.Net6;
using Microsoft.Extensions.Configuration;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.INFRA.Services
{
    public class GenerateFileService : IGenerateFileService
    {
        private readonly IPathService pathService;
        public GenerateFileService(IPathService pathService)
        {
            this.pathService = pathService;
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

        private async Task ExecuteGenerateFile(Folder folder, Table table, ApplicationDto applicationDto, IList<Table> tableList, FileDto file, CodeGeneratorDto codeGeneratorDto)
        {
            var resultContent = string.Empty;

            var templatePath = Path.Combine(this.pathService.GetBaseTemplatePath(applicationDto.TemplateName), file.TemplateName);

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

            var filePath = this.pathService.BuildFilePath(folder, file, table, applicationDto);

            await File.WriteAllTextAsync(filePath, resultContent);

            return;
        }
    }
}
