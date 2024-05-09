using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Models.Db
{
    public class Table
    {
        public int object_id { get; set; }
        public string name { get; set; }
        public string type_desc { get; set; }
        public virtual IList<Column> Columns { get; set; }
        public virtual IList<Relation> ParentRelations { get; set; }
        public virtual IList<Relation> RelatedRelations { get; set; }
    }
}
