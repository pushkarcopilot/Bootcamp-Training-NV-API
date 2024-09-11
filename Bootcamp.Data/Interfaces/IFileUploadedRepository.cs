using Bootcamp.Data.Models;
using Microsoft.AspNetCore.Http;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Interfaces
{
    public interface IFileUploadedRepository
    {
        Task UploadFileAsync(IFormFile file);
        Task<DocumentDetails> DownloadFileAsync(int id);
        Task<List<DocumentDetails>> GetAllFilesAsync();
    }
}