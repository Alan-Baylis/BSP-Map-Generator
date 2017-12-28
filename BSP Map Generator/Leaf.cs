using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace BSP_Map_Generator
{
    public static class StaticData
    {
        private static int scale;
        private static double splitHorArg;
        public static Random rng;

        static StaticData()
        {
            rng = new Random(Environment.TickCount);
            scale = 10;
            splitHorArg = 0.2;
        }

        public static int Scale
        {
            get
            {
                return scale;
            }

            set
            {
                scale = value;
            }
        }

        public static double SplitHorArg
        {
            get
            {
                return splitHorArg;
            }

            set
            {
                splitHorArg = value;
            }
        }
       
    }

    public class Leaf
    {
        private int MIN_SIZE = 6*StaticData.Scale;

        public int x, y;
        public int width, height;
        //private int scale = StaticData.Scale;        

        public Leaf leftChild;
        public Leaf rightChild;
        public Rectangle room;
        public List<Rectangle> halls;

        public Leaf(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }       

        public bool Split()
        {
            if (leftChild != null || rightChild != null)
            {
                return false;
            }

            bool splitH = StaticData.rng.NextDouble() > StaticData.SplitHorArg;

            if (width > height && width / height >= 1.25)
            {
                splitH = false;
            }

            else if (height > width && height / width >= 1.25)
            {
                splitH = true;
            }

            int max = (splitH ? height : width) - MIN_SIZE;

            if (max <= MIN_SIZE)
            {
                return false;
            }

            int split = StaticData.rng.Next(MIN_SIZE, max);

            if (splitH)
            {
                leftChild = new Leaf(x, y, width, split);
                rightChild = new Leaf(x, y + split, width, height - split);
            }
            else
            {
                leftChild = new Leaf(x, y, split, height);
                rightChild = new Leaf(x + split, y, width - split, height);
            }

            return true;
        }

        public void CreateRooms()
        {
            if (leftChild != null || rightChild != null)
            {
                if (leftChild != null)
                {
                    leftChild.CreateRooms();
                }

                if (rightChild != null)
                {
                    rightChild.CreateRooms();
                }

                if (leftChild != null && rightChild != null)
                {
                    CreateHall(leftChild.GetRoom(), rightChild.GetRoom());
                }
            }

            else
            {
                Point roomSize;
                Point roomPos;

                roomSize = new Point(StaticData.rng.Next(3*StaticData.Scale, width - 2*StaticData.Scale), StaticData.rng.Next(3*StaticData.Scale, height - 2*StaticData.Scale));
                roomPos = new Point(StaticData.rng.Next(StaticData.Scale, width - roomSize.X - StaticData.Scale), StaticData.rng.Next(StaticData.Scale, height - roomSize.Y - StaticData.Scale));
                room = new Rectangle(x + roomPos.X, y + roomPos.Y, roomSize.X, roomSize.Y);
            }
        }

        public Rectangle GetRoom()
        {
            if (room != default(Rectangle))
            {
                return room;
            }
            else
            {
                Rectangle lRoom = default(Rectangle);
                Rectangle rRoom = default(Rectangle);
                

                if (leftChild != null)
                {
                    lRoom = leftChild.GetRoom();
                }

                if (rightChild != null)
                {
                    rRoom = rightChild.GetRoom();
                }

                if (lRoom == default(Rectangle) && rRoom == default(Rectangle))
                {
                    return default(Rectangle);
                }
                else if (rRoom == default(Rectangle))
                {
                    return lRoom;
                }                    
                else if (lRoom == default(Rectangle))
                {
                    return rRoom;
                }                   
                else if (StaticData.rng.NextDouble() > 0.5)
                {
                    return lRoom;
                }
                else
                {
                    return rRoom;
                }
            }
        }

        public void CreateHall(Rectangle l, Rectangle r)
        {
            halls = new List<Rectangle>();
            Point point1 = new Point(StaticData.rng.Next(l.Left + StaticData.Scale, l.Right - 2 * StaticData.Scale), StaticData.rng.Next(l.Top + StaticData.Scale, l.Bottom - 2 * StaticData.Scale));
            Point point2 = new Point(StaticData.rng.Next(r.Left + StaticData.Scale, r.Right - 2 * StaticData.Scale), StaticData.rng.Next(r.Top + StaticData.Scale, r.Bottom - 2 * StaticData.Scale));

            int w = point2.X - point1.X;
            int h = point2.Y - point1.X;

            if (w < 0)
            {
                if (h < 0)
                {
                    if (StaticData.rng.NextDouble() < 0.5)
                    {
                        halls.Add(new Rectangle(point2.X, point1.Y, Math.Abs(w), StaticData.Scale));
                        halls.Add(new Rectangle(point2.X, point2.Y, StaticData.Scale, Math.Abs(h)));
                    }
                    else
                    {
                        halls.Add(new Rectangle(point2.X, point2.Y, Math.Abs(w), StaticData.Scale));
                        halls.Add(new Rectangle(point1.X, point2.Y, StaticData.Scale, Math.Abs(h)));
                    }
                }
                else if (h > 0)
                {
                    if (StaticData.rng.NextDouble() < 0.5)
                    {
                        halls.Add(new Rectangle(point2.X, point1.Y, Math.Abs(w), StaticData.Scale));
                        halls.Add(new Rectangle(point2.X, point1.Y, StaticData.Scale, Math.Abs(h)));
                    }
                    else
                    {
                        halls.Add(new Rectangle(point2.X, point2.Y, Math.Abs(w), StaticData.Scale));
                        halls.Add(new Rectangle(point1.X, point1.Y, StaticData.Scale, Math.Abs(h)));
                    }
                }
                else
                {
                    halls.Add(new Rectangle(point2.X, point2.Y, Math.Abs(w), StaticData.Scale));
                }
            }
            else if (w > 0)
            {
                if (h < 0)
                {
                    if (StaticData.rng.NextDouble() < 0.5)
                    {
                        halls.Add(new Rectangle(point1.X, point2.Y, Math.Abs(w), StaticData.Scale));
                        halls.Add(new Rectangle(point1.X, point2.Y, StaticData.Scale, Math.Abs(h)));
                    }
                    else
                    {
                        halls.Add(new Rectangle(point1.X, point1.Y, Math.Abs(w), StaticData.Scale));
                        halls.Add(new Rectangle(point2.X, point2.Y, StaticData.Scale, Math.Abs(h)));
                    }
                }
                else if (h > 0)
                {
                    if (StaticData.rng.NextDouble() < 0.5)
                    {
                        halls.Add(new Rectangle(point1.X, point1.Y,Math.Abs(w), StaticData.Scale));
                        halls.Add(new Rectangle(point2.X, point1.Y, StaticData.Scale, Math.Abs(h)));
                    }
                    else
                    {
                        halls.Add(new Rectangle(point1.X, point2.Y, Math.Abs(w), StaticData.Scale));
                        halls.Add(new Rectangle(point1.X, point1.Y, StaticData.Scale, Math.Abs(h)));
                    }
                }
                else
                {
                    halls.Add(new Rectangle(point1.X, point1.Y, Math.Abs(w), StaticData.Scale));
                }
            }
            else
            {
                if (h < 0)
                {
                    halls.Add(new Rectangle(point2.X, point2.Y, StaticData.Scale, Math.Abs(h)));
                }
                else if (h > 0)
                {
                    halls.Add(new Rectangle(point1.X, point1.Y, StaticData.Scale, Math.Abs(h)));
                }
            }
        }
    }  
}
