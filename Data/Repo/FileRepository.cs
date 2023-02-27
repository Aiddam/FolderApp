using FolderTestApp.Interface;
using FolderTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderTestApp.Data.Repo
{
    public class FileRepository:IFileRepository
    {
        private readonly DataContext _dc;

        public FileRepository(DataContext dc)
        {
            _dc = dc;
        }

        public void CreateFile(FileEntity file)
        {
            _dc.Files.Add(file);
        }

        public async Task<FileEntity> GetFileAsync(string path)
        {
            return await _dc.Files.Where(f => f.Path == path).FirstOrDefaultAsync();
        }
    }
}
