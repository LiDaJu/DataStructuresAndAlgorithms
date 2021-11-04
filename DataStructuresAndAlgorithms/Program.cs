using System;

/// <summary>
/// 稀疏数组
/// </summary>
namespace Sparse_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ArrayToSparse();


        }

        /// <summary>
        /// 创建原始数组并将原数组转成稀疏数组
        /// </summary>
        /// <returns></returns>
        public static int[,] ArrayToSparse()
        {
            //创建原始数组
            int[,] array = new int[6, 7];
            array[0, 3] = 22;
            array[0, 6] = 15;
            array[1, 1] = 11;
            array[1, 5] = 17;
            array[2, 3] = -6;
            array[3, 5] = 39;
            array[4, 0] = 91;
            array[5, 2] = 28;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine(" ");
            }

            Console.WriteLine("-------------------");

            var count = 0;

            foreach (var item in array)
            {
                if (item != 0)
                {
                    count += 1;
                }
            }

            int[,] sparseArray = new int[count + 1, 3];
            sparseArray[0, 0] = 6;
            sparseArray[0, 1] = 7;
            sparseArray[0, 2] = count;
            for (int i = 1; i < sparseArray.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(0); k++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[k, j] != 0)
                        {
                            sparseArray[i, 0] = k;
                            sparseArray[i, 1] = j;
                            sparseArray[i, 2] = array[k, j];
                        }
                    }
                }
            }

            for (int i = 0; i < sparseArray.GetLength(0); i++)
            {
                for (int j = 0; j < sparseArray.GetLength(1); j++)
                {
                    Console.Write(sparseArray[i, j] + "\t");
                }
                Console.WriteLine(" ");
            }

            return sparseArray;
        }
    }
}
