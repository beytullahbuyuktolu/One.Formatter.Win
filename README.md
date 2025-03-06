# One.Formatter

One.Formatter is a simple Windows Forms application that formats JSON data and saves it to a specified directory.

## Features

- Format raw JSON or plain text input
- Support for Unicode characters including non-ASCII characters
- Automatic saving to C:/Teknosol directory
- Custom file naming
- Option to open the directory after saving

## Usage

1. Run the application
2. Enter a filename (the .json extension will be added automatically if not included)
3. Input the JSON data or plain text you want to format in the text area
4. Click the "Oluştur" (Create) button
5. Your JSON data will be formatted and saved to the C:/Teknosol folder
6. Choose "Yes" if you want to open the directory after saving

## Technical Details

- Windows Forms application built on .NET Framework
- Uses System.Text.Json library for JSON processing
- Implements UnsafeRelaxedJsonEscaping encoding option for proper Unicode character support

## Example

### Input:
```json
{"configurations":[{"name":"Development","connectionString":"Server=localhost;Database=DevDB;User Id=dev;Password=devPass;","environmentVariables":{"ASPNETCORE_ENVIRONMENT":"Development","LOG_LEVEL":"Debug"}}],"appSettings":{"apiVersion":"1.0.0","maxRequestLimit":100,"enableCache":true,"timeout":30}}
```

### Output:
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

### Plain Text to JSON Example

Input:
```
This is some plain text that will be converted to JSON
```

Output:
```json
{
  "text": "This is some plain text that will be converted to JSON"
}
```

## Code Example

The core formatting functionality uses System.Text.Json:

```csharp
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
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
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
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            
            return JsonSerializer.Serialize(jsonObject, options);
        }
        catch
        {
            throw new Exception("Invalid JSON format and failed to convert plain text to JSON.");
        }
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

This application was developed to address specific needs for JSON formatting with Unicode character support.

## License

[MIT](LICENSE) 