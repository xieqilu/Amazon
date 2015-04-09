/**
Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. Return the sum of the three integers. You may assume that each input would have exactly one solution.

    For example, given array S = {-1 2 1 -4}, and target = 1.

    The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
*/

class Solution {
    public int ThreeSumClosest(int[] num, int target) {
        Array.Sort(num);
        int n = num.Length;
        int closesetSum = num[0] + num[1] + num[2];
        int minDelta = Math.Abs(target - closesetSum);
        for (int i = 0; i < n-2; i++) {
            int j = i + 1, k = n - 1;
            int sub = target - num[i];
            while(j<k) {
                int sum = num[j] + num[k];
                if (sum<sub) {
                    j++;
                } else {
                    k--;
                }
                int delta = Math.Abs(sub - sum);
                if (delta<minDelta) {
                    minDelta = delta;
                    closesetSum = sum + num[i];
                }
            }
        }
        return closesetSum;
    }
}
