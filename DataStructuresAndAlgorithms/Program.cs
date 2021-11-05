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
            var sparseArr = ArrayToSparse();

            SparseToArray(sparseArr);
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

            var a = 1;

            for (int k = 0; k < array.GetLength(0); k++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[k, j] != 0)
                    {
                        sparseArray[a, 0] = k;
                        sparseArray[a, 1] = j;
                        sparseArray[a, 2] = array[k, j];
                        a++;
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
            Console.WriteLine("-------------------");
            return sparseArray;
        }

        /// <summary>
        /// 将稀疏数组转成原数组
        /// </summary>
        /// <param name="sparse"></param>
        public static void SparseToArray(int[,] sparse)
        {
            int[,] array = new int[sparse[0, 0], sparse[0, 1]];

            for (int i = 1; i < sparse.GetLength(0); i++)
            {
                array[sparse[i, 0], sparse[i, 1]] = sparse[i, 2];
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine(" ");
            }

            Console.WriteLine("-------------------");
        }
    }
}
