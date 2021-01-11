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
    public partial class NewWorld : Form
    {
        private string mapPath;
        private Graphics g;
        public NewWorld()
        {
            InitializeComponent();
            g = previewPicBox.CreateGraphics();
        }

        private void PictureBox1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void PictureBox1_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void AddPictureButton_Click(object sender, EventArgs e)
        {
            try
            {
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.png";
                dialog.Title = "Please select an image file.";

                switch (dialog.ShowDialog())
                {
                    case DialogResult.Cancel:

                    case DialogResult.No:

                    case DialogResult.Abort:
                        break;
                    case DialogResult.OK:
                    case DialogResult.Yes:
                        
                        Bitmap selectedPic = new Bitmap(dialog.FileName);
                        mapPath = dialog.FileName;
                        previewPicBox.Load(dialog.FileName);
                        removeMapLinkLabel.Visible = true;
                        addPictureButton.Visible = false;
                        gridSize.Enabled = true;
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            
            //g.Clear(Color.Transparent);
            previewPicBox.Refresh();
            Pen p = new Pen(Color.Black);
            float cellSizepercent = (100 / (float)gridSize.Value) / 100;
            float cellSizeX = previewPicBox.Height * cellSizepercent;
            float cellSizeY = previewPicBox.Width * cellSizepercent;
            for (int y = 0; y < gridSize.Value + 1; ++y)
            {
                g.DrawLine(p, 0, y * cellSizeY, (float)gridSize.Value * cellSizeY, y * cellSizeY);
            }

            for (int x = 0; x < gridSize.Value + 1; ++x)
            {
                g.DrawLine(p, x * cellSizeX, 0, x * cellSizeX, (float)gridSize.Value * cellSizeX);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(worldNameTB.Text) && gridSize.Value != 0)
            {
                this.Tag = new WeatherGen.WeatherSystem.WorldData(worldNameTB.Text, mapPath, (int)gridSize.Value, (int)gridSize.Value);
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Fill in Grid Size and World Name");
            }
            
            
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            removeMapLinkLabel.Visible = false;
            addPictureButton.Visible = true;
            previewPicBox.Image = null;
        }
    }
}
