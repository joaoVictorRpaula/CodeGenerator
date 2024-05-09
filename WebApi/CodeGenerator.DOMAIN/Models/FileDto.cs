using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Models
{
    public class FileDto
    {
        public string TemplateName { get; set; }
        public string FileNamePrefix { get; set; }
        public string FileNameSufix { get; set; }
        public string FileExtension { get; set; }
        public bool UseTableName { get; set; }
        public bool UseTableListParameter { get; set; }
        public bool UseApplicationName { get; set; }
        public bool GenerateFileForEachTable { get; set; }
    }
}
