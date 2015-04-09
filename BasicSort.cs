/*Quick Sort*/
using System;
using System.Collections.Generic;
using System.Text;
 
namespace CSharpSort
{
    class Program
    {
 
        static public int Partition(int [] numbers, int left, int right)
        {
            int pivot = numbers[left];
              while (true)
              {
                while (numbers[left] < pivot)
                    left++;
 
                while (numbers[right] > pivot)
                    right--;
 
                if (left < right)
                    {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                    }
                    else
                    {
                          return right;
                    }
              }
        }
 
        static public void QuickSort_Recursive(int [] arr, int left, int right)
        {
            // For Recusrion
            if(left < right)
            {
                int pivot = Partition(arr, left, right);
 
                if(pivot > 1)
                    QuickSort_Recursive(arr, left, pivot - 1);
 
                if(pivot + 1 < right)
                    QuickSort_Recursive(arr, pivot + 1, right);
            }
        }
 
        static void Main(string[] args)
        {
            int[] numbers = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
            int len = 9;
 
            Console.WriteLine("QuickSort By Recursive Method");
            QuickSort_Recursive(numbers, 0, len - 1);
            for (int i = 0; i < 9; i++)
                Console.WriteLine(numbers[i]);
 
            Console.WriteLine();
           
        }
    }
}



//Quick Sort Iterative
using System;
using System.Collections.Generic;
using System.Text;
 
namespace CSharpSort
{
    class Program
    {
 
        static public int Partition(int [] numbers, int left, int right)
        {
            int pivot = numbers[left];
              while (true)
              {
                while (numbers[left] < pivot)
                    left++;
 
                while (numbers[right] > pivot)
                    right--;
 
                if (left < right)
                    {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                    }
                    else
                    {
                          return right;
                    }
              }
        }
 
        struct QuickPosInfo
        {
            public int left;
            public int right;
        };
 
        static public void QuickSort_Iterative(int [] numbers, int left, int right)
        {
           
            if(left >= right)
                return; // Invalid index range
 
            List<QuickPosInfo> list = new List<QuickPosInfo>();
 
            QuickPosInfo info;
            info.left = left;
            info.right = right;
            list.Insert(list.Count, info);
 
            while(true)
            {
                if(list.Count == 0)
                    break;
 
                left = list[0].left;
                right = list[0].right;
                list.RemoveAt(0);
 
                int pivot = Partition(numbers, left, right);   
               
                if(pivot > 1)
                {
                    info.left = left;
                    info.right = pivot - 1;
                    list.Insert(list.Count, info);
                }
 
                if(pivot + 1 < right)
                {
                    info.left = pivot + 1;
                    info.right = right;
                    list.Insert(list.Count, info);
                }
            }
        }
 
        static void Main(string[] args)
        {
            int[] numbers = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
            int len = 9;
 
            Console.WriteLine("QuickSort By Iterative Method");
            QuickSort_Iterative(numbers, 0, len - 1);
            for (int i = 0; i < 9; i++)
                Console.WriteLine(numbers[i]);
           
        }
    }
}


//Bubble Sort
using System;
using System.Collections.Generic;
using System.Text;
 
namespace ConsoleApplication1
{
    class Program
    {
 
      static int BubbleSort()
        {
            Console.Write("\nProgram for Ascending order of Numeric Values using BUBBLE SORT");
            Console.Write("\n\nEnter the total number of elements: ");
            int max = Convert.ToInt32(Console.ReadLine());
 
            int [] numarray = new int[max];
 
            for(int i = 0; i < max; i++)
            {
                Console.Write("\nEnter [" + (i + 1).ToString() + "] element: ");
                numarray[i] = Convert.ToInt32(Console.ReadLine());
            }
 
            Console.Write("Before Sorting   : ");
            for(int k = 0; k < max; k++)
                Console.Write(numarray[k] + " ");
            Console.Write("\n");
 
            for(int i = 1; i < max; i++)
            {
                for(int j = 0; j < max - i; j++)
                {
                    if(numarray[j] > numarray[j + 1])
                    {
                        int temp = numarray[j];
                        numarray[j] = numarray[j + 1];
                        numarray[j + 1] = temp;
                    }
                }
                Console.Write("After iteration " + i.ToString() + ": ");
                for(int k = 0; k < max; k++)
                    Console.Write(numarray[k] +  " ");
                Console.Write("/*** " + (i + 1).ToString() + " biggest number(s) is(are) pushed to the end of the array ***/\n");
            }
 
            Console.Write("\n\nThe numbers in ascending orders are given below:\n\n");
            for(int i = 0; i < max; i++)
            {
                Console.Write("Sorted [" + (i + 1).ToString() + "] element: ");
                Console.Write(numarray[i]);
                Console.Write("\n");
            }
            return 0;
        }  
 
      static void Main(string[] args)
      {
            BubbleSort();
           
      }
    }
}

