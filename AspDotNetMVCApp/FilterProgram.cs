using System;
using System.Collections.Generic;
using System.Linq;
 
class Solution
{
    static List<string> FilterRooms(List<(string source, string destination)> instructions, List<string> treasureRooms)
    {
        var destinationToSources = new Dictionary<string, List<string>>();
        var sourceToDestination = new Dictionary<string, string>();
 
        foreach (var (source, destination) in instructions)
        {
            sourceToDestination[source] = destination;
 
            if (!destinationToSources.ContainsKey(destination))
                destinationToSources[destination] = new List<string>();
 
            destinationToSources[destination].Add(source);
        }
 
        var result = new List<string>();
 
        foreach (var room in destinationToSources.Keys)
        {
            int incomingCount = destinationToSources[room].Count;
 
            if (incomingCount >= 2 &&
                sourceToDestination.ContainsKey(room) &&
                treasureRooms.Contains(sourceToDestination[room]))
            {
                result.Add(room);
            }
        }
        return result;
    }
 
    static void Main()
    {
        var instructions1 = new List<(string, string)> {
            ("jasmin", "tulip"),
            ("lily", "tulip"),
            ("tulip", "tulip"),
            ("rose", "rose"),
            ("violet", "rose"),
            ("sunflower", "violet"),
            ("daisy", "violet"),
            ("iris", "violet")
        };
 
        var treasureRooms1 = new List<string> { "lily", "tulip", "violet", "rose" };
        var treasureRooms2 = new List<string> { "lily", "jasmin", "violet" };
 
        var result1 = FilterRooms(instructions1, treasureRooms1);
        var result2 = FilterRooms(instructions1, treasureRooms2);
 
        var instructions2 = new List<(string, string)> {
            ("jasmin", "tulip"),
            ("lily", "tulip"),
            ("tulip", "violet"),
            ("violet", "violet")
        };
 
        var treasureRooms3 = new List<string> { "violet" };
        var result3 = FilterRooms(instructions2, treasureRooms3);
 
        Console.WriteLine("Result 1: " + string.Join(", ", result1));
        Console.WriteLine("Result 2: " + string.Join(", ", result2));
        Console.WriteLine("Result 3: " + string.Join(", ", result3));
    }
}
 