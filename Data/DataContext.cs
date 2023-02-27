using FolderTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderTestApp.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<FolderEntity> Folders { get; set; }
        public DbSet<FileEntity> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileEntity>()
                .HasOne(f => f.Folder)
                .WithMany(p => p.Files)
                .HasForeignKey(f => f.FolderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FolderEntity>()
                .HasMany(p => p.SubFolders)
                .WithOne(p => p.ParentFolder)
                .HasForeignKey(p => p.ParentFolderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
