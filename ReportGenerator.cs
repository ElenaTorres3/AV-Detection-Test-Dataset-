using AVDetectionTest.Models;
using AVDetectionTest.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVDetectionTest
{
    public class ReportGenerator
    {
        private readonly DatabaseService _dbService;

        public ReportGenerator()
        {
            _dbService = new DatabaseService();
        }

        public async Task<string> GenerateHtmlReportAsync()
        {
            var samples = await _dbService.GetAllSamplesAsync();
            var scanResults = await _dbService.GetRecentScanResultsAsync(1000);
            
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html><head><title>AV Detection Test Report</title>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: Arial, sans-serif; margin: 20px; }");
            sb.AppendLine("table { border-collapse: collapse; width: 100%; }");
            sb.AppendLine("th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }");
            sb.AppendLine("th { background-color: #f2f2f2; }");
            sb.AppendLine(".detected { color: red; font-weight: bold; }");
            sb.AppendLine(".clean { color: green; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head><body>");
            
            sb.AppendLine("<h1>Antivirus Detection Test Report</h1>");
            sb.AppendLine($"<p>Generated on: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC</p>");
            
            // Summary
            var totalSamples = samples.Count;
            var totalScans = scanResults.Count;
            var detectionRate = totalScans > 0 ? 
                (double)scanResults.Count(sr => sr.Detected) / totalScans * 100 : 0;
            
            sb.AppendLine("<h2>Summary</h2>");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr><th>Metric</th><th>Value</th></tr>");
            sb.AppendLine($"<tr><td>Total Samples</td><td>{totalSamples}</td></tr>");
            sb.AppendLine($"<tr><td>Total Scan Results</td><td>{totalScans}</td></tr>");
            sb.AppendLine($"<tr><td>Detection Rate</td><td>{detectionRate:F2}%</td></tr>");
            sb.AppendLine("</table>");
            
            // Scan Results Table
            sb.AppendLine("<h2>Scan Results</h2>");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr><th>Sample</th><th>AV Product</th><th>Detected</th><th>Detection Name</th><th>Scan Time (ms)</th></tr>");
            
            foreach (var result in scanResults.OrderByDescending(sr => sr.ScanDate).Take(50))
            {
                var sample = samples.FirstOrDefault(s => s.Id == result.SampleId);
                var detectedClass = result.Detected ? "detected" : "clean";
                var detectedText = result.Detected ? "YES" : "NO";
                
                sb.AppendLine("<tr>");
                sb.AppendLine($"<td>{sample?.FileName ?? "Unknown"}</td>");
                sb.AppendLine($"<td>{result.AntivirusName}</td>");
                sb.AppendLine($"<td class='{detectedClass}'>{detectedText}</td>");
                sb.AppendLine($"<td>{result.DetectionName}</td>");
                sb.AppendLine($"<td>{result.ScanDurationMs:F0}</td>");
                sb.AppendLine("</tr>");
            }
            
            sb.AppendLine("</table>");
            sb.AppendLine("</body></html>");
            
            return sb.ToString();
        }

        public async Task SaveReportAsync(string filePath)
        {
            var htmlReport = await GenerateHtmlReportAsync();
            await File.WriteAllTextAsync(filePath, htmlReport);
        }
    }
}
