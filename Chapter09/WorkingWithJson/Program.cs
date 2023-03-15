using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.Text.Json; // JsonSerializer
using System.Text.Json.Serialization;   // [JsonInclude]
using Microsoft.VisualBasic;
using WorkingWithJson;


// creating an instance of Book class and serialize it to JSON
Book csharp10 = new(title: "C# 10 and .NET 6 - Modern Cross-platform Development")
{
    Author = "Mark J Price",
    PublishDate = new(year: 2021, month: 11, day: 9),
    Pages = 823,
    Created = DateTimeOffset.UtcNow
};

JsonSerializerOptions options = new()
{
    IncludeFields = true,   // include all fields
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};


string filePath = Combine(CurrentDirectory, "book.json");

using (Stream fileStream = File.Create(filePath))
{
    JsonSerializer.Serialize<Book>(
        utf8Json: fileStream,
        value: csharp10,
        options
    );
}

WriteLine("Written {0:N0} bytes of JSON to: {1}", new FileInfo(filePath).Length, filePath);
WriteLine();

// display the serialized object graph
WriteLine(File.ReadAllText(filePath));

public class Book
{
    #region Properties
    public string Title { get; set; }
	public string? Author { get; set; }
    #endregion

    #region Fields
    // custom converter used for DateOnly fields to avoid serialization/deserialization issues
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly PublishDate;
    
    [JsonInclude]
    public DateTimeOffset Created;

    public ushort Pages;
    #endregion

    #region Constructors
    public Book(string title)
	{
		Title = title;
	}
    #endregion
}

