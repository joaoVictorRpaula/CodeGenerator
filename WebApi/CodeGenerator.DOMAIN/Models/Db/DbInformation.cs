using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Models.Db
{
    public class DbInformation
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public Auth Auth { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
    }
}
