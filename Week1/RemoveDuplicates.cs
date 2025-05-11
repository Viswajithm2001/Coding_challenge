class RemoveDuplicates : CheckerInterface<int>, TestInterface
{
    //https://leetcode.com/problems/remove-duplicates-from-sorted-array/submissions/1631157396/
    private static RemoveDuplicates remove;
    public RemoveDuplicates()
    {
        remove = this;
    }
    public static int RemoveDuplicatesInAnArray(int[] nums)
    {
        // code here.
        int n = nums.Length;
        int k = 1;
        if (!remove.IsValid(nums.ToList()))
            return k;
        for (int i = 0; i < n - 1; i++)
        {
            if (nums[i] != nums[i + 1])
            {
                nums[k] = nums[i + 1];
                k++;
            }
        }
        return k;

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
    public void Test()
    {
        List<List<int>> testCases = new List<List<int>>()
        {
            new List<int>(){1, 1, 3, 4, 5},
            new List<int>(){5, 5, 3, 2, 1},
            new List<int>(){-1, -1, -1, -1, -1},
            new List<int>(){0, 0, 0, 0, 0},
            new List<int>(){1, 1, 2, 2, 3, 3, 4, 4, 5, 5},
            new List<int>(){-1, -1, 0, 0, 1, 1},
            new List<int>(){1, 2},
            new List<int>(){10},
            new List<int>(){}
        };
        int i = 1;
        foreach (var testCase in testCases)
        {
            int result = RemoveDuplicatesInAnArray(testCase.ToArray());
            Console.WriteLine("Test case " + i + ": " + result);
            i++;
        }

    }
}