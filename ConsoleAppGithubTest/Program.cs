// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Threading.Channels;
using ConsoleAppGithubTest;

Console.WriteLine("Hello, Github!!");



var propReq = new PropReq
{
    Id = 1,
    Type = "House",
    Size = 100
};

var p = new Property();


// Iterate over the properties of the source object using reflection
foreach (var prop in propReq.GetType().GetProperties())
{
    // Find the corresponding property in the destination object
    var destinationProperty = p.GetType().GetProperty(prop.Name)!;

    // Copy the value from source to destination
    if (destinationProperty!= null! && destinationProperty.CanWrite)
    {
        var value = prop.GetValue(propReq)!;
        destinationProperty.SetValue(p, value);
    }
}

// Now, 'destination' object is populated with values from 'source' object
Console.WriteLine($"Id: {p.Id}, Type: {p.Type}, Size: {p.Size}");

