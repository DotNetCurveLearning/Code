﻿using static System.Console;
using static System.Environment;
using static System.IO.Path;
using Packt.Shared;
using System.Xml.Serialization; // XMLSerializer
using Newtonsoft.Json;
using NewJson = System.Text.Json.JsonSerializer;

//SerializeAndDeserializeFilesAsXml();
SerializeAndDeserializeFilesAsJson();

string jsonPath;
static List<Person> CreatePersonList()
{
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

    return people;
}

static void SerializeAndDeserializeFilesAsXml()
{
    var people = CreatePersonList();

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


    // deserializing the XML file
    using (FileStream xmlLoad = File.Open(path, FileMode.Open))
    {
        // deserialize and cast the object graph into a list of Person
        List<Person>? loadedPeople =
            xmlSerializer.Deserialize(xmlLoad) as List<Person>;

        if (loadedPeople is not null)
        {
            foreach (Person p in loadedPeople)
            {
                WriteLine("{0} has {1} children", p.LastName, p.Children?.Count ?? 0);
            }
        }
    }
}

static async void SerializeAndDeserializeFilesAsJson()
{
    var people = CreatePersonList();

    // create a file to write to
    string jsonPath = Combine(CurrentDirectory, "people.json");

    using (StreamWriter jsonStream = File.CreateText(jsonPath))
    {
        // create an object that will format as JSON
        JsonSerializer jsonSerializer = new();

        // serialize the object graph into a string
        jsonSerializer.Serialize(jsonStream, people);
    }

    WriteLine();
    WriteLine("Written {0:N0} bytes of JSON to: {1}", new FileInfo(jsonPath).Length, jsonPath);

    // display the serialized object
    WriteLine(File.ReadAllText(jsonPath));    
}


// deserializing JSON using new APIs
string jsonPath1 = Combine(CurrentDirectory, "people.json");

using (FileStream jsonLoad = File.Open(jsonPath1, FileMode.Open))
{
    // deserialize object graph into a list of Person
    List<Person>? loadedPeople =
        await NewJson.DeserializeAsync(utf8Json: jsonLoad,
        returnType: typeof(List<Person>)) as List<Person>;

    if (loadedPeople is not null)
    {
        foreach (Person p in loadedPeople)
        {
            WriteLine("{0} has {1} children", p.LastName, p.Children?.Count ?? 0);
        }
    }
}

