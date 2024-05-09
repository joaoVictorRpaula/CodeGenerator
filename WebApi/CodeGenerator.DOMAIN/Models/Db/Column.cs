using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Models.Db
{
    public class Column
    {
        public int column_id { get; set; }
        public int object_id { get; set; }
        public string name { get; set; }
        public short max_length { get; set; }
        public bool is_nullable { get; set; }
        public bool is_identity { get; set; }
        [Column(TypeName = "TinyInt")]
        public int system_type_id { get; set; }
        public virtual Table Table { get; set; }
        public virtual ColumnType ColumnType { get; set; }
        public virtual IList<Relation> ParentRelations { get; set; }
        public virtual IList<Relation> RelatedRelations { get; set; }
    }
}
