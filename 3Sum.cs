/**
Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

Note:
Elements in a triplet (a,b,c) must be in non-descending order. (ie, a ≤ b ≤ c)
The solution set must not contain duplicate triplets.
    For example, given array S = {-1 0 1 2 -1 -4},

    A solution set is:
    (-1, 0, 1)
    (-1, -1, 2)
*/

public class Solution {
    public IList<IList<int>> ThreeSum(int[] num) {
        Array.Sort(num);
        var ans = new List<IList<int>>();
        int n = num.Length;
        for (int i = 0; i < n - 2; ) {
            int target = -num[i];
            int j = i + 1;
            int k = n - 1;
            while (j < k) {
                int sum = num[j] + num[k];
                if (sum < target) {
                    j++;
                } else if (sum > target) {
                    k--;
                } else {
                    var triplets = new List<int>();
                    triplets.Add(num[i]);
                    triplets.Add(num[j]);
                    triplets.Add(num[k]);
                    ans.Add(triplets);
                    while (j < n && num[j] == triplets[1]) j++;
                    while (k >= 0 && num[k] == triplets[2]) k--;
                }
            }
            int prev = num[i];
            while (i < n - 2 && num[i] == prev) i++;
        }
        return ans;
    }
}