//Merge Sort
using System;
using System.Collections.Generic;
using System.Text;
 
namespace CSharpSort
{
    class Program
    {
 
        static public void DoMerge(int [] numbers, int left, int mid, int right)
        {
            int [] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;
        
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);
        
            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }
        
            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];
 
            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];
 
            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
 
        static public void MergeSort_Recursive(int [] numbers, int left, int right)
        {
          int mid;
        
          if (right > left)
          {
            mid = (right + left) / 2;
            MergeSort_Recursive(numbers, left, mid);
            MergeSort_Recursive(numbers, (mid + 1), right);
        
            DoMerge(numbers, left, (mid+1), right);
          }
        }
        
 
        static void Main(string[] args)
        {
            int[] numbers = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
            int len = 9;
 
            Console.WriteLine("MergeSort By Recursive Method");
            MergeSort_Recursive(numbers, 0, len - 1);
            for (int i = 0; i < 9; i++)
                Console.WriteLine(numbers[i]);
 
            Console.WriteLine(numbers[i]);
 
        }
    }
}

//Merge Sort Iterative
using System;
using System.Collections.Generic;
using System.Text;
 
namespace CSharpSort
{
    class Program
    {
 
        static public void DoMerge(int [] numbers, int left, int mid, int right)
        {
            int [] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;
        
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);
        
            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }
        
            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];
 
            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];
 
            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
 
        struct MergePosInfo
        {
            public int left;
            public int mid;
            public int right;
        };
 
        static public void MergeSort_Iterative(int [] numbers, int left, int right)
        {
            int mid;
            if (right <= left)
                return;
         
            List<MergePosInfo> list1 = new List<MergePosInfo>();
            List<MergePosInfo> list2 = new List<MergePosInfo>();
 
            MergePosInfo info;
            info.left = left;
            info.right = right;
            info.mid = -1;
           
            list1.Insert(list1.Count, info);
 
            while(true)
            {
                if(list1.Count == 0)
                    break;
 
                left = list1[0].left;
                right = list1[0].right;
                list1.RemoveAt(0);
                mid = (right + left) / 2;
 
                if(left < right)
                {
                    MergePosInfo info2;
                    info2.left = left;
                    info2.right = right;
                    info2.mid = mid + 1;
                    list2.Insert(list2.Count, info2);
 
                    info.left = left;
                    info.right = mid;
                    list1.Insert(list1.Count, info);
 
                    info.left = mid + 1;
                    info.right = right;
                    list1.Insert(list1.Count, info);
                }
            }
 
 
            for (int i = 0; i < list2.Count; i++)
            {
                DoMerge(numbers, list2[i].left, list2[2].mid, list2[2].right);
            }
           
        }
 
        
 
        static void Main(string[] args)
        {
            int[] numbers = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
            int len = 9;
 
            Console.WriteLine("MergeSort By Iterative Method");
            MergeSort_Iterative(numbers, 0, len - 1);
            for (int i = 0; i < 9; i++)
                Console.WriteLine(numbers[i]);
 
        }
    }
}

//Insertion Sort
using System;
using System.Collections.Generic;
using System.Text;
 
namespace ConsoleApplication1
{
    class Program
    {
 
        static int InsertionSort()
        {
            Console.Write("\nProgram for Ascending order of Numeric Values using INSERTION SORT");
            Console.Write("\n\nEnter the total number of elements: ");
            int max = Convert.ToInt32(Console.ReadLine());
 
            int [] numarray = new int[max];
 
            for(int i = 0; i < max; i++)
            {
                Console.Write("\nEnter [" + (i + 1).ToString() + "] element: ");
                numarray[i] = Convert.ToInt32(Console.ReadLine());
            }
 
            Console.Write("Before Sorting   : ");
            for(int k = 0; k < max; k++)
                Console.Write(numarray[k] + " ");
            Console.Write("\n");  
 
            for(int i = 1; i < max; i++)
            {
                int j = i;
                while(j > 0)
                {
                    if(numarray[j-1] > numarray[j])
                    {
                        int temp = numarray[j - 1];
                        numarray[j - 1] = numarray[j];
                        numarray[j] = temp;
                        j--;
                    }
                    else
                        break;
                }
                Console.Write("After iteration " + i.ToString() + ": ");
                for(int k = 0; k < max; k++)
                    Console.Write(numarray[k] + " ");
                Console.Write("/*** " + (i + 1).ToString() + " numbers from the begining of the array are input and they are sorted ***/\n");
            }
 
            Console.Write("\n\nThe numbers in ascending orders are given below:\n\n");
            for(int i = 0; i < max; i++)
            {
                Console.Write("Sorted [" + (i + 1).ToString() + "] element: ");
                Console.Write(numarray[i]);
                Console.Write("\n");
            }
            return 0;
        }
 
 
        static void Main(string[] args)
        {
            InsertionSort();
        }
    }
}
