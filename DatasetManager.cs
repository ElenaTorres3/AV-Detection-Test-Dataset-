using AVDetectionTest.Models;
using AVDetectionTest.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVDetectionTest
{
    public class DatasetManager
    {
        private readonly DatabaseService _dbService;
        private readonly FileService _fileService;

        public DatasetManager()
        {
            _dbService = new DatabaseService();
            _fileService = new FileService();
        }

        public async Task ImportDatasetAsync(string directoryPath, string category)
        {
            var files = await _fileService.GetFilesInDirectoryAsync(directoryPath);
            
            foreach (var file in files)
            {
                try
                {
                    var sha256 = await _fileService.CalculateSha256Async(file);
                    var fileName = Path.GetFileName(file);
                    
                    // Check if sample already exists
                    var existingSample = await _dbService.GetAllSamplesAsync();
                    if (existingSample.Any(s => s.Sha256Hash == sha256))
                        continue;
                    
                    var sample = new Sample
                    {
                        FileName = fileName,
                        Sha256Hash = sha256,
                        Category = category,
                        Description = $"Imported from {directoryPath}"
                    };
                    
                    await _dbService.AddSampleAsync(sample);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error importing {file}: {ex.Message}", "Import Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async Task<List<Sample>> GetAllSamplesAsync()
        {
            return await _dbService.GetAllSamplesAsync();
        }

        public async Task<List<Sample>> GetSamplesByCategoryAsync(string category)
        {
            return await _dbService.GetSamplesByCategoryAsync(category);
        }
    }
}
