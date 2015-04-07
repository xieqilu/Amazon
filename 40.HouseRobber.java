/**
There are n houses built in a line, each of which contains some value in it. 
A thief is going to steal the maximal value in these houses, 
but he cannot steal in two adjacent houses. What is the maximal stolen value?
All house values are postive int, no negative number

Example:
if there are four houses with values {6, 1, 2, 7}, 
the maximal stolen value is 13 when the first and fourth houses are stolen.

Solution:
This is a very classic dynamic programming problem and we can solve it in linear
running time and constant memory space.

Assume f(i) is the max value we can get from the first house to the ith house. And the value
in the ith house is Vi. When we reach the ith house, we have two choices: to steal or not. 
Thus we have the following equation to find f(i):
f(i) = Max(f(i-2)+Vi, f(i-1))
If we rob the ith house, then the total value would be f(i-2)+Vi (since we cannot rob the (i-1)th one),
otherwise, the totoal value would be f(i-1). Then our task is to get the max between these two values.

It would be much more efficient to calculate in bottom-up order than to calculate recursively. 
It looks like a 1D array with size n is needed to store f(i) for each house. But actually for each house
we only need f(i-2) and f(i-1), so we only need two integers to cache them and in each pass, we will update
the two integers. Therefore, we can solve this problem in O(1) space.

Time complexity: O(n)
Space complexity: O(1)
*/


public class Solution {
    public int rob(int[] num) {
        if(num.length<1) return 0; //edge case
        int v1 = num[0];
        if(num.length==1) return v1; //if only one house,rob it
        int v2 = Math.max(num[0],num[1]);
        int max = v2;
        //in each pass, v1 is f(i-2), v2 is f(i-1)
        for(int i=2;i<num.length;i++){
            max = Math.max(v1+num[i], v2);
            v1=v2;
            v2=max;
        }
        return max;
    }
}
