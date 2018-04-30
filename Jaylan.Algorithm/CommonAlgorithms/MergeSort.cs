using System.Collections.Generic;

namespace Jaylan.Algorithm.CommonAlgorithms
{
    /// <summary>
    /// 归并排序
    /// 
    /// 利用"归并"技术来进行排序。归并是指将若干个已排序的子文件合并成一个有序的文件。
    /// 归并排序有两种方式：1): 自底向上的方法 2):自顶向下的方法
    /// 
    /// 时间复杂度：O(nlgn)
    /// </summary>
    public static class MergeSort
    {
        public static List<int> Sort(List<int> list, int first = 0, int last = -1)
        {
            if (last == -1)
            {
                last = list.Count - 1;
            }
            if (first < last)   //子表的长度大于1，则进入下面的递归处理
            {
                var mid = (first + last) / 2;   //子表划分的位置
                Sort(list, first, mid);   //对划分出来的左侧子表进行递归划分
                Sort(list, mid + 1, last);    //对划分出来的右侧子表进行递归划分
                MergeSortCore(list, first, mid, last); //对左右子表进行有序的整合（归并排序的核心部分）
            }
            return list;
        }

        //归并排序的核心部分：将两个有序的左右子表（以mid区分），合并成一个有序的表
        private static void MergeSortCore(List<int> list, int first, int mid, int last)
        {
            var indexA = first; //左侧子表的起始位置
            var indexB = mid + 1;   //右侧子表的起始位置
            var temp = new int[last + 1]; //声明数组（暂存左右子表的所有有序数列）：长度等于左右子表的长度之和。
            var tempIndex = 0;
            while (indexA <= mid && indexB <= last) //进行左右子表的遍历，如果其中有一个子表遍历完，则跳出循环
            {
                if (list[indexA] <= list[indexB]) //此时左子表的数 <= 右子表的数
                {
                    temp[tempIndex++] = list[indexA++];    //将左子表的数放入暂存数组中，遍历左子表下标++
                }
                else//此时左子表的数 > 右子表的数
                {
                    temp[tempIndex++] = list[indexB++];    //将右子表的数放入暂存数组中，遍历右子表下标++
                }
            }
            //有一侧子表遍历完后，跳出循环，将另外一侧子表剩下的数一次放入暂存数组中（有序）
            while (indexA <= mid)
            {
                temp[tempIndex++] = list[indexA++];
            }
            while (indexB <= last)
            {
                temp[tempIndex++] = list[indexB++];
            }

            //将暂存数组中有序的数列写入目标数组的制定位置，使进行归并的数组段有序
            tempIndex = 0;
            for (var i = first; i <= last; i++)
            {
                list[i] = temp[tempIndex++];
            }
        }
    }
}
