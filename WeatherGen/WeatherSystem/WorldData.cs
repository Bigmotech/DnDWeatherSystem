using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherGen.WeatherSystem
{
    class WorldData
    {
        public string worldName { get; set; }
        public string mapPath { get; set; }
        public int currentDay { get; set; }
        public int row { get; set; }
        public int col { get; set; }
        public WeatherCelliconDisplay[][] weatherMap;

        private WorldData()
        {
            
        }
        public WorldData(string worldName, string mapPath, int row, int col) 
        {
            this.worldName = worldName;
            this.mapPath = mapPath;
            this.row = row;
            this.col = col;
            weatherMap = new WeatherCelliconDisplay[row][];
            LoadArray();

        }
        public WorldData(string worldName, string mapPath, int[] gridSize) 
        {
            this.worldName = worldName;
            this.mapPath = mapPath;
            row = gridSize[0];
            col = gridSize[1];
            weatherMap = new WeatherCelliconDisplay[gridSize[0]][];
            LoadArray();
        }
        public WorldData(WorldData world)
        {
            worldName = world.worldName;
            currentDay = world.currentDay;
            row = world.row;
            col = world.col;
            weatherMap = world.weatherMap;

        }
        private void LoadArray()
        {
            for (int i = 0; i < weatherMap.Length; i++)
                weatherMap[i] = new WeatherCelliconDisplay[col];
        }


        public bool SaveWorld()
        {

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "World Json (*.json) | *.json;";
            dialog.Title = "Please select a World Json.";


            try
            {

                switch (dialog.ShowDialog())
                {
                    case DialogResult.Cancel:

                    case DialogResult.No:

                    case DialogResult.Abort:

                        MessageBox.Show("Nothing was Saved");

                        break;
                    case DialogResult.OK:
                    case DialogResult.Yes:
                            File.WriteAllText(dialog.FileName, JsonConvert.SerializeObject(this));
                        
                        break;
                }
            }catch(Exception e)
            {
                MessageBox.Show("failed to save \n" + e.Message);
                return false;
            }
            
            
            return true;
        }


    }
}
