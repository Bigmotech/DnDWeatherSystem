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
            CloudcoverLL.Text = ConditionsSystem.CloudDirection(Cell);
            TempLL.Text = Cell.CurrentTemp.ToString();
            //WindSpeedLL.Text = ConditionsSystem.WindCondition(Cell.TempRange);
            if (Cell.Statechange.Equals(WeatherState.Rain))
            {
                this.BackColor = Color.Navy;
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

        private void RainLL_MouseHover(object sender, EventArgs e)
        {
            ToolInfo.Show(ConditionsSystem.RainCondition(Cell.LocalRain), RainLL);
        }

        private void TempLL_MouseHover(object sender, EventArgs e)
        {
            ToolInfo.Show(ConditionsSystem.TempCondition(Cell.CurrentTemp), TempLL);
        }

        private void RainLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void TempLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
