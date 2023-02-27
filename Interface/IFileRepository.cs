using FolderTestApp.Models;

namespace FolderTestApp.Interface
{
    public interface IFileRepository
    {
        void CreateFile(FileEntity file);
        Task<FileEntity> GetFileAsync(string path);
    }
}
