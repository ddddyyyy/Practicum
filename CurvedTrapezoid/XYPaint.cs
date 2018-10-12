using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AreaCalculate;

namespace CurvedTrapezoid
{
    class XYPaint
    {
        //坐标轴与上和左的边距
        static float tab = 50;
        static int cells = 20;
        float YNum;
        float XNum;
        float height;

        //画笔
        Graphics g;

        /// <summary>
        /// 绘制XY坐标的类
        /// </summary>
        /// <param name="from">目标视图</param>
        /// /// <param name="x">坐标轴的x的最大值</param>
        /// /// <param name="y">坐标轴的y的最大值</param>
        public XYPaint(Form from, float x, float y)
        {
            //初始化画笔
            g = from.CreateGraphics();

            //坐标轴的高和宽
            height = from.Height - 3 * tab;
            float width = from.Width - 2 * tab;
            //每一格的长度
            float YLen = (height / cells);
            float XLen = (width / cells);
            //1px对应的x,y值
            YNum = height / y ;
            XNum = width / x ;

            this.DrawYLine(from, 0, y, cells, height);
            this.DrawXLine(from, 0, x, cells, width, height);
            this.DrawPoint();
        }

        /// <summary>
        /// 画Y轴
        /// </summary>
        /// <param name="pan">目标容器</param>
        /// <param name="minY">最小的Y值</param>
        /// <param name="maxY">最大的Y值</param>
        /// <param name="cells">多少格</param>
        /// <param name="height">Y轴的高度</param>
        private void DrawYLine(Form pan, float minY, float maxY, int cells, float height)
        {
            //每一格的长度
            float Len = (height / cells);
            g.DrawLine(new Pen(Brushes.Red, 2), new PointF(tab, tab), new PointF(tab, height + tab));
            for (int i = 0; i <= cells; i++)    //len等份Y轴
            {
                //绘制分割线
                PointF px1 = new PointF(tab, Len * i + tab);
                PointF px2 = new PointF(tab + 4, Len * i + tab);
                g.DrawLine(new Pen(Brushes.Black, 2), px1, px2);
                //绘制数值
                string sx = (maxY - (maxY - minY) * i / cells).ToString();
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Far;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(sx, new Font("宋体", 8f), Brushes.Black, new PointF(tab / 1.2f, Len * i + tab * 1.1f), drawFormat);
            }
            Pen pen = new Pen(Color.Black, 1);
            g.DrawString("Y轴", new Font("宋体 ", 10f), Brushes.Black, new PointF(tab / 3, tab / 2f));
        }

        /// <summary>
        /// 绘制X轴
        /// </summary>
        /// <param name="pan"></param>
        /// <param name="minX"></param>
        /// <param name="maxX"></param>
        /// <param name="cells"></param>
        /// <param name="width"></param>
        /// <param name="height">Y轴的高度</param>
        private void DrawXLine(Form pan, float minX, float maxX, int cells, float width,float height)
        {
            //每一格的长度
            float Len = (width / cells);
            //绘制直线
            g.DrawLine(new Pen(Brushes.Red, 2), new PointF(tab, height + tab), new PointF(width + tab, height + tab));
            for (int i = 0; i <= cells; i++)
            {
                //绘制分割线
                PointF px1 = new PointF(Len * i + tab, height + tab - 4);
                PointF px2 = new PointF(Len * i + tab, height + tab );
                g.DrawLine(new Pen(Brushes.Black, 2), px1, px2);

                string sx = ((maxX - minX) * i / cells).ToString();
                //设置字符格式
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Far;
                drawFormat.LineAlignment = StringAlignment.Center;
                //绘制数值
                g.DrawString(sx, new Font("宋体", 8f), Brushes.Black, new PointF(tab*1.1f + Len * i, height + 2*tab - tab/1.2f), drawFormat);
            }
            Pen pen = new Pen(Color.Black, 1);
            g.DrawString("X轴", new Font("宋体 ", 10f), Brushes.Black, new PointF(width + tab*1.1f , height + 2*tab - tab/1.5f));
        }

        /// <summary>
        /// 绘制点，要求数组之间两两对应
        /// </summary>
        /// <param name="x">x坐标的数组</param>
        /// <param name="y">y坐标的数组</param>
        public void DrawPoint()
        {
            //生成随机的图形，这里的x和y均为100，100
            UShape shape = new UShape(((float[])DataMaker.Making((int)DateTime.Now.Ticks, 30).ToArray(typeof(float))));
            //绘制点
            foreach (Coordinate c in shape.coordinates)
            {
                Brush bush = new SolidBrush(Color.Green);//填充的颜色
                g.FillEllipse(bush, tab + c.x * XNum - 2.5f, tab + height - c.y * YNum - 2.5f, 5, 5);//画填充椭圆的方法，x坐标、y坐标、宽、高，如果是100，则半径为50
            }
            //绘制两点之间的直线
            for (int i = 0;i<shape.coordinates.Length - 1; ++i)
            {
                g.DrawLine(new Pen(Brushes.Blue, 2), new PointF(tab + shape.coordinates[i].x * XNum, tab + height - shape.coordinates[i].y * YNum), new PointF(tab + shape.coordinates[i+1].x * XNum, tab + height - shape.coordinates[i+1].y * YNum));
            }
        }

    }
}
