using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Models
{
    public class LanguageType
    {
        public IList<string> Get()
        {
            return new List<string> {
                "CSharp",
                "Python",
                "Java",
                "TypeScript"
            };
        }
    }
}
