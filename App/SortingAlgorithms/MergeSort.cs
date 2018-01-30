using System;
using System.Collections.Generic;
using System.Linq;

public static class mergeSort 
{
    public static List<int> splitList(List<int> list)
    {
        if(list.Count <= 1)
            return list;
        
        int middle = list.Count / 2; 
        List<int> left = list.Take(middle).ToList();
        List<int> right = list.Skip(middle).ToList();

        return Merge(splitList(left), splitList(right));
    }

    private static List<int> Merge(List<int> left, List<int> right)
    {
        var result = new List<int>();

        while(left.Count > 0 || right.Count > 0 )
        {
            if(left.Count > 0 && right.Count > 0)
            {
                if(left[0] > right[0])
                {
                    result.Add(right[0]);
                    right.Remove(right[0]);
                } else 
                {
                    result.Add(left[0]);
                    left.Remove(left[0]);
                }
            } else if (left.Count > 1)
            {
                    result.Add(left[0]);
                    left.Remove(left[0]);
            } else if (right.Count > 1)
            {
                    result.Add(right[0]);
                    right.Remove(right[0]);   
            }
        }
        return result;
    }
}