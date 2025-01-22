using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a dictionary
        Dictionary<string, int> ages = new Dictionary<string, int>();

        // Add key-value pairs
        ages["Alice"] = 25;
        ages["Bob"] = 30;

        // Update a value
        ages["Alice"] = 26;

        // Retrieve a value
        Console.WriteLine($"Alice's age: {ages["Alice"]}");

        // Remove a key-value pair
        ages.Remove("Bob");

        // Check if a key exists
        if (ages.ContainsKey("Bob"))
        {
            Console.WriteLine("Bob is in the dictionary.");
        }
        else
        {
            Console.WriteLine("Bob is not in the dictionary.");
        }

        // Iterate through the dictionary
        foreach (var kvp in ages)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}