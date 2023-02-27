using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FolderTestApp.Models
{
    public class FolderEntity:BaseEntity
    {
        public int? ParentFolderId { get; set; }
        public virtual FolderEntity? ParentFolder { get; set; }
        public virtual ICollection<FolderEntity>? SubFolders { get; set; }
        public virtual ICollection<FileEntity>? Files { get; set; }

        public FolderEntity()
        {
            SubFolders= new List<FolderEntity>();
            Files= new List<FileEntity>();
        }



    }
}
