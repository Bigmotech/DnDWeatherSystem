using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Serialization;
using WeatherGen.WeatherSystem;
using System.Xml;
using System.Drawing;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using WeatherGen.Properties;

namespace WeatherGen
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        private bool flag = false;
        ContainerMap map;
        WorldData world;
        Bitmap mapPic;

        public Form1()
        {
            InitializeComponent();
        }
        // test commit

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Properties.Settings.Default.picturePath))
            {
                FitTableToPicture();
            }
            else
            {
                LoadMap();
                FitTableToPicture();
                

            }
            
        }

        private void FitTableToPicture()
        {
            mapPic = new Bitmap(Properties.Settings.Default.picturePath);
            mapBox.Image = mapPic;
            mapBox.SizeMode = PictureBoxSizeMode.StretchImage;
            tableLayoutPanel1.CellPaint += TableLayoutPanel1_CellPaint;
            tableLayoutPanel1.MouseClick += TableLayoutPanel1_MouseClick;
        }

        private void TableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void TableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (world.weatherMap != null)
            {

                using (var b = new SolidBrush(world.weatherMap[e.Column][e.Row].cloudCover))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }
            }
        }

        private void StartLoad()
        {
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
            //map.RunFormDay(out world.weatherMap);
            for (int i = 0; i < world.weatherMap.Length; i++)
            {

                for (int j = 0; j < world.weatherMap[i].Length; j++)
                {

                    tableLayoutPanel1.Controls.Add(world.weatherMap[i][j], world.weatherMap[i][j].Cell.Coordinates[0], world.weatherMap[i][j].Cell.Coordinates[1]);

                }

            }
            tableLayoutPanel1.Visible = true;

        }


        private void LoadMap()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.png";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select an image file.";

            switch (dialog.ShowDialog())
            {
                case DialogResult.Cancel:

                case DialogResult.No:

                case DialogResult.Abort:
                    break;
                case DialogResult.OK:
                case DialogResult.Yes:
                    Properties.Settings.Default.picturePath = dialog.FileName;
                    Properties.Settings.Default.Save();
                    break;
            }
        }

        private void LoadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMap();
            FitTableToPicture();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();

        }

        private void LoadWeather_Click(object sender, EventArgs e)
        {
            world = new WorldData("TestWorld", Properties.Settings.Default.picturePath, (int)CellCount.Value, (int)CellCount.Value);
            map = new ContainerMap(world);
            LoadCellMap();
            StartLoad();
        }

        private void RunDayButton_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                map.RunFormDay(out world.weatherMap);
                tableLayoutPanel1.Refresh();

            }
            else
            {
                MessageBox.Show("Please load the map first");
            }
        }

        private void SaveMapButton_Click(object sender, EventArgs e)
        {
            world.SaveWorld();
        }

        private void LoadMapButton_Click(object sender, EventArgs e)
        {
            try
            {

                world = JsonConvert.DeserializeObject<WorldData>(File.ReadAllText(@"C: \Users\Test\Desktop\TestWorld.json"));
                CellCount.Value = world.row;
                Properties.Settings.Default.picturePath = world.mapPath;
                Properties.Settings.Default.Save();
                LoadCellMap();
                map = new ContainerMap(world);
                StartLoad();
                FitTableToPicture();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load file " + ex.Message);

            }
        }
    }
}

