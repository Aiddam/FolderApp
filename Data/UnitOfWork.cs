
using FolderTestApp.Data.Repo;
using FolderTestApp.Interface;

namespace FolderTestApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dc;

        public UnitOfWork(DataContext dc)
        {
            _dc = dc;
        }

        public IFolderRepository FolderRepository => new FolderRepository(_dc);

        public IFileRepository FileRepository => new FileRepository(_dc);

        public async Task<bool> SaveAsync()
        {
            return await _dc.SaveChangesAsync() > 0;
        }
    }
}
