using System;
using System.Collections.Generic;

class Program
{
    static List<int> freqQuery(List<List<int>> queries)
    {
        // Dictionary to store the count of each value
        Dictionary<int, int> valueCount = new Dictionary<int, int>();
        
        // Dictionary to store the frequency of each count
        Dictionary<int, int> freqCount = new Dictionary<int, int>();
        
        // List to store the results of the queries
        List<int> results = new List<int>();

        // Variables to store the current operation and value
        int operation = 0;
        int value = 0;

        // Loop through each query in the list
        foreach (List<int> query in queries)
        {
            // Extract the operation and value from the current query
            operation = query[0]; // Key
            value = query[1]; // Value

            if (operation == 1)
            {
                // Operation 1: Add an element

                // Get the current count for the value, or 0 if not present
                int currentCount = valueCount.GetValueOrDefault(value, 0);
                
                // Calculate the new count after adding an element
                int newCount = currentCount + 1;

                // Update the count for the value
                valueCount[value] = newCount;

                // Update the frequency of the new count
                freqCount[newCount] = freqCount.GetValueOrDefault(newCount, 0) + 1;

                // Update the frequency of the previous count
                if (currentCount > 0)
                {
                    freqCount[currentCount] = freqCount[currentCount] - 1;
                }
            }
            else if (operation == 2)
            {
                // Operation 2: Remove an element

                // Check if the value is present and has a count greater than 0
                if (valueCount.ContainsKey(value) && valueCount[value] > 0)
                {
                    // Get the current count for the value
                    int currentCount = valueCount[value];

                    // Decrease the count for the value
                    valueCount[value] = currentCount - 1;

                    // Update the frequency of the current count
                    freqCount[currentCount] = freqCount[currentCount] - 1;

                    // Update the frequency of the previous count
                    if (currentCount > 1)
                    {
                        freqCount[currentCount - 1] = freqCount.GetValueOrDefault(currentCount - 1, 0) + 1;
                    }
                }
            }
            else if (operation == 3)
            {
                // Operation 3: Check if the frequency of a value is present

                // Check if the freqCount contains the value, and add the result to the list
                results.Add(freqCount.GetValueOrDefault(value, 0) > 0 ? 1 : 0);
            }
        }

        // Return the list of results
        return results;
    }

    static void Main()
    {
        // Example queries
        List<List<int>> queries = new List<List<int>>
        {
            new List<int> {2, 3}, // No value exists
            new List<int> {1, 3}, // Inserting a value
            new List<int> {2, 3}, // Deleting a value
            new List<int> {1, 1}, // Again inserting a value
            new List<int> {3, 2}, // Check frequency; output will be 1
        };

        // Call the freqQuery function with the example queries
        List<int> results = freqQuery(queries);

        // Print the results
        foreach (int result in results)
        {
            Console.WriteLine(result);
        }
    }
}
