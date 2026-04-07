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
    Console.WriteLine("Exercise 1: Top K Frequent Elements");
    int[] numbers = { 1, 2, 2, 3, 3, 3, 4, 5, 5 };
    int top = 2;

    if (top > numbers.Length)
    {
        Console.WriteLine("Requested top K is larger than the number of elements.");
        return;
    }

    var result = GetTopKFrequent(numbers, top);

    Console.WriteLine($"Top {top} frequent elements: {string.Join(", ", result)}");
    Console.WriteLine("----------------------");
    Console.WriteLine("Exercise 2: Subarray Sum Equals K");
    int[] subArraysum = { 1, 2, 2, 3, 3, 3, 4, 5, 5 };
    int sum = 9;

    var subsumarray = GetTwoSum(subArraysum,sum);
    Console.WriteLine($"Two Sum of {sum} in given array are ");
    foreach( var item in subsumarray)
        {
            Console.WriteLine($"Index are :, {string.Join(", ", item)}");
            Console.WriteLine($"{item[0]} {item[1]}");
        }
    Console.WriteLine("----------------------");
    Console.WriteLine("Exercise 3: Merging Intervals");

    int[][] merginArray = new int[][]
    {
        new int[] { 7, 8 },new int[] { 1, 5 },new int[] { 2, 4 },new int[] { 4, 6 }
    };
    List<int[]> res = GetMergeOverlap(merginArray);
    foreach (var interval in res)
        {
            Console.WriteLine($"{interval[0]} {interval[1]}");
        }
}

    public static List<int> GetTopKFrequent(int[] numbers, int k)
    {
      if (numbers == null)
        throw new ArgumentNullException(nameof(numbers));

    if (k <= 0)
        throw new ArgumentOutOfRangeException(nameof(k));

    var uniqueCount = numbers.Distinct().Count();

    if (k > uniqueCount)
        throw new ArgumentOutOfRangeException(nameof(k), $"k must be <= {uniqueCount}");

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
        .Take(k)
        .Select(x => x.Key)
        .ToList();  
    
    }

    public static int[][] GetTwoSum(int[] numbers, int k)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException(nameof(numbers));
        }
        if (k <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(k));
        }
        var map = new Dictionary<int,int>();
        List<int[]> TwoList = new List<int[]>();
        for(int i = 0; i < numbers.Length; i++)
        {
            int complete = k - numbers[i]; 

            if (map.TryGetValue(complete, out int Previousindex))
            {
                TwoList.Add(new int[]{Previousindex, i });
            }
            if(!map.ContainsKey(numbers[i]))
            {
                map.Add(numbers[i], i);
            }
        }
        return TwoList.ToArray();
    }
    public static List<int[]> GetMergeOverlap(int[][] arr)
    {
        int n = arr.Length;
        Array.Sort(arr, (a,b) => a[0].CompareTo(b[0]));
        List<int[]> response = new List<int[]>(); 
        for(int i = 0; i < n; i++)
        {
            int start = arr[i][0]; // start of the interval
            int end = arr[i][1]; //end of the interval
            
            if(response.Count > 0 && response[response.Count - 1][1] >= end) // checking the response 
            continue;                                                        // last intevals end with current end

            for(int j = i + 1; j < n; j++) // checking the next intervals start and end 
            {                              // need this loop which start from next interation of i    
               if(arr[j][0] <= end)  // checking next interval start e.g (1,5) & (2,4) => i.e 2 <=5
                                     // need to merge these two intervals i.e (1,5) & (2,4) => (1,5)
                                     // for this new interval we need max value from previous end & next end        
               end = Math.Max(end, arr[j][1]);                            
            } 
            response.Add( new int[] {start, end});                                                                   
        }  
        return response;     
    }
}