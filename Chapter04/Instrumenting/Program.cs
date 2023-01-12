using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;

/*
writing to a text file in the project folder.
it will be pass it into a new trace listener that knows how to write to a text file,
and enable automatic flushing for its buffer.
*/
Trace.Listeners.Add(new TextWriterTraceListener(
    File.CreateText(Path.Combine(Environment.CurrentDirectory, "log.txt"))));

Trace.Listeners.Add(new TextWriterTraceListener(
    File.CreateText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt"))));

// text writer is buffered, so this options calls
// Flush() on all listeners after writing
Trace.AutoFlush= true;

Debug.WriteLine("Debug says, I am watching!");
Trace.WriteLine("Trace says, I am watching!");

ConfigurationBuilder builder = new();

// looks in the current folder for a file named appsettings.json
builder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json",
    optional: true, reloadOnChange: true);

// build the configuration
IConfigurationRoot configuration = builder.Build();

// create a trace switch
TraceSwitch ts = new(
    displayName: "PacktSwitch",
    description: "This switch is set via a JSON config.");

// set its level by binding to the configuration
configuration.GetSection("PacktSwitch").Bind(ts);

// output the four trace switch levels
Trace.WriteLineIf(ts.TraceError, "Trace error");
Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
Trace.WriteLineIf(ts.TraceInfo, "Trace information");
Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");