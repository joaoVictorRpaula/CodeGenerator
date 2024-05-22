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
    public class TemplateService : ITemplateService
    {
        public List<string> GetAllTemplates()
        {
            var templatesName = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(IFolderService).IsAssignableFrom(t))
                .Select(x => x.Name)
                .ToList();

            return templatesName;
        }

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
