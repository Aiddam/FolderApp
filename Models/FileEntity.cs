namespace FolderTestApp.Models
{
    public class FileEntity:BaseEntity
    {
        public int FolderId { get; set; }
        public virtual FolderEntity Folder { get; set; }


    }
}
