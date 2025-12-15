using AVDetectionTest.Models;
using AVDetectionTest.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVDetectionTest
{
    public class ScanEngine
    {
        private readonly DatabaseService _dbService;
        private readonly string _tempDirectory;

        public ScanEngine()
        {
            _dbService = new DatabaseService();
            _tempDirectory = Path.Combine(Path.GetTempPath(), "AVTest");
            Directory.CreateDirectory(_tempDirectory);
        }

        public async Task<List<ScanResult>> ScanSamplesAsync(List<Sample> samples, string antivirusName)
        {
            var results = new List<ScanResult>();
            
            foreach (var sample in samples)
            {
                // Create a copy of the sample in temp directory
                var tempFile = Path.Combine(_tempDirectory, sample.FileName);
                
                try
                {
                    // For demonstration, we'll create a file with EICAR test string
                    // In a real scenario, you'd copy the actual malware sample
                    File.WriteAllText(tempFile, GetEicarTestString());
                    
                    var result = await ScanFileAsync(tempFile, antivirusName, sample.Id);
                    results.Add(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error scanning {sample.FileName}: {ex.Message}", "Scan Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    results.Add(new ScanResult
                    {
                        SampleId = sample.Id,
                        AntivirusName = antivirusName,
                        Detected = false,
                        DetectionName = "Scan Error",
                        ScanDurationMs = 0
                    });
                }
                finally
                {
                    // Clean up temp file
                    if (File.Exists(tempFile))
                        File.Delete(tempFile);
                }
            }
            
            return results;
        }

        private async Task<ScanResult> ScanFileAsync(string filePath, string antivirusName, int sampleId)
        {
            var stopwatch = Stopwatch.StartNew();
            
            try
            {
                // Simulate scanning by checking if file contains EICAR test string
                var content = await File.ReadAllTextAsync(filePath);
                var detected = content.Contains("EICAR");
                
                stopwatch.Stop();
                
                return new ScanResult
                {
                    SampleId = sampleId,
                    AntivirusName = antivirusName,
                    Detected = detected,
                    DetectionName = detected ? "EICAR-Test-File" : "Clean",
                    ScanDurationMs = stopwatch.ElapsedMilliseconds
                };
            }
            catch (Exception)
            {
                stopwatch.Stop();
                throw;
            }
        }

        private string GetEicarTestString()
        {
            // EICAR test file string - safe to use for testing
            return @"X5O!P%@AP[4\PZX54(P^)7CC)7}$EICAR-STANDARD-ANTIVIRUS-TEST-FILE!$H+H*";
        }
    }
}
