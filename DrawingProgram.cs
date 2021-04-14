using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Drawer
    {
        static float x, y;
        static Graphics graph;

        public static void Initialize ( Graphics newGraph )
        {
            graph = newGraph;
            graph.SmoothingMode = SmoothingMode.None;
            graph.Clear(Color.Black);
        }

        public static void PositionOfSet(float x0, float y0)
        {
            x = x0; 
            y = y0;
        }

        public static void DrawLine(Pen activePen, double length, double angle)
        {
        //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graph.DrawLine(activePen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle)); 
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double angleOfTurn, Graphics graph)
        {
            // ugolPovorota пока не используется, но будет использоваться в будущем
            Drawer.Initialize(graph);
            double velZ = Math.Min(width, height);
            double diagonal = Math.Sqrt(2) * (velZ * 0.375f + velZ * 0.04f) / 2;
            var x0 = (float)(diagonal * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonal * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;
            Drawer.PositionOfSet(x0, y0);
            //Рисуем 1-ую сторону
            DrawSide1(velZ);
            //Рисуем 2-ую сторону
            DrawSide2(velZ);
            //Рисуем 3-ю сторону
            DrawSide3(velZ);
            //Рисуем 4-ую сторону
            DrawSide4(velZ);          
        }

        static void DrawSide1(double vz)
        {
            Drawer.DrawLine(Pens.Yellow, vz * 0.375f, 0);
            Drawer.DrawLine(Pens.Yellow, vz * 0.04f * Math.Sqrt(2), Math.PI / 4);
            Drawer.DrawLine(Pens.Yellow, vz * 0.375f, Math.PI);
            Drawer.DrawLine(Pens.Yellow, vz * 0.375f - vz * 0.04f, Math.PI / 2);

            Drawer.Change(vz * 0.04f, -Math.PI);
            Drawer.Change(vz * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);
        }

        static void DrawSide2(double vz)
        {
            Drawer.DrawLine(Pens.Yellow, vz * 0.375f, -Math.PI / 2);
            Drawer.DrawLine(Pens.Yellow, vz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
            Drawer.DrawLine(Pens.Yellow, vz * 0.375f, -Math.PI / 2 + Math.PI);
            Drawer.DrawLine(Pens.Yellow, vz * 0.375f - vz * 0.04f, -Math.PI / 2 + Math.PI / 2);

            Drawer.Change(vz * 0.04f, -Math.PI / 2 - Math.PI);
            Drawer.Change(vz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);
        }

        static void DrawSide3(double vz)
        {
            Drawer.DrawLine(Pens.Yellow, vz * 0.375f, Math.PI);
            Drawer.DrawLine(Pens.Yellow, vz * 0.04f * Math.Sqrt(2), Math.PI + Math.PI / 4);
            Drawer.DrawLine(Pens.Yellow, vz * 0.375f, Math.PI + Math.PI);
            Drawer.DrawLine(Pens.Yellow, vz * 0.375f - vz * 0.04f, Math.PI + Math.PI / 2);

            Drawer.Change(vz * 0.04f, Math.PI - Math.PI);
            Drawer.Change(vz * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);
        }

        static void DrawSide4(double vz)
        {
            Drawer.DrawLine(Pens.Yellow, vz * 0.375f, Math.PI / 2);
            Drawer.DrawLine(Pens.Yellow, vz * 0.04f * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
            Drawer.DrawLine(Pens.Yellow, vz * 0.375f, Math.PI / 2 + Math.PI);
            Drawer.DrawLine(Pens.Yellow, vz * 0.375f - vz * 0.04f, Math.PI / 2 + Math.PI / 2);

            Drawer.Change(vz * 0.04f, Math.PI / 2 - Math.PI);
            Drawer.Change(vz * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }
    }
}
