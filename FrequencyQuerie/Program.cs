using System;
using System.Collections.Generic;

class Program
{
    static List<int> freqQuery(List<List<int>> queries)
    {
        Dictionary<int, int> valueCount = new Dictionary<int, int>();
        Dictionary<int, int> freqCount = new Dictionary<int, int>();
        List<int> results = new List<int>();

        int operation = 0;
        int value = 0;

        foreach (List<int> query in queries)
        {
            operation = query[0];
            value = query[1];

            if (operation == 1)
            {
                // Adding an element
                int currentCount = valueCount.GetValueOrDefault(value, 0);
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
                // Removing an element
                if (valueCount.ContainsKey(value) && valueCount[value] > 0)
                {
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
                // Check if the freqCount contains the value
                results.Add(freqCount.GetValueOrDefault(value, 0) > 0 ? 1 : 0);
            }
        }
        return results;
    }

    static void Main()
    {
        // Example 
        List<List<int>> queries = new List<List<int>>
        {
            new List<int> {2, 3}, // No value exist
            new List<int> {1, 3}, // Insering a value
            new List<int> {2, 3}, // Deleting a value
            new List<int> {1, 1}, //Again  inserting a value
            new List<int> {3, 1}, // now we are checking frequency we have available 1 frequency so Output will be 1 
            // if frequency will not match so output will be 0.
        };

        List<int> results = freqQuery(queries);

        foreach (int result in results)
        {
            Console.WriteLine(result);
        }
    }
}