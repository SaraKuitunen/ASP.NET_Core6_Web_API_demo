using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        // injected fileExtensionContentTypeProvider is saved in field -> can be used
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(
            // Add fileExtensionContentTypeProvider as parameter for the constructor -> injected
            FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
                ?? throw new System.ArgumentNullException(
                    nameof(fileExtensionContentTypeProvider));
        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            /// look up the actual file
            // Properties of the file: set Copy to Output Directory to "Copy always" ->
            // can load it from the root dir because will be in the same place as the application is running from
            // var pathToFile = "ASP.NET Core Web APIs.md"; // hard coded for demo
            var pathToFile = "CleanArchitecture_JasonTaylor.pdf";

            /// Check whether the file exists
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            // call TryGetContentType to find the correct content type of the file
            if (!_fileExtensionContentTypeProvider.TryGetContentType(
                pathToFile, out var contentType))
            {
                // application/octet-stream is default media type for arbitrary binary data
                contentType = "application/octet-stream";
            }
            // read bytes 
            var bytes = System.IO.File.ReadAllBytes(pathToFile);

            // Pass through the File method the bytes, content type, and the path to the file name.
            // File method is defined on the ControllerBase
            // and it acts as a wrapper around the FileResult subclasses.
            // set content type to the resulting content type from FileExtensionContentTypeProvider.
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
