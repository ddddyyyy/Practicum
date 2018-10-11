﻿using System;
using System.Collections;
using System.Text;

namespace AreaCalculate
{

    #region DataMaker 实验一

    /// <summary>
    /// 数据生成器
    /// </summary>
    class DataMaker
    {
        /// <summary>
        /// Y坐标的最大值
        /// </summary>
        public static int MAX = 10;

        /// <summary>
        /// 生成数据
        /// </summary>
        /// <param name="seed">一位种子</param>
        /// <param name="count">生成数据的数量</param>
        /// <returns></returns>
        public static ArrayList Making(int seed, int count)
        {
            Random random = new Random(seed);
            ArrayList list = new ArrayList();
            while (--count >= 0)
            {
                list.Add(random.Next(MAX));
            }
            return list;
        }

        /// <summary>
        /// 根据X坐标生成Y坐标
        /// </summary>
        /// <param name="seed">X坐标</param>
        /// <returns></returns>
        public static ArrayList Making(int[] seed)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < seed.Length; ++i)
            {
                Random random = new Random(seed[i]);
                list.Add(random.Next(MAX));
            }
            return list;
        }
    }


    #endregion DataMaker


    #region 实验二 图形面积计算

    /// <summary>
    /// 计算面积的接口
    /// </summary>
    interface IShape
    {
        Double Arae();
    }

    /// <summary>
    /// 三角形
    /// </summary>
    class Triangle : IShape
    {
        readonly float height;
        readonly float width;

        public Triangle(float height, float width)
        {
            this.height = height;
            this.width = width;
        }

        public Double Arae()
        {
            return height * width / 2;
        }
    }

    /// <summary>
    /// 不规则图形
    /// </summary>
    class UShape : IShape
    {
        //X坐标
        int[] XList;
        //Y坐标
        int[] YList;

        public UShape(int[] list)
        {
            ArrayList x = new ArrayList(list);
            ArrayList y = DataMaker.Making(list);
            //判断数组中是否有重复的数据，并过滤
            for (int i = 0; i < x.Count; ++i)
            {
                for (int j = i+1; j < x.Count; ++j)
                {
                    if (x[i] == x[j] && y[i] == y[j])
                    {
                        x.RemoveAt(i);
                        y.RemoveAt(i);
                    }
                }
            }
            XList = ((int[])x.ToArray(typeof(int)));
            YList = ((int[])y.ToArray(typeof(int)));
        }

        public Double Arae()
        {
            Double result = 0;
            for (int i = 0; i < XList.Length - 1; ++i)
            {
                int h = XList[i + 1] - XList[i];
                result += (YList[i] + YList[i + 1]) / 2.0 * h;
            }
            return result;
        }

        /// <summary>
        /// 将不规则的图形打印的函数
        /// </summary>
        public void Print()
        {
            //动态改变的字符串，用于打印*号
            StringBuilder s = new StringBuilder();
            //每一个坐标的空格
            String tab = "   ";
            //初始化打印对应Y轴的X轴的字符串,以X轴的最大值为界
            for (int i = 0; i < GetMax(XList); ++i)
            {
                s.Append(tab);
            }
            ////储存原始的空白字符串
            String temp = s.ToString();
            //打印Y轴,从1打印到最大值
            for (int i = DataMaker.MAX; i >= 1; i -= 1)
            {
                char c = '|';
                for (int j = 0; j < YList.Length; ++j)
                {
                    //如果相等就赋值
                    if (YList[j] == i)
                    {
                        //X为0的情况
                        if (XList[j] != 0 )
                        {
                            s.Insert(tab.Length * (XList[j] - 1), "  *");
                        }
                        else
                        {
                            c = '*';
                        }
                    }
                }
                Console.Write("{0,3}{1}", i,c);
                Console.Write(s);
                s = new StringBuilder(temp);
                Console.WriteLine();
            }

            ArrayList zeroList = new ArrayList();

            //找出Y坐标为0的点
            for (int i = 0; i < YList.Length;++i)
            {
                if (YList[i] == 0)
                {
                    zeroList.Add(i);
                }
            }
            if (zeroList.Count > 0 && (int)zeroList[0] == 0)
            {
                Console.Write(tab + "*");
            }
            else
            {
                Console.Write(tab + "|");
            }

            //打印X轴
            for (int i = 1; i <= GetMax(XList); i += 1)
            {
                char c = '|';
                foreach (int j in zeroList)
                {
                    if (j == i)
                    {
                        c = '*';
                    }
                }
                Console.Write("--{0}",c);
            }

            Console.WriteLine();
            Console.Write(" ");
            //打印X轴数字
            for (int i = 0; i <= GetMax(XList); i += 1)
            {
                Console.Write("{0,3}", i);
            }
        }

        private int GetMax(int[] list)
        {
            int max = -1;
            foreach (int i in list)
            {
                if (i > max) { max = i; }
            }
            return max;
        }

        private int GetMin(int[] list)
        {
            int min = list[0];
            foreach (int i in list)
            {
                if (i < min) { min = i; }
            }
            return min;
        }

    }

    #endregion

    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] x = ((int[])DataMaker.Making((int)DateTime.Now.Ticks,10).ToArray(typeof(int))); ;
            UShape u = new UShape(x);
            u.Print();
            Console.ReadKey();
        }
    }


}
