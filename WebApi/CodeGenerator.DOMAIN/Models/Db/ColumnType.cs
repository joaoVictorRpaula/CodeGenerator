using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Models.Db
{
    public class ColumnType
    {
        public int user_type_id { get; set; }
        public string name { get; set; }
        public virtual IList<Column> Column { get; set; }
    }
}
