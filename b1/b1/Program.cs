using System;
class b1
{
    int MaxElement(int[] arr,int len)
    {
        int res = int.MinValue;
        for (int i = 0; i < len; i++) 
        {
            if (arr[i]>res)
            {
                res = arr[i];
            }
        }
        return res;
    }
    int MinElement(int[] arr, int len)
    {
        int res = int.MaxValue;
        for (int i = 0; i < len; i++)
        {
            if (arr[i] < res)
            {
                res = arr[i];
            }
        }
        return res;
    }
    double MeanSum(int[] arr,int len)
    {
        double res = 0;
        for(int i = 0;i < len;i++) res+= arr[i];
        return res / len;
    }
    int ArrSum(int[] arr,int len)
    {
        int res = 0;
        for (int i = 0;i<len ; i++)res+= arr[i];
        return res;
    }
    static void Main(String[] args)
    {
        int[] arr = {1,2,3,4,5,6,7,8,9};
        int len = arr.Length;
        b1 b = new b1();
        Console.WriteLine("maxnum= " + b.MaxElement(arr, len));
        Console.WriteLine("minnum= " + b.MinElement(arr, len));
        Console.WriteLine("meannum= " + b.MeanSum(arr, len));
        Console.WriteLine("sum= " + b.ArrSum(arr, len));
    }
}
