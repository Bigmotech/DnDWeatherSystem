using System;
using System.Windows.Forms;
using WeatherGen.WeatherSystem;

namespace WeatherGen
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        private bool flag = false;
        ContainerMap map;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.texas;
            
        }
        

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

        private void Button2_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel1.Controls.Clear();
                WeatherCelliconDisplay[][] l = map.RunFormDay();
                
                for (int i = 0; i < l.Length; i++)
                {
                    

                    for (int j = 0; j < l[i].Length; j++)
                    {
                        tableLayoutPanel1.Controls.Add(l[i][j], l[i][j].Cell.Coordinates[0], l[i][j].Cell.Coordinates[1]);
                    }
                    
                }

                //foreach (WeatherControlContainer i in l)
                //{
                //     tableLayoutPanel1.Controls.Add(i);
                //    
                //}
                tableLayoutPanel1.Visible = true;
            }
            else
            {
                MessageBox.Show("Please load the map first");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            
            foreach(CellData j in weathers)
            {
                WeatherSystem.WeatherSim.RunDay(j);
            }
            stopwatch.Stop();
            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());

        }
        System.Collections.Generic.List<CellData> weathers = new System.Collections.Generic.List<CellData>();
        private void button4_Click(object sender, EventArgs e)
        {

            map = new ContainerMap(1000, 1000);
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Size = tableLayoutPanel1.Size;
        }

        private void open_Temp_Btn_Click(object sender, EventArgs e)
        {
            TempStuff temp = new TempStuff();
            if(temp.ShowDialog() == DialogResult.OK)
            {
                // Do nothing
            }
        }
    }
}

