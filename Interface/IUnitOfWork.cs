namespace FolderTestApp.Interface
{
    public interface IUnitOfWork
    {
        IFolderRepository FolderRepository { get; }
        IFileRepository FileRepository { get; }

        Task<bool> SaveAsync();
    }
}
