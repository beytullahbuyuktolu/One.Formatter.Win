using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Diagnostics;

namespace One.Formatter;
public partial class Form1 : Form
{
    private readonly string saveDirectory = @"C:\Temporary";
    public Form1()
    {
        InitializeComponent();
        // Create save directory if it doesn't exist
        if (!Directory.Exists(saveDirectory))
            Directory.CreateDirectory(saveDirectory);
    }
    private void btnFormat_Click(object sender, EventArgs e)
    {
        try
        {
            string inputText = txtInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Please enter JSON text to format.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // File name validation
            string fileName = txtFileName.Text.Trim();
            if (string.IsNullOrWhiteSpace(fileName))
            {
                MessageBox.Show("Please enter a file name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add .json extension if missing
            if (!fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                fileName += ".json";
            // Format the JSON
            string formattedJson = FormatJson(inputText);
            // Create full file path
            string fullPath = Path.Combine(saveDirectory, fileName);
            // Check if file exists
            if (File.Exists(fullPath))
            {
                DialogResult result = MessageBox.Show($"File {fileName} already exists. Do you want to overwrite it?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }
            // Save formatted JSON
            File.WriteAllText(fullPath, formattedJson);
            // Show success message
            MessageBox.Show($"JSON successfully saved to: {fullPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Ask if user wants to open the directory
            DialogResult openFolderResult = MessageBox.Show("Do you want to open the file directory?", "Open Directory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (openFolderResult == DialogResult.Yes)
                Process.Start("explorer.exe", saveDirectory);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private string FormatJson(string jsonString)
    {
        try
        {
            // Parse the JSON input
            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // For proper Unicode character support
                };

                return JsonSerializer.Serialize(document, options);
            }
        }
        catch (JsonException)
        {
            // If not valid JSON, try to convert the string to JSON
            try
            {
                // Convert to a simple JSON object
                var jsonObject = new { text = jsonString };
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // For proper Unicode character support
                };

                return JsonSerializer.Serialize(jsonObject, options);
            }
            catch
            {
                throw new Exception("Invalid JSON format and failed to convert plain text to JSON.");
            }
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
}