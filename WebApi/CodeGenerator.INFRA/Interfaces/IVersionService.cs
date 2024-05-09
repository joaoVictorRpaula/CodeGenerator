using CodeGenerator.DOMAIN.Interfaces;
using CodeGenerator.DOMAIN.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.INFRA.Interfaces
{
    public interface IVersionService
    {
        IFolderService ResolveService(string serviceName);
    }
}
