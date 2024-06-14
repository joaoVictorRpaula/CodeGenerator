using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Models.Db
{
    public class Indexes
    {
        public int object_id { get; set; }
        public int index_id { get; set; }
        public bool is_primary_key { get; set; }
        public virtual IList<IndexColumns> IndexColumns { get; set; }
    }
}
