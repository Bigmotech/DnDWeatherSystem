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
            this.Dock = DockStyle.Fill;
        }
        public WeatherCelliconDisplay(CellData cell)
        {
            InitializeComponent();
            Cell = cell;
            Cell.PropertyChanged += ControlForm_PropertyChanged;
        }


        private void ControlForm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Statechange":
                    switch (Cell.Statechange)
                    {
                        case WeatherState.NoRain:
                            //linkLabel1.Image = new Bitmap(Properties.Resources.sunny, linkLabel1.Size);
                            cloudCover = Color.Transparent;

                            break;
                        case WeatherState.Rain:
                            //linkLabel1.Image = new Bitmap(WeatherGen.Properties.Resources.rainnyday, linkLabel1.Size);
                            cloudCover = Color.FromArgb(50, Color.DeepSkyBlue);
                            break;

                    }
                    break;

                case "FirstDay":
                    break;
                case "IsCloudy":
                    this.BackColor = Color.FromArgb(50, Color.LightGray);
                    break;
                case "TempDiscription":
                    break;
                case "PrevState":
                    break;
                case "IncomingRainCheck":
                    break;
                case "LocalRain":
                    break;
                case "IncomingRain":
                    break;
                case "OutgoingRain":
                    OnOutgoingRainChange();
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
                    break;
                case "SurroundedFlag":
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
