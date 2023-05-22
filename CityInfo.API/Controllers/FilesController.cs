using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            /// look up the actual file
            // Properties of the file: set Copy to Output Directory to "Copy always" ->
            // can load it from the root dir because will be in the same place as the application is running from
            var pathToFile = "ASP.NET Core Web APIs.md"; // hard coded for demo

            /// Check whether the file exists
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            // read bytes 
            var bytes = System.IO.File.ReadAllBytes(pathToFile);

            // Pass through the File method the bytes, content type, and the path to the file name.
            // File method is defined on the ControllerBase
            // and it acts as a wrapper around the FileResult subclasses
            return File(bytes, "text/plain", Path.GetFileName(pathToFile));
        }
    }
}
