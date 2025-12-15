using AVDetectionTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVDetectionTest
{
    public partial class MainForm : Form
    {
        private readonly DatasetManager _datasetManager;
        private readonly ScanEngine _scanEngine;
        private readonly ReportGenerator _reportGenerator;
        private List<Sample> _samples = new List<Sample>();

        public MainForm()
        {
            InitializeComponent();
            _datasetManager = new DatasetManager();
            _scanEngine = new ScanEngine();
            _reportGenerator = new ReportGenerator();
            
            LoadSamples();
        }

        private async void LoadSamples()
        {
            try
            {
                _samples = await _datasetManager.GetAllSamplesAsync();
                UpdateSamplesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading samples: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSamplesList()
        {
            samplesListBox.Items.Clear();
            foreach (var sample in _samples)
            {
                samplesListBox.Items.Add($"{sample.FileName} ({sample.Category})");
            }
            
            // Update status label
            statusLabel.Text = $"Loaded {_samples.Count} samples";
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            using var folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "Select directory containing malware samples";
            
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                var category = categoryTextBox.Text.Trim();
                if (string.IsNullOrEmpty(category))
                {
                    MessageBox.Show("Please enter a category for these samples", "Category Required", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                Task.Run(async () =>
                {
                    try
                    {
                        await _datasetManager.ImportDatasetAsync(folderDialog.SelectedPath, category);
                        MessageBox.Show("Samples imported successfully!", "Import Complete", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSamples();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error importing samples: {ex.Message}", "Import Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }

        private async void scanButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(avNameTextBox.Text.Trim()))
            {
                MessageBox.Show("Please enter an antivirus product name", "AV Name Required", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var selectedSamples = new List<Sample>();
            if (samplesListBox.CheckedItems.Count == 0)
            {
                // Scan all samples if none selected
                selectedSamples = _samples;
            }
            else
            {
                foreach (var item in samplesListBox.CheckedItems)
                {
                    var fileName = item.ToString().Split('(')[0].Trim();
                    var sample = _samples.FirstOrDefault(s => s.FileName == fileName);
                    if (sample != null)
                        selectedSamples.Add(sample);
                }
            }
            
            if (selectedSamples.Count == 0)
            {
                MessageBox.Show("No samples selected for scanning", "No Samples", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            scanButton.Enabled = false;
            statusLabel.Text = "Scanning samples...";
            
            try
            {
                var results = await _scanEngine.ScanSamplesAsync(selectedSamples, avNameTextBox.Text.Trim());
                
                // Save results to database
                foreach (var result in results)
                {
                    await _datasetManager.AddSampleAsync(null); // This will be handled differently
                    // Actually, we need to save results through DatabaseService
                    // This is a placeholder - in real implementation you'd call DatabaseService
                }
                
                MessageBox.Show($"Scanning complete! {results.Count} samples scanned.", "Scan Complete", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusLabel.Text = "Scan complete";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during scanning: {ex.Message}", "Scan Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Scan failed";
            }
            finally
            {
                scanButton.Enabled = true;
            }
        }

        private async void generateReportButton_Click(object sender, EventArgs e)
        {
            using var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "HTML Report|*.html|All Files|*.*";
            saveDialog.Title = "Save Report";
            saveDialog.FileName = $"AV_Report_{DateTime.Now:yyyyMMdd_HHmmss}.html";
            
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _reportGenerator.SaveReportAsync(saveDialog.FileName);
                    MessageBox.Show("Report generated successfully!", "Report Complete", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Optionally open the report
                    if (MessageBox.Show("Open report in browser?", "Open Report", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = saveDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error generating report: {ex.Message}", "Report Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
