# One.Formatter

One.Formatter is a versatile Windows Forms application that formats and saves multiple types of structured data formats with real-time preview.

## Features

- Real-time formatting preview with dual-panel interface
- Format and beautify various data formats:
  - JSON
  - SQL
  - XML
  - CSV
  - Plain Text
- Support for Unicode characters including non-ASCII characters
- Automatic saving to C:/Teknosol directory
- Custom file naming
- Option to open the directory after saving

## Usage

1. Run the application
2. Select the format type from the dropdown menu
3. Enter your data in the left panel
4. See the formatted output in real-time in the right panel
5. Click "Format" to explicitly format complex inputs if needed
6. Click "Save" to save the formatted output
7. Enter a filename or use the save dialog
8. Choose "Yes" if you want to open the directory after saving

## Interface

The application features a dual-panel interface:
- Left panel: Input data in raw format
- Right panel: Preview of formatted output in real-time
- Format selection dropdown at the top
- Format and Save buttons at the bottom

## Technical Details

- Windows Forms application built on .NET Framework
- Uses System.Text.Json library for JSON processing
- Uses regex-based formatting for SQL queries
- Uses XDocument for XML formatting
- Implements UnsafeRelaxedJsonEscaping encoding option for proper Unicode character support
- TextChanged event handling for real-time preview

## Examples

### JSON Example:

**Input:**
```json
{"configurations":[{"name":"Development","connectionString":"Server=localhost;Database=DevDB;User Id=dev;Password=devPass;","environmentVariables":{"ASPNETCORE_ENVIRONMENT":"Development","LOG_LEVEL":"Debug"}}],"appSettings":{"apiVersion":"1.0.0","maxRequestLimit":100,"enableCache":true,"timeout":30}}
```

**Output:**
```json
{
  "configurations": [
    {
      "name": "Development",
      "connectionString": "Server=localhost;Database=DevDB;User Id=dev;Password=devPass;",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "LOG_LEVEL": "Debug"
      }
    }
  ],
  "appSettings": {
    "apiVersion": "1.0.0",
    "maxRequestLimit": 100,
    "enableCache": true,
    "timeout": 30
  }
}
```

### SQL Example:

**Input:**
```sql
select id, first_name, last_name, email from users where status='active' and last_login > '2023-01-01' order by last_name asc
```

**Output:**
```sql
SELECT
    id,
    first_name,
    last_name,
    email
FROM
    users
WHERE
    status='active'
    AND last_login > '2023-01-01'
ORDER BY
    last_name ASC
```

### XML Example:

**Input:**
```xml
<root><person id="1"><name>John Doe</name><email>john@example.com</email><address><street>123 Main St</street><city>Anytown</city></address></person></root>
```

**Output:**
```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <person id="1">
    <name>John Doe</name>
    <email>john@example.com</email>
    <address>
      <street>123 Main St</street>
      <city>Anytown</city>
    </address>
  </person>
</root>
```

## Key Code Snippets

### Real-time Formatting with TextChanged Event

```csharp
private void txtInput_TextChanged(object sender, EventArgs e)
{
    try
    {
        // Don't try to format if the input is empty
        if (string.IsNullOrWhiteSpace(txtInput.Text))
        {
            txtOutput.Text = string.Empty;
            return;
        }

        // Get selected format type
        FormatType formatType = (FormatType)Enum.Parse(typeof(FormatType), cboFormatType.SelectedItem.ToString());

        // Format the text and show in output
        string formattedText = FormatText(txtInput.Text, formatType);
        txtOutput.Text = formattedText;
    }
    catch (Exception)
    {
        // Ignore errors during real-time formatting
        // This prevents exception popups when typing invalid syntax
    }
}
```

## Installation

1. Build the project
2. Run the generated One.Formatter.exe file

## Requirements

- .NET Framework 4.7.2 or higher
- Windows 7 or newer

## Development

This application was developed to address specific needs for formatting different types of data with Unicode character support and real-time preview.

## License

[MIT](LICENSE) 