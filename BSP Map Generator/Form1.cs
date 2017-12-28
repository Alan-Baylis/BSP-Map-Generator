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
        int MAX_WIDTH;        
        List<Leaf> leafs = new List<Leaf>();
        Leaf root;
        bool didSplit = true;        

        public Form1()
        {
            InitializeComponent();
        }

        private void btBuild_Click(object sender, EventArgs e)
        {
            leafs = new List<Leaf>();
            MAX_SIZE = Convert.ToInt32(tbMaxSize.Text);

            StaticData.Scale = Convert.ToInt32(tbScale.Text);
            StaticData.SplitHorArg = Convert.ToDouble(tbSplit.Text);
            StaticData.MaxWidth = 25;
            StaticData.MaxHeight = 10;
            StaticData.ResetRoomCount();
            
            root = new Leaf(0, 0, 950, 500);
            leafs.Add(root);
            didSplit = true;

            while (didSplit)
            {
                didSplit = false;

                for (int i = 0; i < leafs.Count; i++)
                {
                    if (leafs[i].leftChild == null && leafs[i].rightChild == null)
                    {
                        if (leafs[i].width > StaticData.MaxWidth || leafs[i].height > StaticData.MaxHeight || StaticData.rng.NextDouble() > 0.99999)
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
            tbRoomCount.Text = Convert.ToString(StaticData.RoomCount);

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

                if (leafs[i].RoomExist)
                {                    
                    rect = new Rectangle(leafs[i].room.X, leafs[i].room.Y, leafs[i].room.Width, leafs[i].room.Height);
                    e.Graphics.DrawRectangle(roomPen, rect);

                    Font f = new Font("Roboto", 14);
                    e.Graphics.DrawString(Convert.ToString(leafs[i].RoomID), f, Brushes.Black, rect.X, rect.Y);
                }

                

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

        private void tbBreak_Click(object sender, EventArgs e)
        {

        }
    }
}
