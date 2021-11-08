using System;

namespace Queue_Study
{
    class Program
    {
        static void Main(string[] args)
        {
            b();
        }

        /// <summary>
        /// 基础队列
        /// </summary>
        public static void a()
        {
            try
            {

                Console.WriteLine("基础队列");
                ArrayQueue(3);
                var loop = true;
                while (loop)
                {
                    Console.WriteLine("s(show):显示队列");
                    Console.WriteLine("e(exit):退出队列");
                    Console.WriteLine("a(add):添加队列数据");
                    Console.WriteLine("g(get):取队列数据");
                    var a = Console.ReadLine();
                    switch (a.ToCharArray()[0])
                    {
                        case 's':
                            ShowQueue(); break;
                        case 'e':
                            loop = false; break;
                        case 'a':
                            Console.WriteLine("请输入数字进行添加");
                            addQueue(int.Parse(Console.ReadLine()));
                            break;
                        case 'g':
                            Console.WriteLine("数据为：" + GetQueue()); break;
                        default:
                            break;
                    }
                }

                Console.WriteLine("退出");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 环形队列
        /// </summary>
        public static void b()
        {
            try
            {
                Console.WriteLine("环形队列");
                CircleArrayQueue circleArrayQueue = new CircleArrayQueue(10);
                var loop = true;
                while (loop)
                {
                    Console.WriteLine("s(show):显示队列");
                    Console.WriteLine("e(exit):退出队列");
                    Console.WriteLine("a(add):添加队列数据");
                    Console.WriteLine("g(get):取队列数据");
                    var a = Console.ReadLine();
                    switch (a.ToCharArray()[0])
                    {
                        case 's':
                            circleArrayQueue.ShowQueue(); break;
                        case 'e':
                            loop = false; break;
                        case 'a':
                            Console.WriteLine("请输入数字进行添加");
                            circleArrayQueue.addQueue(int.Parse(Console.ReadLine()));
                            break;
                        case 'g':
                            Console.WriteLine("数据为：" + circleArrayQueue.GetQueue()); break;
                        default:
                            break;
                    }
                }

                Console.WriteLine("退出");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 环形队列
        /// </summary>
        public class CircleArrayQueue
        {
            /// <summary>
            /// 最大容量
            /// </summary>
            public static int MaxSize { get; set; }

            /// <summary>
            /// 指向队列第一位，front = 0;
            /// </summary>
            public static int front { get; set; }

            /// <summary>
            /// 指向队列尾的后一个位置
            /// </summary>
            public static int rear { get; set; }

            /// <summary>
            /// 数据数组
            /// </summary>
            public static int[] arr { get; set; }

            /// <summary>
            /// 使用数组模拟队列
            /// </summary>
            public CircleArrayQueue(int arrMaxSize)
            {
                MaxSize = arrMaxSize;
                arr = new int[MaxSize];
            }

            /// <summary>
            /// 判断队列是否已满
            /// </summary>
            /// <returns></returns>
            public bool isFull()
            {
                return (rear + 1) % MaxSize == front;
            }

            /// <summary>
            /// 队列是否为空
            /// </summary>
            /// <returns></returns>
            public bool isEmpty()
            {
                return rear == front;
            }

            /// <summary>
            /// 添加
            /// </summary>
            /// <param name="n"></param>
            public void addQueue(int n)
            {
                if (isFull())
                {
                    Console.WriteLine("队列已满");
                    return;
                }

                arr[rear] = n;
                //将rear后移
                //例：若maxSize = 10；rear = 0；则rear = （0 + 1）% 10 = 1；
                //    若maxSize = 10；rear = 1；则rear = （1 + 1）% 10 = 2；
                //    若maxSize = 10；rear = 9；则rear = （9 + 1）% 10 = 0；
                rear = (rear + 1) % MaxSize;
            }

            /// <summary>
            /// 取数据
            /// </summary>
            /// <returns></returns>
            public int GetQueue()
            {
                if (isEmpty())
                {
                    throw new Exception("队列为空");
                }

                //分析front是否指向的时队列的第一条元素
                //将front对应的值保存到零时变量中；
                var value = arr[front];
                //将front后移
                //例：若maxSize = 10；front = 0；则rear = （0 + 1）% 10 = 1；
                //    若maxSize = 10；front = 1；则rear = （1 + 1）% 10 = 2；
                //    若maxSize = 10；front = 9；则rear = （9 + 1）% 10 = 0；
                front = (front + 1) % MaxSize;
                return value;
            }

            /// <summary>
            /// 获取队列所有数据
            /// </summary>
            public void ShowQueue()
            {
                if (isEmpty())
                {

                    Console.WriteLine("队列为空");
                    return;
                }

                //应从front开始遍历，遍历个数应为front+【有效个数(rear + MaxSize - front) % MaxSize】
                for (int i = front; i < front + (rear + MaxSize - front) % MaxSize; i++)
                {
                    //i % MaxSize 说明：例：若队列中原有10条数据，去除两条，即去除arr[0],arr[1],再加两条，即在arr[0],arr[1]中添加数据，所以有效数据个数为10;
                    //第一条数据为arr[2]，即front=2,而第9条数据应该是arr[10]但数组只到arr[9]，所以数据为arr[0],所以即为arr[10%10]=arr[0]
                    Console.WriteLine($"arr[{i % MaxSize}] = {arr[i % MaxSize]}" + "\n");
                }
                foreach (var item in arr)
                {
                    Console.WriteLine(item + "\n");
                }
            }

        }

        #region 普通队列

        /// <summary>
        /// 最大容量
        /// </summary>
        public static int MaxSize { get; set; }

        /// <summary>
        /// 指向队列头前一位置
        /// </summary>
        public static int front { get; set; }

        /// <summary>
        /// 指向队列尾
        /// </summary>
        public static int rear { get; set; }

        /// <summary>
        /// 数据数组
        /// </summary>
        public static int[] arr { get; set; }

        /// <summary>
        /// 使用数组模拟队列
        /// </summary>
        public static void ArrayQueue(int arrMaxSize)
        {
            MaxSize = arrMaxSize;
            arr = new int[MaxSize];
            front = -1;
            rear = -1;
        }

        /// <summary>
        /// 判断队列是否已满
        /// </summary>
        /// <returns></returns>
        public static bool isFull()
        {
            return rear == MaxSize - 1;
        }

        /// <summary>
        /// 队列是否为空
        /// </summary>
        /// <returns></returns>
        public static bool isEmpty()
        {
            return rear == front;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="n"></param>
        public static void addQueue(int n)
        {
            if (isFull())
            {
                Console.WriteLine("队列已满");
                return;
            }

            rear++;
            arr[rear] = n;
        }

        /// <summary>
        /// 取数据
        /// </summary>
        /// <returns></returns>
        public static int GetQueue()
        {
            if (isEmpty())
            {
                throw new Exception("队列为空");
            }
            front++;
            return arr[front];
        }

        /// <summary>
        /// 获取队列所有数据
        /// </summary>
        public static void ShowQueue()
        {
            if (isEmpty())
            {

                Console.WriteLine("队列为空");
                return;
            }

            foreach (var item in arr)
            {
                Console.WriteLine(item + "\n");
            }
        }
        #endregion
    }
}
