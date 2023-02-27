using FolderTestApp.Data.Repo;
using FolderTestApp.Interface;
using FolderTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static NuGet.Packaging.PackagingConstants;

namespace FolderTestApp.Controllers
{
    public class FolderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FolderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var all = await _unitOfWork.FolderRepository.GetAllFoldersAsync();
            return View(all.FirstOrDefault());
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(IFormFile[] files)
        {
            if (files == null)
                return BadRequest("You choose folder without files or so much files");
            FolderEntity rootFolder = await _unitOfWork.FolderRepository.GetRootFolderAsync();
            if (rootFolder == null)
            {
                rootFolder = new FolderEntity() { Name = "root", Path = "root" };
                _unitOfWork.FolderRepository.CreateFolder(rootFolder);
                await _unitOfWork.SaveAsync();
                rootFolder = await _unitOfWork.FolderRepository.GetFolderAsync(rootFolder.Path);
            }

            foreach (var file in files)
            {
                var fileName = file.FileName.Split("/");
                var folder = await _unitOfWork.FolderRepository.GetFolderAsync(Path.Combine("/", fileName[0]));
                if (folder == null)
                {
                    folder = new FolderEntity() { Name = fileName[0], Path = Path.Combine("/", fileName[0]), ParentFolder = rootFolder,ParentFolderId = rootFolder.Id };
                    _unitOfWork.FolderRepository.CreateFolder(folder);
                    await _unitOfWork.SaveAsync();
                    folder = await _unitOfWork.FolderRepository.GetFolderAsync(folder.Path);

                }
 
                foreach (var item in fileName)
                {
                    if (item == fileName[0])
                        continue;
                    if (fileName[^1] == item)
                    {
                        var file1 = await _unitOfWork.FileRepository.GetFileAsync(Path.Combine(folder.Path, item));

                        if (file1 == null)
                        {
                            file1 = new FileEntity() { Name = item, Path = Path.Combine(folder.Path, item), Folder = folder,FolderId = folder.Id };
                            _unitOfWork.FileRepository.CreateFile(file1);
                            await _unitOfWork.SaveAsync();
                            file1 = await _unitOfWork.FileRepository.GetFileAsync(file1.Path);
                        }
                        continue;

                    }
                    else
                    {
                        var parentFolder = await _unitOfWork.FolderRepository.GetFolderAsync(folder.Path);
                        folder = new FolderEntity() { Name = item, Path = Path.Combine(folder.Path, item), ParentFolder = parentFolder  };
                        var folder1 = await _unitOfWork.FolderRepository.GetFolderAsync(folder.Path);
                        if (folder1 == null)
                        {
                            _unitOfWork.FolderRepository.CreateFolder(folder);
                            await _unitOfWork.SaveAsync();
                            folder = await _unitOfWork.FolderRepository.GetFolderAsync(folder.Path);
                        }
                        else
                        {
                            folder = await _unitOfWork.FolderRepository.GetFolderAsync(folder.Path);
                            continue;
                        }
                    }
                    
                }

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
