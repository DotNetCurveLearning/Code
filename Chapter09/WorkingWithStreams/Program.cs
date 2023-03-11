using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

// WorkWithText();
WorkWithXml();

static void WorkWithText()
{
    // define a file to write to
    string textFile = Combine(CurrentDirectory, "streams.txt");

    // create a text file and return a helper writer
    StreamWriter text = File.CreateText(textFile);

    // enumerate the strings, writing each one
    // to the stream on a separate line
    using (text)
    {
        foreach (string item in Viper.Callsigns)
        {
            text.WriteLine(item);
        }
    }

    // output the contents of the file
    WriteLine("{0} contains {1:N0} bytes.",
        arg0: textFile,
        arg1: new FileInfo(textFile).Length);

    WriteLine(File.ReadAllText(textFile));
}

static void WorkWithXml()
{
    // define a file to write to
    string xmlFile = Combine(CurrentDirectory, "streams.xml");

    // create a file stream
    FileStream xmlWFileStream = File.Create(xmlFile);

    using (xmlWFileStream)
    {
        // wrap the file stream in an XML writer helper
        // and automatically indent nested element
        using (XmlWriter xml = XmlWriter.Create(xmlWFileStream, new XmlWriterSettings { Indent = true }))
        {
            // write the XML declaration
            xml.WriteStartDocument();

            // write a root element
            xml.WriteStartElement("callsigns");

            // enumerate the strings writing each one to the stream
            foreach (string item in Viper.Callsigns)
            {
                xml.WriteElementString("callsign", item);
            }

            // write the close root element
            xml.WriteEndElement();
        }
    }

    // output all the contents of the file
    WriteLine("{0} contains {1:N0} bytes.",
        arg0: xmlFile,
        arg1: new FileInfo(xmlFile).Length);

    WriteLine(File.ReadAllText(xmlFile));
}
static class Viper
{
    // define an array of Viper pilot call signs
    public static string[] Callsigns = new[]
    {
        "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog",
        "Athena", "Helo", "Racetrack"
    };
}
