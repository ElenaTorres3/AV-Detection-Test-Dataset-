using AVDetectionTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AVDetectionTest.Services
{
    public class FileService
    {
        public async Task<List<string>> GetFilesInDirectoryAsync(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException($"Directory not found: {directoryPath}");

            var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories)
                .Where(f => !f.EndsWith(".db") && !f.EndsWith(".log"))
                .ToList();

            return files;
        }

        public async Task<string> CalculateSha256Async(string filePath)
        {
            using var sha256 = SHA256.Create();
            using var stream = File.OpenRead(filePath);
            var hash = await sha256.ComputeHashAsync(stream);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
