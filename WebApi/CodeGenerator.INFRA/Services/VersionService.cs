using CodeGenerator.DOMAIN.Interfaces;
using CodeGenerator.INFRA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.INFRA.Services
{
    public class VersionService : IVersionService
    {
        public IFolderService ResolveService(string serviceName)
        {
            var serviceType = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => typeof(IFolderService).IsAssignableFrom(t) && t.Name == serviceName);

            if (serviceType == null)
            {
                throw new ArgumentException($"Service with name '{serviceName}' not found.");
            }

            return Activator.CreateInstance(serviceType) as IFolderService;
        }
    }
}
