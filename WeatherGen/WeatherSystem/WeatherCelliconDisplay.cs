using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WeatherGen.WeatherSystem
{
    [JsonObject(MemberSerialization.OptIn)]
    public partial class WeatherCelliconDisplay : UserControl
    {
        [JsonProperty]
        public CellData Cell;
        public delegate void OutgoingRainEventHandler(object sender, OutgoingRainEventArgs e);

        public event OutgoingRainEventHandler OutgoingRainEvent;
        [JsonProperty]
        public Color cloudCover { get; set; }





        public WeatherCelliconDisplay()
        {
            InitializeComponent();
            Cell = new CellData();
            this.Visible = false;
            
        }
        public WeatherCelliconDisplay(CellData cell)
        {
            InitializeComponent();
            this.ForeColor = Color.FromArgb(120, 255, 255, 255);
            linkLabel1.FlatAppearance.BorderColor = Color.FromArgb(120, 255, 255, 255);
            linkLabel1.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 255, 255, 255);
            Cell = cell;
            Cell.PropertyChanged += ControlForm_PropertyChanged;
            switch (Cell.Statechange)
            {
                case WeatherState.NoRain:

                    cloudCover = Color.Transparent;

                    break;
                case WeatherState.Rain:

                    cloudCover = Color.FromArgb(50, Color.DeepSkyBlue);
                    this.BackColor = Color.FromArgb(50, Color.DeepSkyBlue);
                    break;

            }

        }
        public void AddEventsThroughForm(WorldMap worldMap)
        {
            worldMap.ResizeStart += WorldMap_ResizeStart;
            worldMap.ResizeEnded += WorldMap_ResizeEnded; 
        }

        private void WorldMap_ResizeEnded(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void WorldMap_ResizeStart(object sender, ResizedEventArgs e)
        {
            
            float newCellHeight = (float)(e.Height / e.Rows);
            float newCellWidth = (float)(e.Width / e.Rows);
            this.Visible = false;
            this.Size = new Size((int)newCellWidth, (int)newCellHeight);
            this.Location = new Point((int)(newCellWidth * Cell.Coordinates[0]), (int)(newCellHeight * Cell.Coordinates[1]));

        }

        private void ControlForm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Statechange":
                    switch (Cell.Statechange)
                    {
                        case WeatherState.NoRain:

                            cloudCover = Color.Transparent;
                            this.BackColor = Color.Transparent;
                            break;
                        case WeatherState.Rain:
                            cloudCover = Color.FromArgb(50, Color.DeepSkyBlue);
                            this.BackColor = Color.FromArgb(50, Color.DeepSkyBlue);
                            break;

                    }
                    
                    break;

                case "FirstDay":
                    break;
                case "IsCloudy":
                    this.BackColor = Color.FromArgb(50, Color.LightGray);
                    break;
                case "OutgoingRain":
                    OnOutgoingRainChange();
                    break;
                case "CurrentTemp":
                    break;

                case "IncomingRainCheck":
                    break;
                case "LocalRain":
                    break;
                case "IncomingRain":
                    break;
                case "TotalRain":
                    break;
                case "TempRange":
                    break;
                case "MaxTemp":
                    break;
                case "MinTemp":
                    break;
                case "Direction":
                    //CloudDirectionLL.Text = Cell.Direction.ToString();
                    break;
                case "SurroundedFlag":
                    break;
                case "currentTerrian":
                    break;

            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            WeatherCellDisplayInfo.Show(Cell);
        }

        public void OnOutgoingRainChange()
        {
            OutgoingRainEvent?.Invoke(this, new OutgoingRainEventArgs(Cell));
        }
       
    }

    public class OutgoingRainEventArgs : EventArgs
    {
        public CellData cell { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public OutgoingRainEventArgs(CellData e) { cell = e; Row = e.Coordinates[0]; Column = e.Coordinates[1]; }
    }

    
}
