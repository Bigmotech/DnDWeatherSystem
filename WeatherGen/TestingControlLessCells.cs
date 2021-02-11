using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherGen
{
    public partial class TestingControlLessCells : Form
    {
        const int numberOfLines = 5;
        
        public TestingControlLessCells()
        {
            InitializeComponent();
            
        }

        private void DrawLines()
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DrawLines();
        }

        private void Panel1_CursorChanged(object sender, EventArgs e)
        {
            label1.Text = Cursor.Position.ToString();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            int CellSizeX = panel1.Width / numberOfLines;
            int CellsizeY = panel1.Height / numberOfLines;
            for (int x = 1; x < numberOfLines; x++)
            {
                g.DrawLine(p, x * CellSizeX, 0, x * CellSizeX, panel1.Height);
            }
            for (int y = 1; y <= numberOfLines; y++)
            {
                //g.DrawLine(p, 0, 0, y * CellsizeY, panel1.Height);
            }
        }
    }
}
