using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FolderTestApp.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT Folders ON
                INSERT INTO Folders(Id, ParentFolderId, Name, Path)
                VALUES (1, null, 'root', 'root');

                INSERT INTO Folders (Id, ParentFolderId, Name, Path)
                VALUES (2, 1, 'Creating Digital Images', '/Creating Digital Images/');

                INSERT INTO Folders (Id, ParentFolderId, Name, Path)
                VALUES (3, 2, 'Resources', '/Creating Digital Images/Resources/');

                INSERT INTO Folders (Id, ParentFolderId, Name, Path)
                VALUES (4, 3, 'Primary Sources', '/Creating Digital Images/Resources/Primary Sources/');

                INSERT INTO Folders (Id, ParentFolderId, Name, Path)
                VALUES (5, 3, 'Secondary Sources', '/Creating Digital Images/Resources/Secondary Sources/');

                INSERT INTO Folders (Id, ParentFolderId, Name, Path)
                VALUES (6, 2, 'Evidence', '/Creating Digital Images/Evidence/');

                INSERT INTO Folders (Id, ParentFolderId, Name, Path)
                VALUES (7, 2, 'Grahpic Products', '/Creating Digital Images/Grahpic Products/');

                INSERT INTO Folders (Id, ParentFolderId, Name, Path)
                VALUES (8, 7, 'Proccess', '/Creating Digital Images/Grahpic Products/Proccess/');

                INSERT INTO Folders (Id, ParentFolderId, Name, Path)
                VALUES (9, 7, 'Final Product', '/Creating Digital Images/Grahpic Products/Final Product/');
                SET IDENTITY_INSERT Folders OFF 
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
