using CodeGenerator.DOMAIN.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Models
{
    public class CodeGeneratorDto
    {
        public ApplicationDto Application { get; set; }
        public Table Table { get; set; }
        public IList<Table> TableList { get; set; }
    }
}
