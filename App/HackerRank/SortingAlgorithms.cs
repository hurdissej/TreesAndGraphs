using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
public static class SortingAlgorithms {

    private static int[] quickSort(int[] arr)
    {
        var less = arr.Where(x => x < arr[0]).ToArray();
        var more = arr.Where(x => x > arr[0]).ToArray();
        var eq = arr.Where(x => x == arr[0]);
        if(less.Length > 1)
        {
            less = quickSort(less);
            System.Console.WriteLine(string.Join(" ", less));
        }
        if(more.Length > 1)
        {
            more = quickSort(more);
            System.Console.WriteLine(string.Join(" ", more));
        }
        return less.Concat(eq).Concat(more).ToArray();
    }

    static int[] insertionSort2(int[] arr) {
        for(var i = 1; i < arr.Count(); i++)
        {
            var x = arr[i];
            var j = i;
            while(j > 0 && arr[j-1] > x)
            {
                arr[j] = arr[j-1];
                j--;
            }
            arr[j] = x;
        }
        return arr;
    }

    static void PerformSort(String[] args) {
        var stopwatch = new Stopwatch();
        var r = new Random();
        var arr = new int[100000];
        for(var i = 0; i < 100000; i ++)
        {
            arr[i] = r.Next(0,1000);
        }
        
        stopwatch.Start();
        int[] result = quickSort(arr);
        //Console.WriteLine(String.Join(" ", result));
        System.Console.WriteLine($"Quick Sorted in: {stopwatch.ElapsedMilliseconds}");
        stopwatch.Restart();

        
        int[] result2 = insertionSort2(arr);
       // Console.WriteLine(String.Join(" ", result2));
        System.Console.WriteLine($"Insert Sorted in: {stopwatch.ElapsedMilliseconds}");
        stopwatch.Reset();
    }
}
