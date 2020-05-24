using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WeatherGen.WeatherSystem
{
    public partial class WeatherFormData : Form
    {
        
        public CellData Cell;
        private bool DisplayEdit = false;

        public WeatherFormData(CellData cell)
        {

            InitializeComponent();
            Cell = cell;
            TerrainButton.Text = cell.currentTerrian.ToString();
            this.StartPosition = FormStartPosition.CenterParent;
            Cell.PropertyChanged += Cell_PropertyChanged;
            Start();
        }

        private void Start()
        {
            RainCombo.SelectedItem = Cell.Statechange.ToString();
            LocalRainText.Text = Cell.LocalRain.ToString();
            OutgoingText.Text = Cell.OutgoingRain.ToString();
            IncomingText.Text = Cell.IncomingRain.ToString();
            TotalText.Text = Cell.TotalRain.ToString();
            RainLL.Text = ConditionsSystem.RainCondition(Cell.LocalRain);
        }

        private void WeatherControl_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            switch (e.PropertyName)
            {
                case "CurrentTerrian":

                    break;
                

            }

        }
        private void EditButton_Click(object sender, EventArgs e)
        {

            DisplayEdit = !DisplayEdit;
            LocalRainText.Enabled = !LocalRainText.Enabled;
            OutgoingText.Enabled = !OutgoingText.Enabled;
            IncomingText.Enabled = !IncomingText.Enabled;
            RainCombo.Enabled = !RainCombo.Enabled;

        }
        public void SendOutgoingRain(int row, int col)
        {

        }
        public void RunDayForm()
        {
            if (Cell.currentTerrian.Equals(Terrian.Mountain) || Cell.currentTerrian.Equals(Terrian.None))
            {
                Cell.LocalRain = 0;
                Cell.OutgoingRain = 0;
                Cell.IncomingRain = 0;
                Cell.TotalRain = 0;
            }
            else
            {
                WeatherSim.RunDay(Cell);
                RainCombo.SelectedItem = Cell.Statechange.ToString();
                LocalRainText.Text = Cell.LocalRain.ToString();
                OutgoingText.Text = Cell.OutgoingRain.ToString();
                IncomingText.Text = Cell.IncomingRain.ToString();
                TotalText.Text = Cell.TotalRain.ToString();
                RainLL.Text = ConditionsSystem.RainCondition(Cell.LocalRain);
                //CloudDirectionLL.Text = ConditionsSystem.CloudDirection(Cell.Direction);
                //TempLL.Text = ConditionsSystem.TempCondition(Cell.TempRange);
                //WindSpeedLL.Text = ConditionsSystem.WindCondition(Cell.TempRange);
                WeatherSim.ZeroIncoming(Cell);
            }
        }

        private void LocalRainText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (double.TryParse(LocalRainText.Text, out double localy))
                {
                    if (localy > 0)
                        Cell.LocalRain = localy;
                    else
                        Cell.LocalRain = 0;
                }
            }
        }

        //Textbox event to trigger Outgoing Rain Event
        private void OutgoingText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (double.TryParse(OutgoingText.Text, out double localy))
                {
                    if (localy > 0)
                    {
                        Cell.OutgoingRain = localy;
                        //(this, new OutGoingRainArgs(Cell.Coordinates[0], Cell.Coordinates[1]));
                    }
                    else
                    {
                        Cell.OutgoingRain = 0;
                    }
                }
            }
        }
        //Textbox event to trigger Incoming Rain Event
        private void IncomingText_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (double.TryParse(IncomingText.Text, out double localy))
                {
                    if (localy > 0)
                    {
                        Cell.IncomingRain = localy;
                        Cell.IncomingRainCheck = true;
                    }

                }
            }
        }

        private void TerrainButton_Click(object sender, EventArgs e)
        {
            Cell.currentTerrian++;
            if (Cell.currentTerrian == Terrian.None)
                Cell.currentTerrian = 0;
            TerrainButton.Text = Cell.currentTerrian.ToString();

        }
              
        private void RainCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cell.Statechange = (WeatherState)RainCombo.SelectedIndex + 1;
        }

        private void Cell_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "TempDiscription":

                    break;
                case "Statechange":
                    if (Cell.Statechange.Equals(WeatherState.Rain))
                    {
                        this.BackColor = Color.Navy;
                    }
                    else
                    {
                        this.BackColor = Color.Yellow;
                    }



                    break;
                case "IncomingRainCheck":
                    break;
                case "LocalRain":
                    LocalRainText.Text = Cell.LocalRain.ToString();
                    break;
                case "IncomingRain":
                    IncomingText.Text = Cell.IncomingRain.ToString();
                    break;
                case "OutgoingRain":
                    OutgoingText.Text = Cell.OutgoingRain.ToString();
                    break;
                case "TotalRain":
                    TotalText.Text = Cell.TotalRain.ToString();
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
                    if (Cell.currentTerrian.Equals(Terrian.Mountain))
                    {
                        LocalRainText.Hide();
                        OutgoingText.Hide();
                        IncomingText.Hide();
                        TotalText.Hide();
                        RainCombo.Hide();
                    }
                    else
                    {
                        LocalRainText.Show();
                        OutgoingText.Show();
                        IncomingText.Show();
                        TotalText.Show();
                        RainCombo.Show();
                    }


                    break;

            }
        }



        private void RainLL_MouseHover(object sender, EventArgs e)
        {
            ToolInfo.Show(ConditionsSystem.RainCondition(Cell.LocalRain), RainLL);
        }

        private void TempLL_MouseHover(object sender, EventArgs e)
        {
            //add temp funcation
        }

        private void RainLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Explained explained = new Explained(ConditionsSystem.RainCondition(Cell.LocalRain))
            {
                Location = new Point(RainLL.Location.X, RainLL.Location.Y)
            };
            explained.Show();

        }
    }
}
