using System;
using System.Collections;

namespace AreaCalculate
{
    class DataMaker
    {
        public static ArrayList Making(int seed,int count)
        {
            Random random = new Random(seed);
            ArrayList list = new ArrayList();
            while(--count>0)
            {
                list.Add(random.NextDouble());
            }
            return list;
        }
    }

    interface IShape
    {
        float Arae();
    }

    class Triangle : IShape
    {
        readonly float height;
        readonly float width;

        public Triangle(float height,float width)
        {
            this.height = height;
            this.width = width;
        }

        public float Arae()
        {
            return height * width / 2;
        }
    }

    class UShape
    {
        ArrayList XList;
        ArrayList YList;
        public UShape(int[] list){
            XList = new ArrayList(list);
            
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


}
