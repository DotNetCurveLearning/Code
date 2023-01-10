using static System.Console;
using System.Diagnostics;

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