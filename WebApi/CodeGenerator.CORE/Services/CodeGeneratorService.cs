using CodeGenerator.DOMAIN.Interfaces;
using CodeGenerator.DOMAIN.Models;
using CodeGenerator.DOMAIN.Models.Db;
using CodeGenerator.INFRA.DynamicDbContext;
using CodeGenerator.INFRA.Interfaces;
using RazorEngine;
using RazorEngine.Templating;

namespace CodeGenerator.CORE.Services
{
    public class CodeGeneratorService : ICodeGeneratorService
    {
        private readonly DynamicDbContext dbContext;
        private readonly IDbService dbService;
        private readonly IGenerateFolderService generateFolderService;
        private readonly ITemplateService templateService;
        private readonly ITypeConverterService typeConverterService;
        public CodeGeneratorService(
            DynamicDbContext dbContext,
            IDbService dbService,
            IGenerateFolderService generateService,
            ITemplateService templateService,
            ITypeConverterService typeConverterService)
        {
            this.dbContext = dbContext;
            this.dbService = dbService;
            this.generateFolderService = generateService;
            this.templateService = templateService;
            this.typeConverterService = typeConverterService;
        }

        public async Task Generate(ApplicationDto applicationDto)
        {
            var context = this.dbContext.CreateDbContext(applicationDto.DbInformation);

            var tables = await this.dbService.GetTables(context);

            tables = typeConverterService.ConvertType(tables, applicationDto.VariableTypes);
            
            if (tables == null || tables.Count == 0)
            {
                throw new Exception("No tables found on database.");
            }

            var apiVersionService = templateService.ResolveService(applicationDto.TemplateName);

            var rootFolder = apiVersionService.GetRootFolder(applicationDto.ApplicationName);

            await this.generateFolderService.ExecuteGenerate(tables, applicationDto, rootFolder);
        }
    }
}
