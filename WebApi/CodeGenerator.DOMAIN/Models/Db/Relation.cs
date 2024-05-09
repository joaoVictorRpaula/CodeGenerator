using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Models.Db
{
    public class Relation
    {
        public int constraint_object_id { get; set; }
        public int parent_object_id { get; set; }
        public int parent_column_id { get; set; }
        public int referenced_object_id { get; set; }
        public int referenced_column_id { get; set; }
        public virtual Table ParentTable { get; set; }
        public virtual Table RelatedTable { get; set; }
        public virtual Column ParentColumn { get; set; }
        public virtual Column RelatedColumn { get; set; }
    }
}
