using FolderTestApp.Interface;
using FolderTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderTestApp.Data.Repo
{
    public class FolderRepository : IFolderRepository
    {
        private readonly DataContext _dc;

        public FolderRepository(DataContext dc)
        {
            _dc = dc;
        }

        public void AddFile(FolderEntity parentFolder, FileEntity file)
        {
            _dc.Files.Add(file);
        }


        public void CreateFolder(FolderEntity folder)
        {
            _dc.Folders.Add(folder);
        }

        public async Task<IEnumerable<FolderEntity>> GetAllFoldersAsync()
        {
            return await _dc.Folders.Include(f=>f.Files).Include(s=>s.SubFolders).ToListAsync();
        }


        public async Task<FolderEntity> GetFolderAsync(string path)
        {
            return await _dc.Folders.FirstOrDefaultAsync(f => f.Path == path);
        }

        public async Task<FolderEntity> GetRootFolderAsync()
        {
            return await _dc.Folders.Include(f => f.SubFolders).Include(f => f.Files).FirstOrDefaultAsync(f=>f.Path == "root");
        }
    }
}
