using CodeGenerator.DOMAIN.Interfaces;
using CodeGenerator.DOMAIN.Models;
using CodeGenerator.DOMAIN.Models.Db;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.INFRA.Templates.CSR.Net6
{
    public class CSRNet6 : IFolderService
    {
        private Folder Folder { get; set; }
        private void DeclareFolders(string applicationName)
        {
            Folder = new Folder
            {
                Name = applicationName,
                Files = new List<FileDto>
                {
                    new FileDto { TemplateName = "WebApi.sln.cshtml", FileNamePrefix = "", FileNameSufix = "", FileExtension = ".sln", UseTableName = false, UseApplicationName = true },
                },
                SubFolders = new List<Folder>
                {
                    new Folder
                    {
                        Name = $"{applicationName}.API",
                        Files = new List<FileDto>
                        {
                            new FileDto { TemplateName = "appsettings.cshtml", FileNamePrefix = "", FileNameSufix = "", FileExtension = ".json", UseTableName = false },
                            new FileDto { TemplateName = "ODataSetup.cshtml", FileNamePrefix = "", FileNameSufix = "", FileExtension = ".cs", UseTableName = false },
                            new FileDto { TemplateName = "Program.cshtml", FileNamePrefix = "", FileNameSufix = "", FileExtension = ".cs", UseTableName = false },
                            new FileDto { TemplateName = "API.csproj.cshtml", FileNamePrefix = "", FileNameSufix = ".API", FileExtension = ".csproj" , UseTableName = false, UseApplicationName = true}
                        },
                        SubFolders = new List<Folder>
                        {
                            new Folder
                            {
                                Name = "Controllers",
                                Files = new List<FileDto>
                                {
                                    new FileDto { TemplateName = "Controller.cshtml", FileNamePrefix = "", FileNameSufix = "Controller", FileExtension = ".cs", UseTableName = true, GenerateFileForEachTable = true },
                                },
                                SubFolders = new List<Folder>
                                {
                                    new Folder
                                    {
                                        Name = "Bases",
                                        Files = new List<FileDto>
                                        {
                                             new FileDto { TemplateName = "BaseController.cshtml", FileNamePrefix = "", FileNameSufix = "", FileExtension = ".cs" , UseTableName = false}
                                        }
                                    }
                                }
                            },
                            new Folder
                            {
                                Name = "Properties",
                                Files = new List<FileDto>
                                {
                                     new FileDto { TemplateName = "launchSettings.cshtml", FileNamePrefix = "", FileNameSufix = "", FileExtension = ".json", UseTableName = false }
                                }
                            }
                        },
                    },
                    new Folder
                    {
                        Name = $"{applicationName}.DOMAIN",
                        Files = new List<FileDto>
                        {
                            new FileDto { TemplateName = "DOMAIN.csproj.cshtml", FileNamePrefix = "", FileNameSufix = ".DOMAIN", FileExtension = ".csproj" , UseTableName = false, UseApplicationName = true}
                        },
                        GenerateSubFolderForEachTable = true,
                        SubFoldersOfSubFolders = new List<Folder>
                            {
                                new Folder
                                {
                                    Name = "Models",
                                    Files = new List<FileDto>{
                                        new FileDto { TemplateName = "Model.cshtml", FileNamePrefix = "", FileNameSufix = "", FileExtension = ".cs", UseTableName = true }
                                    }
                                },
                                new Folder
                                {
                                    Name = "Repositories",
                                    Files = new List<FileDto>{
                                        new FileDto { TemplateName = "IRepository.cshtml", FileNamePrefix = "I", FileNameSufix = "Repository", FileExtension = ".cs", UseTableName = true}
                                    }
                                },
                                new Folder
                                {
                                    Name = "Services",
                                    Files = new List<FileDto>{
                                        new FileDto { TemplateName = "IService.cshtml", FileNamePrefix = "I", FileNameSufix = "Service", FileExtension = ".cs", UseTableName = true}
                                    }
                                }
                            }
                    },
                    new Folder
                    {
                        Name = $"{applicationName}.CORE",
                        Files = new List<FileDto>
                        {
                            new FileDto { TemplateName = "CORE.csproj.cshtml", FileNamePrefix = "", FileNameSufix = ".CORE", FileExtension = ".csproj" , UseTableName = false, UseApplicationName = true}
                        },
                        SubFolders = new List<Folder>
                        {
                            new Folder
                            {
                                Name = "DataAccess",
                                Files = new List<FileDto>
                                {
                                    new FileDto { TemplateName = "DbContext.cshtml", FileNamePrefix = "", FileNameSufix = "DbContext", FileExtension = ".cs" , UseTableName = false, UseApplicationName = true}
                                },
                                SubFolders = new List<Folder>
                                {
                                    new Folder
                                    {
                                        Name = "Extensions",
                                        Files = new List<FileDto>{
                                            new FileDto { TemplateName = "DbContextExtensions.cshtml", FileNamePrefix = "", FileNameSufix = "", FileExtension = ".cs" , UseTableName = false, UseApplicationName = false}
                                        }
                                    },
                                },
                            }
                        },
                        GenerateSubFolderForEachTable = true,
                        SubFoldersOfSubFolders = new List<Folder>
                            {
                                new Folder
                                {
                                    Name = "Mapping",
                                    Files = new List<FileDto>{
                                        new FileDto { TemplateName = "ClassMap.cshtml", FileNamePrefix = "", FileNameSufix = "ClassMap", FileExtension = ".cs" , UseTableName = true}
                                    }
                                },
                                new Folder
                                {
                                    Name = "Repositories",
                                    Files = new List<FileDto>{
                                        new FileDto { TemplateName = "Repository.cshtml", FileNamePrefix = "", FileNameSufix = "Repository", FileExtension = ".cs", UseTableName = true}
                                    }
                                },
                                new Folder
                                {
                                    Name = "Services",
                                    Files = new List<FileDto>{
                                        new FileDto { TemplateName = "Service.cshtml", FileNamePrefix = "", FileNameSufix = "Service", FileExtension = ".cs", UseTableName = true}
                                    }
                                }
                            }
                    },
                    new Folder
                    {
                        Name = $"{applicationName}.INFRA",
                        Files = new List<FileDto>
                        {
                            new FileDto { TemplateName = "INFRA.csproj.cshtml", FileNamePrefix = "", FileNameSufix = ".INFRA", FileExtension = ".csproj" , UseTableName = false, UseApplicationName = true}
                        },
                        SubFolders = new List<Folder>
                        {
                            new Folder
                            {
                                Name = "Base",
                                SubFolders = new List<Folder>
                                {
                                    new Folder
                                    {
                                        Name = "Core",
                                        SubFolders = new List<Folder>
                                        {
                                            new Folder
                                            {
                                                Name = "Repositories",
                                                Files = new List<FileDto>{
                                                    new FileDto { TemplateName = "BaseRepository.cshtml", FileNamePrefix = "", FileNameSufix = "", FileExtension = ".cs", UseTableName = false}
                                                }
                                            },
                                            new Folder
                                            {
                                                Name = "Services",
                                                Files = new List<FileDto>{
                                                    new FileDto { TemplateName = "BaseService.cshtml", FileNamePrefix = "", FileNameSufix = "", FileExtension = ".cs", UseTableName = false}
                                                }
                                            }
                                        }
                                    },
                                    new Folder
                                    {
                                        Name = "Domain",
                                        SubFolders = new List<Folder>
                                        {
                                            new Folder
                                            {
                                                Name = "Repositories",
                                                Files = new List<FileDto>{
                                                    new FileDto { TemplateName = "IBaseRepository.cshtml", FileNamePrefix = "", FileNameSufix = "", FileExtension = ".cs", UseTableName = false}
                                                }
                                            },
                                            new Folder
                                            {
                                                Name = "Services",
                                                Files = new List<FileDto>{
                                                    new FileDto { TemplateName = "IBaseService.cshtml", FileNamePrefix = "", FileNameSufix = "", FileExtension = ".cs", UseTableName = false}
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        public Folder GetRootFolder(string applicationName)
        {
            DeclareFolders(applicationName);
            return Folder;
        }
    }
}