using AVDetectionTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AVDetectionTest.Services
{
    public class DatabaseService
    {
        private readonly Dataset _context;

        public DatabaseService()
        {
            _context = new Dataset();
            _context.Database.EnsureCreated();
        }

        public async Task<List<Sample>> GetAllSamplesAsync()
        {
            return await _context.Samples.ToListAsync();
        }

        public async Task AddSampleAsync(Sample sample)
        {
            _context.Samples.Add(sample);
            await _context.SaveChangesAsync();
        }

        public async Task AddScanResultAsync(ScanResult result)
        {
            _context.ScanResults.Add(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ScanResult>> GetScanResultsForSampleAsync(int sampleId)
        {
            return await _context.ScanResults
                .Where(sr => sr.SampleId == sampleId)
                .ToListAsync();
        }

        public async Task<List<ScanResult>> GetRecentScanResultsAsync(int count = 100)
        {
            return await _context.ScanResults
                .OrderByDescending(sr => sr.ScanDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<Sample>> GetSamplesByCategoryAsync(string category)
        {
            return await _context.Samples
                .Where(s => s.Category == category)
                .ToListAsync();
        }

        public string CalculateSha256(string filePath)
        {
            using var sha256 = SHA256.Create();
            using var stream = File.OpenRead(filePath);
            var hash = sha256.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
