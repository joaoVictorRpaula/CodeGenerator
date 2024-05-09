using CodeGenerator.DOMAIN.Interfaces;
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
    public class GenerateFolderService : IGenerateFolderService
    {
        private readonly IGenerateFileService generateFileService;
        public GenerateFolderService(IGenerateFileService generateFileService)
        {
            this.generateFileService = generateFileService;
        }

        public async Task ExecuteGenerate(IList<Table> tableList, ApplicationDto applicationDto, Folder rootFolder)
        {
            var pathExist = Directory.Exists(applicationDto.Path);
            
            if (!pathExist)
            {
                throw new Exception("Path not found " + applicationDto.Path);
            }

            await GenerateRecursive(tableList, applicationDto.Path, rootFolder, applicationDto);
        }

        private async Task GenerateRecursive(IList<Table> tableList, string basePath, Folder folder, ApplicationDto applicationDto, Table? referenceTable = null)
        {
            string folderPath = Path.Combine(basePath, folder.Name);
            folder.Path = folderPath;
            Directory.CreateDirectory(folderPath);

            if (folder.GenerateSubFolderForEachTable)
            {
                foreach (var table in tableList)
                {
                    var tableFolder = new Folder
                    {
                        Name = table.name,
                        SubFolders = folder.SubFoldersOfSubFolders
                    };

                    await GenerateRecursive(tableList, folderPath, tableFolder, applicationDto, table);
                }
            }

            await generateFileService.ExecuteGenerate(referenceTable, applicationDto, folder, tableList);

            foreach (var subfolder in folder.SubFolders)
            {
                await GenerateRecursive(tableList, folderPath, subfolder, applicationDto, referenceTable);
            }
        }
    }
}
