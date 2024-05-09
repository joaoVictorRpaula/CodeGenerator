using CodeGenerator.DOMAIN.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Models
{
    public class ApplicationDto
    {
        public string ApplicationName { get; set; }
        public string Path { get; set; }
        public string ApiVersion { get; set; }
        public DbInformation DbInformation { get; set; }
    }
}
