using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Serialization;
using WeatherGen.WeatherSystem;
using System.Xml;
using System.Drawing;
using System.Threading.Tasks;
using System.Reflection;

namespace WeatherGen
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        private bool flag = false;
        ContainerMap map;
        Bitmap mapPic;
        WeatherCelliconDisplay[][] l;

        public Form1()
        {
            InitializeComponent();

        }
        // test commit

        private void Form1_Load(object sender, EventArgs e)
        {
            mapPic = new Bitmap(@"C:\Users\Test\Desktop\Map.png");
            mapBox.Image = mapPic;
            mapBox.SizeMode = PictureBoxSizeMode.StretchImage;
            tableLayoutPanel1.CellPaint += TableLayoutPanel1_CellPaint;
            tableLayoutPanel1.MouseClick += TableLayoutPanel1_MouseClick;

        }

        private void TableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (l != null)
            {

                using (var b = new SolidBrush(l[e.Row][e.Column].cloudCover))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {


            LoadCellMap();

            map = new ContainerMap(tableLayoutPanel1.RowCount, tableLayoutPanel1.ColumnCount);
            flag = true;
            mapBox.Controls.Add(tableLayoutPanel1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.BackColor = Color.Transparent;
            UpdateMap();
        }


        private void LoadCellMap()
        {
            tableLayoutPanel1.Visible = false;


            for (int i = 0; i < CellCount.Value - 1; i++)
            {
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent));
                tableLayoutPanel1.ColumnCount++;
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
            }
            foreach (RowStyle r in tableLayoutPanel1.RowStyles)
            {
                r.SizeType = SizeType.Percent;
                r.Height = (float)(100 / CellCount.Value);
            }
            foreach (ColumnStyle r in tableLayoutPanel1.ColumnStyles)
            {
                r.SizeType = SizeType.Percent;
                r.Width = (float)(100 / CellCount.Value);
            }

            tableLayoutPanel1.Visible = true;
        }
        private void UpdateMap()
        {

            tableLayoutPanel1.Visible = false;
            map.RunFormDay(out l);
            for (int i = 0; i < l.Length; i++)
            {

                for (int j = 0; j < l[i].Length; j++)
                {

                    tableLayoutPanel1.Controls.Add(l[i][j], l[i][j].Cell.Coordinates[0], l[i][j].Cell.Coordinates[1]);

                }

            }
            tableLayoutPanel1.Visible = true;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                map.RunFormDay(out l);
                tableLayoutPanel1.Refresh();
                
            }
            else
            {
                MessageBox.Show("Please load the map first");
            }
        }





    }
}

