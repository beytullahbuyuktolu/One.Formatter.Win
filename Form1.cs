using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;

namespace One.Formatter;
public partial class Form1 : Form
{
    private readonly string saveDirectory = @"C:\Temporary";
    private enum FormatType
    {
        JSON,
        SQL,
        XML,
        CSV,
        PlainText
    }

    public Form1()
    {
        InitializeComponent();
        // Create save directory if it doesn't exist
        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }

        // Initialize format types combobox
        cboFormatType.Items.AddRange(Enum.GetNames(typeof(FormatType)));
        cboFormatType.SelectedIndex = 0; // Default to JSON
    }

    private void txtInput_TextChanged(object sender, EventArgs e)
    {
        try
        {
            // Get the selected format type
            FormatType selectedFormat = (FormatType)cboFormatType.SelectedIndex;

            // Update the input and output labels based on the selected format
            lblInputTitle.Text = $"{selectedFormat} Input";
            lblOutputTitle.Text = $"Formatted {selectedFormat}";

            // Format the text based on the selected format type
            string inputText = txtInput.Text;
            string formattedText = FormatText(inputText, selectedFormat);

            // Update the output text box
            txtOutput.Text = formattedText;
        }
        catch (Exception ex)
        {
            // If an error occurs, display it in the output text box
            txtOutput.Text = $"Error: {ex.Message}";
        }
    }

    private void btnFormat_Click(object sender, EventArgs e)
    {
        try
        {
            string inputText = txtInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Please enter text to format.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected format type
            FormatType formatType = (FormatType)Enum.Parse(typeof(FormatType), cboFormatType.SelectedItem.ToString());

            // Format based on the selected type
            string formattedText = FormatText(inputText, formatType);

            // Display formatted text in output textbox
            txtOutput.Text = formattedText;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtOutput.Text))
            {
                MessageBox.Show("There is no formatted text to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show file name controls
            lblFileName.Visible = true;
            txtFileName.Visible = true;

            // If filename is not already visible and filled, prompt user to enter filename
            if (string.IsNullOrWhiteSpace(txtFileName.Text))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    // Get selected format type
                    FormatType formatType = (FormatType)Enum.Parse(typeof(FormatType), cboFormatType.SelectedItem.ToString());

                    // Set appropriate file extension
                    string extension = GetFileExtension(formatType);
                    saveFileDialog.Filter = $"Format files (*{extension})|*{extension}|All files (*.*)|*.*";
                    saveFileDialog.DefaultExt = extension.TrimStart('.');
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.InitialDirectory = saveDirectory;
                    saveFileDialog.Title = "Save Formatted File";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Save the formatted text
                        File.WriteAllText(saveFileDialog.FileName, txtOutput.Text);
                        MessageBox.Show($"File successfully saved to: {saveFileDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Ask if user wants to open the directory
                        DialogResult openFolderResult = MessageBox.Show(
                            "Do you want to open the file directory?",
                            "Open Directory",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (openFolderResult == DialogResult.Yes)
                        {
                            string folderPath = Path.GetDirectoryName(saveFileDialog.FileName);
                            Process.Start("explorer.exe", folderPath);
                        }
                    }
                }
            }
            else
            {
                // User provided filename
                string fileName = txtFileName.Text.Trim();

                // Get selected format type
                FormatType formatType = (FormatType)Enum.Parse(typeof(FormatType), cboFormatType.SelectedItem.ToString());

                // Add appropriate extension if missing
                if (!Path.HasExtension(fileName))
                {
                    fileName += GetFileExtension(formatType);
                }

                // Create full file path
                string fullPath = Path.Combine(saveDirectory, fileName);

                // Check if file exists
                if (File.Exists(fullPath))
                {
                    DialogResult result = MessageBox.Show(
                        $"File {fileName} already exists. Do you want to overwrite it?",
                        "File Exists",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }

                // Save formatted text
                File.WriteAllText(fullPath, txtOutput.Text);

                // Show success message
                MessageBox.Show($"File successfully saved to: {fullPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ask if user wants to open the directory
                DialogResult openFolderResult = MessageBox.Show(
                    "Do you want to open the file directory?",
                    "Open Directory",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (openFolderResult == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", saveDirectory);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string FormatText(string inputText, FormatType formatType)
    {
        if (string.IsNullOrWhiteSpace(inputText))
            return string.Empty;

        try
        {
            switch (formatType)
            {
                case FormatType.JSON:
                    return FormatJson(inputText);
                case FormatType.SQL:
                    return FormatSql(inputText);
                case FormatType.XML:
                    return FormatXml(inputText);
                case FormatType.CSV:
                    return FormatCsv(inputText);
                case FormatType.PlainText:
                    return inputText; // No formatting for plain text
                default:
                    return inputText;
            }
        }
        catch (Exception ex)
        {
            // Return the error message instead of throwing
            return $"Error: {ex.Message}";
        }
    }

    private string GetFileExtension(FormatType formatType)
    {
        switch (formatType)
        {
            case FormatType.JSON:
                return ".json";
            case FormatType.SQL:
                return ".sql";
            case FormatType.XML:
                return ".xml";
            case FormatType.CSV:
                return ".csv";
            case FormatType.PlainText:
                return ".txt";
            default:
                return ".txt";
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
                throw new Exception("Invalid JSON format and failed to convert to JSON.");
            }
        }
    }

    private string FormatSql(string sqlString)
    {
        try
        {
            // Remove any XML tags if present - this is a common issue
            string cleanSql = System.Text.RegularExpressions.Regex.Replace(sqlString, "<[^>]*>", "");

            // Basic SQL formatting
            string formattedSql = cleanSql
                .Replace("SELECT", "\nSELECT")
                .Replace("FROM", "\nFROM")
                .Replace("WHERE", "\nWHERE")
                .Replace("AND", "\n  AND")
                .Replace("OR", "\n  OR")
                .Replace("ORDER BY", "\nORDER BY")
                .Replace("GROUP BY", "\nGROUP BY")
                .Replace("HAVING", "\nHAVING")
                .Replace("JOIN", "\nJOIN")
                .Replace("INNER JOIN", "\nINNER JOIN")
                .Replace("LEFT JOIN", "\nLEFT JOIN")
                .Replace("RIGHT JOIN", "\nRIGHT JOIN")
                .Replace("OUTER JOIN", "\nOUTER JOIN")
                .Replace("INSERT INTO", "\nINSERT INTO")
                .Replace("VALUES", "\nVALUES")
                .Replace("UPDATE", "\nUPDATE")
                .Replace("SET", "\nSET")
                .Replace("DELETE", "\nDELETE")
                .Replace("CREATE TABLE", "\nCREATE TABLE")
                .Replace("ALTER TABLE", "\nALTER TABLE")
                .Replace("DROP TABLE", "\nDROP TABLE")
                .Replace("CREATE INDEX", "\nCREATE INDEX")
                .Replace("DROP INDEX", "\nDROP INDEX")
                .Replace(";", ";\n");

            // Clean up any double newlines
            formattedSql = System.Text.RegularExpressions.Regex.Replace(formattedSql, "\n\n+", "\n");

            return formattedSql.Trim();
        }
        catch (Exception)
        {
            throw new Exception("Failed to format SQL. Please check your input.");
        }
    }

    private string FormatXml(string xmlString)
    {
        try
        {
            // First, clean up the input
            string cleanXml = xmlString.Trim();

            // If it doesn't start with XML declaration, add it
            if (!cleanXml.StartsWith("<?xml"))
            {
                cleanXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" + cleanXml;
            }

            // Load XML into XDocument
            XDocument xdoc = XDocument.Parse(cleanXml);

            // Create settings for formatting
            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "    ", // 4 spaces for indentation
                NewLineChars = "\n",
                NewLineHandling = NewLineHandling.Replace,
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };

            // Format the XML
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                xdoc.Save(writer);
            }

            return sb.ToString().Trim();
        }
        catch (XmlException)
        {
            try
            {
                // If parsing fails, try to wrap content in a root element
                string cleanXml = xmlString.Trim();
                cleanXml = "<root>" + cleanXml + "</root>";

                // Add XML declaration if missing
                if (!cleanXml.StartsWith("<?xml"))
                {
                    cleanXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" + cleanXml;
                }

                XDocument xdoc = XDocument.Parse(cleanXml);
                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "    ",
                    NewLineChars = "\n",
                    NewLineHandling = NewLineHandling.Replace,
                    OmitXmlDeclaration = false,
                    Encoding = Encoding.UTF8
                };

                StringBuilder sb = new StringBuilder();
                using (XmlWriter writer = XmlWriter.Create(sb, settings))
                {
                    xdoc.Save(writer);
                }

                return sb.ToString().Trim();
            }
            catch
            {
                throw new Exception("Invalid XML format. Please check your input.");
            }
        }
    }

    private string FormatCsv(string csvString)
    {
        try
        {
            // Basic CSV formatting - ensure consistency
            string[] lines = csvString.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            if (lines.Length == 0)
            {
                return csvString;
            }

            // Get columns from first row
            string[] headers = SplitCsvLine(lines[0]);
            int columnCount = headers.Length;

            // Create a formatted CSV with consistent columns
            StringBuilder sb = new StringBuilder();

            // Add headers
            sb.AppendLine(string.Join(",", headers.Select(h => FormatCsvField(h))));

            // Add data rows
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                string[] fields = SplitCsvLine(lines[i]);

                // Ensure each row has the same number of columns as the header
                string[] paddedFields = new string[columnCount];
                for (int j = 0; j < columnCount; j++)
                {
                    paddedFields[j] = j < fields.Length ? FormatCsvField(fields[j]) : "";
                }

                sb.AppendLine(string.Join(",", paddedFields));
            }

            return sb.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error formatting CSV: {ex.Message}");
        }
    }

    private string[] SplitCsvLine(string line)
    {
        // Simple CSV parsing - doesn't handle all edge cases
        List<string> result = new List<string>();
        bool inQuotes = false;
        StringBuilder field = new StringBuilder();

        foreach (char c in line)
        {
            if (c == '\"')
            {
                inQuotes = !inQuotes;
                field.Append(c);
            }
            else if (c == ',' && !inQuotes)
            {
                result.Add(field.ToString());
                field.Clear();
            }
            else
            {
                field.Append(c);
            }
        }

        // Add the last field
        result.Add(field.ToString());

        return result.ToArray();
    }

    private string FormatCsvField(string field)
    {
        // Remove existing quotes
        field = field.Trim();
        if (field.StartsWith("\"") && field.EndsWith("\""))
        {
            field = field.Substring(1, field.Length - 2);
        }

        // Quote fields that contain commas, quotes, or newlines
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
        {
            // Escape quotes by doubling them
            field = field.Replace("\"", "\"\"");
            field = $"\"{field}\"";
        }

        return field;
    }

    private void cboFormatType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // Get the selected format type
            FormatType selectedFormat = (FormatType)cboFormatType.SelectedIndex;

            // Update the input and output labels
            lblInputTitle.Text = $"{selectedFormat} Input";
            lblOutputTitle.Text = $"Formatted {selectedFormat}";

            // Trigger formatting of the current input text
            if (!string.IsNullOrEmpty(txtInput.Text))
            {
                string formattedText = FormatText(txtInput.Text, selectedFormat);
                txtOutput.Text = formattedText;
            }
        }
        catch (Exception ex)
        {
            txtOutput.Text = $"Error: {ex.Message}";
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // Any initialization code
        cboFormatType.SelectedIndex = 0; // Set default to JSON
    }
}