using FolderTestApp.Models;

namespace FolderTestApp.Interface
{
    public interface IFolderRepository
    {
        void CreateFolder(FolderEntity folder);
        Task<FolderEntity> GetFolderAsync(string path);
        void AddFile(FolderEntity parentFolder, FileEntity file);
        Task<IEnumerable<FolderEntity>> GetAllFoldersAsync();
        Task<FolderEntity> GetRootFolderAsync();
    }
}
