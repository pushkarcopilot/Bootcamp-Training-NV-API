using Bootcamp.Data.Context;
using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace Bootcamp.Data
{
    public class FileUploadedRepository : IFileUploadedRepository
    {
        private readonly EngagementDbContext _context;
        private readonly string[] permittedExtensions = { ".xls", ".xlsx", ".csv", ".doc", ".pdf" };

        public FileUploadedRepository(EngagementDbContext context)
        {
            _context = context;
        }

        public async Task UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is null or empty.");
            }

            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            var permittedExtensions = new[] { ".xls", ".xlsx", ".csv", ".doc", ".pdf" };

            if (!permittedExtensions.Contains(fileExtension))
            {
                throw new ArgumentException("Invalid file type. Only .xls, .xlsx, .csv, .doc, and .pdf files are allowed.");
            }

            // Read file content into a byte array
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var fileContent = memoryStream.ToArray();

                // Create a new file record
                var fileRecord = new DocumentDetails
                {
                    FileName = Path.GetFileName(file.FileName),
                    FileType = fileExtension,
                    UploadedAt = DateTime.UtcNow,
                    DataContentVarbinary = fileContent // Store the binary data
                };

                // Save the file record to the database
                _context.FileRecords.Add(fileRecord);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DocumentDetails> DownloadFileAsync(int id)
        {
            var fileRecord = await _context.FileRecords.FindAsync(id);

            if (fileRecord == null)
                throw new Exception("File not found.");

            // Ensure that DataContent is of type byte[] for binary data
            return new DocumentDetails
            {
                Id = fileRecord.Id,
                FileName = fileRecord.FileName,
                FileType = fileRecord.FileType,
                DataContentVarbinary = fileRecord.DataContentVarbinary // Use the correct field
            };
        }

        public async Task<List<DocumentDetails>> GetAllFilesAsync()
        {
            var documents = await _context.FileRecords
                .Select(d => new DocumentDetails
                {
                    Id = d.Id,
                    FileName = d.FileName,
                    FileType = d.FileType,
                    UploadedAt = d.UploadedAt,
                    DataContentVarbinary = d.DataContentVarbinary != null ? d.DataContentVarbinary : new byte[0]
                })
                .ToListAsync();

            return documents;
        }
    }
}

