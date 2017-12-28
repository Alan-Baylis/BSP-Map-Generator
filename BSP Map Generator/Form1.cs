using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSP_Map_Generator
{
    public partial class Form1 : Form
    {
        int MAX_SIZE = 40;
        List<Leaf> leafs = new List<Leaf>();
        Leaf root;
        bool didSplit = true;
        Random rng = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void btBuild_Click(object sender, EventArgs e)
        {
            leafs = new List<Leaf>();
            MAX_SIZE = Convert.ToInt32(tbMaxSize.Text);
            StaticData.Scale = Convert.ToInt32(tbScale.Text);
            //StaticData.SplitHorArg = Convert.ToDouble(tbScale.Text);
            root = new Leaf(0, 0, 950, 500);
            leafs.Add(root);

            while (didSplit)
            {
                didSplit = false;

                for (int i = 0; i < leafs.Count; i++)
                {
                    if (leafs[i].leftChild == null && leafs[i].rightChild == null)
                    {
                        if (leafs[i].width > MAX_SIZE || leafs[i].height > MAX_SIZE || rng.NextDouble() > 0.25)
                        {
                            if (leafs[i].Split())
                            {
                                leafs.Add(leafs[i].leftChild);
                                leafs.Add(leafs[i].rightChild);

                                didSplit = true;
                            }
                        }
                    }
                }
            }

            root.CreateRooms();

            MessageBox.Show("Construction completed successfully");
        }

        private void btDrawMap_Click(object sender, EventArgs e)
        {
            pbMap.Refresh();
        }

        private void pbMap_Paint(object sender, PaintEventArgs e)
        {
            Pen zonePen = new Pen(Color.Red, 2);
            Pen roomPen = new Pen(Color.Black, 5);
            Pen hallPen = new Pen(Color.Black, 2);
            Rectangle rect;
           

            for (int i = 0; i < leafs.Count; i++)
            {
                rect = new Rectangle(leafs[i].x, leafs[i].y, leafs[i].width, leafs[i].height);
                e.Graphics.DrawRectangle(zonePen, rect);

                rect = new Rectangle(leafs[i].room.X, leafs[i].room.Y, leafs[i].room.Width, leafs[i].room.Height);
                e.Graphics.DrawRectangle(roomPen, rect);

               /* if (leafs[i].halls != null)
                {
                    for (int j = 0; j < leafs[i].halls.Count; j++)
                    {
                        rect = new Rectangle(leafs[i].halls[j].X, leafs[i].halls[j].Y, leafs[i].halls[j].Width, leafs[i].halls[j].Height);
                        e.Graphics.DrawRectangle(hallPen, rect);
                    }
                }*/
                
            }
            
        }
    }
}
