using Shapes.Shared;
using System.Xml.Serialization;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

/*  This program is used to create a list of shapes, uses serialization
    to save it to the filesystem using XML, and then deserializes it back.
*/


List<Shape> listOfShapes = new()
{
    new Circle{ Colour = "Red", Radius = 2.5 },
    new Rectangle{ Colour = "Blue", Height = 20.0, Width = 10.0 },
    new Circle{ Colour = "Green", Radius = 8.0 },
    new Circle{ Colour = "Purple", Radius = 12.3 },
    new Rectangle{ Colour = "Blue", Height = 45.0, Width = 18.0 },
};


// create object that will format a list of Shapes as XML
XmlSerializer xmlSerializer = new(listOfShapes.GetType());

// create a file to write to
string path = Combine(CurrentDirectory, "shapes.xml");

// serialize the object graph to the stream
using (FileStream stream = File.Create(path))
{
    xmlSerializer.Serialize(stream, listOfShapes);
}

WriteLine("Written {0:N0} bytes of XML to {1}", arg0: new FileInfo(path).Length, arg1: path);
WriteLine();

// display the serialized object graph
WriteLine(File.ReadAllText(path));
WriteLine();

// deserializing the XML file - output the list of shapes, including their areas
WriteLine("Loading shapes from XML: ");

using (FileStream xmlFile = File.Open(path, FileMode.Open))
{
    // deserialize and cast the object graph into a list of Shape
    List<Shape>? loadedShapes =
        xmlSerializer.Deserialize(xmlFile) as List<Shape>; 

    if (loadedShapes != null)
    {
        foreach (var shape in loadedShapes)
        {
            WriteLine("{0} is {1} and has an area of {2:N2}",
                shape.GetType().Name, shape.Colour, shape.Area);
        }
    }    
}
