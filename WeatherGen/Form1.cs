using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WeatherGen.WeatherSystem;

namespace WeatherGen
{
    public partial class Form1 : Form
    {
        private bool flag = false;
        private ContainerMap map;
        private WorldData world;
        private Bitmap mapPic;
        private OpenFileDialog dialog;

        public Form1()
        {
            InitializeComponent();
            tableLayoutPanel1.AutoScroll = false;
        }
        // test commit

        private void Form1_Load(object sender, EventArgs e)
        {
            dialog = new OpenFileDialog();
            if (File.Exists(Properties.Settings.Default.picturePath))
            {
                FitTableToPicture();
                tableLayoutPanel1.CellPaint += TableLayoutPanel1_CellPaint;
                tableLayoutPanel1.MouseClick += TableLayoutPanel1_MouseClick;
                
                
            }
            else
            {
                //LoadMap();
                //FitTableToPicture();
                

            }

        }


        private void FitTableToPicture()
        {
            
            mapPic = new Bitmap(Properties.Settings.Default.picturePath);
            mapBox.Image = mapPic;
            mapBox.SizeMode = PictureBoxSizeMode.StretchImage;
            

        }

        private void TableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void TableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (world.weatherMap != null )
            {

                using (var b = new SolidBrush(world.weatherMap[e.Column][e.Row].cloudCover))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }
            }
        }

        private void StartLoad()
        {
            mapBox.Controls.Clear();
            flag = true;
            mapBox.Controls.Add(tableLayoutPanel1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.BackColor = Color.Transparent;
            UpdateMap();
        }
        private void ReloadGrid()
        {

        }

        private void LoadCellMap()
        {
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.ColumnCount = 0;
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            
            for (int i = 0; i < world.col; i++)
            {
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, (float)(100 / world.col)));
                tableLayoutPanel1.ColumnCount++;
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)(100 / world.col)));

            }
            
            tableLayoutPanel1.Visible = true;
        }
        private void UpdateMap()
        {

            tableLayoutPanel1.Visible = false;
            tableLayoutPanel1.Controls.Clear();
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
            
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
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

            world = new WorldData("TestWorld", Properties.Settings.Default.picturePath, world.col, world.col);
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
                Datelabel.Text = world.GetCurrentDayYear();

            }
            else
            {
                MessageBox.Show("Please load a map first");
            }
        }

        private void SaveMapButton_Click(object sender, EventArgs e)
        {
            if (flag)
                world.SaveWorld(Properties.Settings.Default.currentWorldPath);
            else
                MessageBox.Show("Please load a map first");
        }

        private void LoadMapButton_Click(object sender, EventArgs e)
        {
            try
            {
                dialog.Filter = "World Json (*.json) | *.json;";
                dialog.Title = "Please select a World Json.";

                switch (dialog.ShowDialog())
                {
                    case DialogResult.Cancel:

                    case DialogResult.No:

                    case DialogResult.Abort:

                        MessageBox.Show("Nothing was loaded");

                        break;
                    case DialogResult.OK:
                    case DialogResult.Yes:
                        world = JsonConvert.DeserializeObject<WorldData>(File.ReadAllText(dialog.FileName));
                        LoadWorldIntoApplicaiton(dialog.FileName, world.mapPath);

                        break;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load file " + ex.Message);

            }
        }

        private void LoadWorldIntoApplicaiton(string fileName, string mapPath)
        {
            Properties.Settings.Default.currentWorldPath = fileName;
            Properties.Settings.Default.picturePath = mapPath;
            Properties.Settings.Default.Save();
            this.Text = world.worldName;
            LoadCellMap();
            map = new ContainerMap(world);
            StartLoad();
            FitTableToPicture();
        }
        private void LoadWorldIntoApplicaiton(string mapPath)
        {
            Properties.Settings.Default.currentWorldPath = "";
            Properties.Settings.Default.picturePath = mapPath;
            Properties.Settings.Default.Save();
            this.Text = world.worldName;
            LoadCellMap();
            map = new ContainerMap(world);
            map.RunFormDay(out world.weatherMap);
            StartLoad();
            FitTableToPicture();
        }

        private void SaveAsMapButton_Click(object sender, EventArgs e)
        {

        }

        private void ClearPicBoxButton_Click(object sender, EventArgs e)
        {
            LoadCellMap();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewWorld newWorld = new NewWorld();
            switch (newWorld.ShowDialog())
            {
                case DialogResult.Yes:
                    world = newWorld.Tag as WorldData;
                    LoadWorldIntoApplicaiton(world.mapPath);
                    break;
            }
        }

    }
}

