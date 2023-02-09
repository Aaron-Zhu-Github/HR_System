namespace HRSystem.Controllers
{
    using HRSystem.Models;
    using HRSystem.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [Route("/api/file/upload")]
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] FileModel model)
        {
            if (model.ImageFile != null)
            {
                await _fileService.Upload(model);
            }
            return Ok();
        }

        [Route("/api/file/get")]
        [HttpGet]
        public async Task<IActionResult> Get(string fileName)
        {
            var imgStream = await _fileService.Get(fileName);
            string fileType = "jpeg";
            if (fileName.Contains("png"))
            {
                fileType = "png";
            }
            return File(imgStream, $"image/{fileType}");
        }

        [Route("/api/file/download")]
        [HttpGet]
        public async Task<IActionResult> GetDownload(string fileName)
        {
            var imgStream = await _fileService.Get(fileName);
            string fileType = "jpeg";
            if (fileName.Contains("png"))
            {
                fileType = "png";
            }
            return File(imgStream, $"image/{fileType}", $"blobfile.{fileType}");
        }
    }
}
