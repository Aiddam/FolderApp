namespace FolderTestApp.Models
{
    public class FolderViewModel
    {
        public string Name { get; set; }
        public List<FolderViewModel> SubFolders { get; set; }
        public ICollection<FileEntity> Files { get; set; }
        public bool IsExpanded { get; set; }

        public FolderViewModel()
        {
            SubFolders = new List<FolderViewModel>();
            Files = new List<FileEntity>();
            IsExpanded = false;
        }
        public FolderViewModel(FolderEntity folder)
        {
            Name= folder.Name;
            SubFolders = new List<FolderViewModel>();
            Files = folder.Files;
        }
    }
}
