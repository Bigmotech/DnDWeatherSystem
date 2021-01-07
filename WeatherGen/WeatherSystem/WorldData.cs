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
        public WorldData(string worldName, int[] gridSize) 
        {
            this.worldName = worldName;
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

            
            try
            {
                File.WriteAllText(@"C:\Users\Test\Desktop\" + worldName+".json", JsonConvert.SerializeObject(this));
            }catch(Exception e)
            {
                MessageBox.Show("failed to save \n" + e.Message);
                return false;
            }
            
            
            return true;
        }


    }
}
