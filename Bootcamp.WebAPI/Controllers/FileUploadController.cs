using Bootcamp.Data.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
[EnableCors("AllowSpecificOrigins")] // Use the same policy name
public class FileUploadController : ControllerBase
{
    private readonly IFileUploadedRepository _fileUploadedRepository;

    public FileUploadController(IFileUploadedRepository fileUploadedRepository)
    {
        _fileUploadedRepository = fileUploadedRepository;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        try
        {
            // Call repository method to save the file
            await _fileUploadedRepository.UploadFileAsync(file);
            return Ok(new { Message = "File uploaded successfully" });
        }
        catch (Exception ex)
        {
            // Return error message in case of failure
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        }
    }


    [HttpGet("FileRecord")]
    public async Task<IActionResult> GetAllRecords()
    {
        var documents = await _fileUploadedRepository.GetAllFilesAsync();
        return Ok(documents);
    }

    [HttpGet("file/{id}")]
    public async Task<IActionResult> DownloadFile(int id)
    {
        var fileDto = await _fileUploadedRepository.DownloadFileAsync(id);

        if (fileDto == null)
            return NotFound("File not found.");

        if (fileDto.DataContentVarbinary == null || fileDto.DataContentVarbinary.Length == 0)
            return NotFound("File content is empty.");

        // Return the file with the correct content type and filename
        var contentType = GetContentType(fileDto.FileType);
        return File(fileDto.DataContentVarbinary, contentType, fileDto.FileName);
    }

    private string GetContentType(string fileType)
    {
        return fileType switch
        {
            ".xls" => "application/vnd.ms-excel",
            ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            ".csv" => "text/csv",
            ".doc" => "application/msword",
            ".pdf" => "application/pdf",
            _ => "application/octet-stream",
        };
    }
}
