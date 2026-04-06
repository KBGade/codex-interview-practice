using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPracticeApp;

public static class Program
{
   public static void Main()
{
    Console.WriteLine("Interview Practice App");
    Console.WriteLine("----------------------");

    int[] numbers = { 1, 2, 2, 3, 3, 3, 4, 5, 5 };
    int top = 2;

    if (top > numbers.Length)
    {
        Console.WriteLine("Requested top K is larger than the number of elements.");
        return;
    }

    var result = GetTopKFrequent(numbers, top);

    Console.WriteLine($"Top {top} frequent elements: {string.Join(", ", result)}");
}

    public static List<int> GetTopKFrequent(int[] numbers, int k)
    {
        if (numbers == null || numbers.Length == 0)
            return new List<int>();

        if (k <= 0)
            return new List<int>();

        var frequencyMap = new Dictionary<int, int>();

        foreach (var number in numbers)
        {
            if (frequencyMap.ContainsKey(number))
                frequencyMap[number]++;
            else
                frequencyMap[number] = 1;
        }

        return frequencyMap
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .Take(k)
            .Select(x => x.Key)
            .ToList();
    }
}