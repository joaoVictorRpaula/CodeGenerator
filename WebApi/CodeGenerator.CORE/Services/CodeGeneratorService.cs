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
        private readonly IVersionService versionService;
        public CodeGeneratorService(
            DynamicDbContext dbContext,
            IDbService dbService,
            IGenerateFolderService generateService,
            IVersionService versionService)
        {
            this.dbContext = dbContext;
            this.dbService = dbService;
            this.generateFolderService = generateService;
            this.versionService = versionService;
        }

        public async Task Generate(ApplicationDto applicationDto)
        {
            var context = this.dbContext.CreateDbContext(applicationDto.DbInformation);

            var tables = await this.dbService.GetTables(context);

            if (tables == null || tables.Count == 0)
            {
                throw new Exception("No tables found on database.");
            }

            var apiVersionService = versionService.ResolveService(applicationDto.TemplateName);

            var rootFolder = apiVersionService.GetRootFolder(applicationDto.ApplicationName);

            await this.generateFolderService.ExecuteGenerate(tables, applicationDto, rootFolder);
        }
    }
}
