using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherGen.WeatherSystem;

namespace WeatherGen
{
    public partial class WorldMap : Form
    {
        private bool flag = false;
        private ContainerMap map;
        private WorldData world;
        private Bitmap mapPic;
        private OpenFileDialog dialog;
        private CancellationTokenSource tokenSource;
        public event EventHandler<ResizedEventArgs> ResizeStart;
        public event EventHandler ResizeEnded;

        public WorldMap()
        {
            InitializeComponent();
            this.ResizeBegin += WorldMap_ResizeBegin;
            this.ResizeEnd += WorldMap_ResizeEnd;
            tokenSource = new CancellationTokenSource();
        }

        private void WorldMap_ResizeEnd(object sender, EventArgs e)
        {

            if (this.ResizeEnded != null)
            {
                this.ResizeEnded(null, null);
            }
            SizeCellsToPicture();


        }

        private void WorldMap_ResizeBegin(object sender, EventArgs e)
        {
            if (this.ResizeStart != null)
            {
                ResizedEventArgs rea = new ResizedEventArgs();
                rea.Height = mapBox.Height;
                rea.Width = mapBox.Width;
                rea.Rows = world.col;
                this.ResizeStart(null , rea);
            }
        }

        // test commit

        private void Form1_Load(object sender, EventArgs e)
        {


            mapBox.SizeMode = PictureBoxSizeMode.StretchImage;
            dialog = new OpenFileDialog();
            if (File.Exists(Properties.Settings.Default.picturePath))
            {
                FitTableToPicture();


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


        }

        private void StartLoad()
        {
            mapBox.Controls.Clear();
            flag = true;
            SizeCellsToPicture();
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

        private void RunDayButton_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                map.RunFormDay(out world.weatherMap);
                Datelabel.Text = world.GetCurrentDayYear();
                //SizeCellsToPicture();

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
                DialogResult result = dialog.ShowDialog();
                switch (result)
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
                        SizeCellsToPicture();

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
            map = new ContainerMap(world, false);
            Datelabel.Text = world.GetCurrentDayYear();
            AddEventsToCells();
            StartLoad();
            FitTableToPicture();
        }
        private void LoadWorldIntoApplicaiton(string mapPath)
        {
            Properties.Settings.Default.currentWorldPath = "";
            Properties.Settings.Default.picturePath = mapPath;
            Properties.Settings.Default.Save();
            this.Text = world.worldName;
            map = new ContainerMap(world, false);
            Datelabel.Text = world.GetCurrentDayYear();
            AddEventsToCells();
            StartLoad();
            FitTableToPicture();
            mapBox.Refresh();
        }

        private void AddEventsToCells()
        {
            foreach(WeatherCelliconDisplay[] wArray in world.weatherMap)
            {
                foreach(WeatherCelliconDisplay w in wArray)
                {
                    w.AddEventsThroughForm(this);
                }
            }
        }

        private void SaveAsMapButton_Click(object sender, EventArgs e)
        {

        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewWorld newWorld = new NewWorld();
            switch (newWorld.ShowDialog())
            {
                case DialogResult.Yes:
                    world = newWorld.Tag as WorldData;
                    LoadWorldIntoApplicaiton(world.mapPath);
                    SizeCellsToPicture();
                    break;
            }
        }

        private void SizeCellsToPicture()
        {

            if (world != null)
            {
                mapBox.Controls.Clear();
                float cellHeight = (float)mapBox.Height / (float)world.col;
                float cellWidth = (float)mapBox.Width / (float)world.col;
                Size cellSize = new Size((int)cellWidth, (int)cellHeight);

                for (int x = 0; x < world.col; x++)
                {
                    for (int y = 0; y < world.col; y++)
                    {
                        world.weatherMap[x][y].Size = cellSize;
                        world.weatherMap[x][y].Location = new Point((int)(x * cellWidth), (int)(y * cellHeight));
                        mapBox.Controls.Add(world.weatherMap[x][y]);

                    }
                }
            }

        }

    }

    public class ResizedEventArgs : EventArgs
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Rows { get; set; }
    }
}

