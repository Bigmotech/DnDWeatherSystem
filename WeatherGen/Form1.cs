using System;
using System.Drawing;
using System.Windows.Forms;
using WeatherGen.WeatherSystem;

namespace WeatherGen
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        private bool flag = false;
        ContainerMap map;
        WeatherCelliconDisplay[][] l;
        public Form1()
        {
            InitializeComponent();
            
        }
        // test commit

        private void Form1_Load(object sender, EventArgs e)
        {


            
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            
            LoadCellMap();
             map = new ContainerMap(tableLayoutPanel1.RowCount, tableLayoutPanel1.ColumnCount);
            flag = true;
        }


        private void LoadCellMap()
        {
            tableLayoutPanel1.Visible = false;

            for (int i = 0; i < CellCount.Value - 1; i++)
            {
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.ColumnCount++;
            }
            foreach (RowStyle r in tableLayoutPanel1.RowStyles)
                r.SizeType = SizeType.AutoSize;
            foreach (ColumnStyle r in tableLayoutPanel1.ColumnStyles)
                r.SizeType = SizeType.AutoSize;

            tableLayoutPanel1.Visible = true;
        }
        bool firstrun = true;
        private void Button2_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                if (firstrun)
                {
                    tableLayoutPanel1.Visible = false;
                    //tableLayoutPanel1.Controls.Clear();
                    map.RunFormDay(out l);

                    for (int i = 0; i < l.Length; i++)
                    {


                        for (int j = 0; j < l[i].Length; j++)
                        {
                            tableLayoutPanel1.Controls.Add(l[i][j], l[i][j].Cell.Coordinates[0], l[i][j].Cell.Coordinates[1]);
                        }

                    }
                    
                    tableLayoutPanel1.Visible = true;
                    firstrun = false;
                }
                else
                {
                    map.RunFormDay(out l);
                }
            }
            else
            {
                MessageBox.Show("Please load the map first");
            }
        }



        private void open_Temp_Btn_Click(object sender, EventArgs e)
        {
            //TempStuff temp = new TempStuff();
           // if(temp.ShowDialog() == DialogResult.OK)
            //{
                // Do nothing
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1001; i++)
                map.RunFormDay(out l);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

