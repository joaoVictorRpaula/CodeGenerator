using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Models.Db
{
    public class IndexColumns
    {
        public int index_column_id { get; set; }
        public int object_id { get; set; }
        public int index_id { get; set; }
        public int column_id { get; set; }
        public virtual Indexes Indexes { get; set; }
        public virtual Column Column { get; set; }
    }
}
