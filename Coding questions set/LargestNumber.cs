using System;

class LargestNumber : CheckerInterface<int>,TestInterface
{
    //https://www.geeksforgeeks.org/problems/largest-element-in-array4009/1
    private static LargestNumber large;
    public LargestNumber()
    {
        large = this;
    }
    private static int LargestNumberInAnArray(List<int> arr) {
        // code here.
        int largeNumber = Int32.MinValue;
        if(!large.IsValid(arr))
            return largeNumber;

        if(arr == null || arr.Count == 0)
            return largeNumber;
        foreach(int num in arr){
            if(num > largeNumber)
            largeNumber = num;
        }
        return largeNumber;
    }
    public void Test()
    {
        List<List<int>> testCases = new List<List<int>>()
        {
            new List<int>(){1, 2, 3, 4, 5},
            new List<int>(){5, 4, 3, 2, 1},
            new List<int>(){-1, -1, -1, -1, -1},
            new List<int>(){0, 0, 0, 0, 0},
            new List<int>(){1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
            new List<int>(){10, 9, 8, 7, 6, 5, 4, 3, 2, 1},
            new List<int>(){1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
            new List<int>(){10, 9, 8, 7, 6, 5},
            null,
            new List<int>(){}
        };
        int i=1;
        foreach (var testCase in testCases)
        {
            int result = LargestNumberInAnArray(testCase);
            Console.WriteLine("Test case "+i+": "+result);
            i++;
        }
        
    }

    public bool IsValid(List<int> arr)
    {
        // Check if the array is null or empty
        if (arr == null || arr.Count == 0)
        {
            return false; // Invalid case
        }
        return true;
    }
}