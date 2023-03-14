using static System.Console;
using static System.Environment;
using static System.IO.Path;
using Packt.Shared;
using System.Xml.Serialization; // XMLSerializer
using System.Text;

// creating an object graph of Person instances
List<Person> people = new()
{
    new(3000M)
    {
        FirstName = "Alice",
        LastName = "Smith",
        DateOfBirth = new(1974, 3, 14)
    },
    new(4000M)
    {
        FirstName = "Bob",
        LastName = "Jones",
        DateOfBirth = new(1969, 11, 23)
    },
    new(20000M)
    {
        FirstName = "Charlie",
        LastName = "Cox",
        DateOfBirth = new(1984, 5, 4),
        Children = new()
        {
            new(0M)
            {
                FirstName = "Sally",
                LastName = "Cox",
                DateOfBirth = new(2000, 7, 12)
            }
        }
    }
};

// create object that will format a list of Persons as XML
XmlSerializer xmlSerializer = new(people.GetType());

// create a file to write to
string path = Combine(CurrentDirectory, "people.xml");

using (FileStream stream = File.Create(path))
{
    // serialize the object graph to the stream
    xmlSerializer.Serialize(stream, people);
}
WriteLine("Written {0:N0} bytes of XML to {1}", arg0: new FileInfo(path).Length, arg1: path);
WriteLine();

// display the serialized object graph
WriteLine(File.ReadAllText(path));




