using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DOMAIN.Models
{
    public class Folder
    {
        public Folder()
        {
            SubFolders = new List<Folder>();
        }
        public string Name { get; set; }
        public string? Path { get; set; }
        public bool GenerateSubFolderForEachTable { get; set; }
        public IList<Folder> SubFolders { get; set; }
        public IList<Folder> SubFoldersOfSubFolders { get; set; }
        public IList<FileDto> Files { get; set; }
    }
}
