using System;
using System.Threading.Tasks;
using WeatherGen.WeatherSystem;

namespace WeatherGen.WeatherSystem
{
    class ContainerMap
    {


        private readonly Random r = new Random(DateTime.Today.GetHashCode());
        private readonly WorldData worldMap;

        public ContainerMap(WorldData world)
        { 
            worldMap = world;
            LoadInMap();
        }
        private void LoadInMap()
        {
            for (int i = 0; i < worldMap.col; i++)
            {
                for (int j = 0; j < worldMap.col; j++)
                {
                    worldMap.weatherMap[i][j] = new WeatherCelliconDisplay(new CellData(r, i, j));
                    worldMap.weatherMap[i][j].OutgoingRainEvent += ContainerMap_OutgoingRainEvent1;
                }
            }
            for (int i = 0; i < worldMap.col; i++)
            {
                for (int j = 0; j < worldMap.col; j++)
                {
                    WeatherSim.RunDay(worldMap.weatherMap[i][j].Cell);
                    TempetureGeneration.GenerateTempeture(worldMap.weatherMap[i][j].Cell);
                }
            }
        }

        private void LoadSavedMap()
        {
            for (int i = 0; i < worldMap.col; i++)
            {
                for (int j = 0; j < worldMap.col; j++)
                {
                    worldMap.weatherMap[i][j] = new WeatherCelliconDisplay(new CellData(r, i, j));
                    worldMap.weatherMap[i][j].OutgoingRainEvent += ContainerMap_OutgoingRainEvent1;
                }
            }
            for (int i = 0; i < worldMap.row; i++)
            {
                for (int j = 0; j < worldMap.col; j++)
                {
                    WeatherSim.RunDay(worldMap.weatherMap[i][j].Cell);
                    TempetureGeneration.GenerateTempeture(worldMap.weatherMap[i][j].Cell);
                }
            }
        }

        private void ContainerMap_OutgoingRainEvent1(object sender, OutgoingRainEventArgs e)
        {

            double outgoing = worldMap.weatherMap[e.Row][e.Column].Cell.OutgoingRain / 4;

            if (outgoing > .3)
            {
                if (e.Row - 1 >= 0)
                    try
                    {
                        WeatherSim.SetIncomingRain(worldMap.weatherMap[e.Row - 1][e.Column].Cell, outgoing);
                    }
                    catch (NullReferenceException ex)
                    {
                        worldMap.weatherMap[e.Row - 1][e.Column].Cell = new CellData(r, e.Row, e.Column);
                        Console.WriteLine(ex.Message);
                    }
                if (e.Row + 1 < worldMap.row)
                    try
                    {
                        WeatherSim.SetIncomingRain(worldMap.weatherMap[e.Row + 1][e.Column].Cell, outgoing);
                    }
                    catch (NullReferenceException ex)
                    {
                        worldMap.weatherMap[e.Row + 1][e.Column].Cell = new CellData(r, e.Row, e.Column);
                        Console.WriteLine(ex.Message);
                    }
                if (e.Column - 1 >= 0)
                    try
                    {
                        WeatherSim.SetIncomingRain(worldMap.weatherMap[e.Row][e.Column - 1].Cell, outgoing);
                    }
                    catch (NullReferenceException ex)
                    {
                        worldMap.weatherMap[e.Row][e.Column - 1].Cell = new CellData(r, e.Row, e.Column);
                        Console.WriteLine(ex.Message);
                    }
                if (e.Column + 1 < worldMap.row)
                    try
                    {
                        WeatherSim.SetIncomingRain(worldMap.weatherMap[e.Row][e.Column + 1].Cell, outgoing);
                    }
                    catch (NullReferenceException ex)
                    {
                        worldMap.weatherMap[e.Row][e.Column + 1].Cell = new CellData(r, e.Row, e.Column);
                        Console.WriteLine(ex.Message);
                    }

            }
        }

        public WeatherCelliconDisplay[][] RunFormDay(out WeatherCelliconDisplay[][] IncomingGrid)
        {

            Parallel.ForEach(worldMap.weatherMap, (cell) =>
            {
                Parallel.ForEach(cell, (cellbody) =>
                {
                    WeatherSim.RunDay(cellbody.Cell);
                });
            });
            worldMap.currentDay++;
            IncomingGrid = worldMap.weatherMap;
            CheckNeighborsRain();
            CheckNeighborsLoopForm();
            CheckNeighborsToRain();
            return worldMap.weatherMap;
        }

        private void CheckNeighborsRain()
        {
            for (int i = 0; i < worldMap.row; i++)
            {
                for (int j = 0; j < worldMap.col; j++)
                {
                    bool n, s, e, w;
                    if (i - 1 >= 0)
                        n = worldMap.weatherMap[i - 1][j].Cell.Statechange == WeatherSystem.WeatherState.Rain ? true : false;
                    else
                        n = false;
                    if (i + 1 < worldMap.row)
                        s = worldMap.weatherMap[i + 1][j].Cell.Statechange == WeatherSystem.WeatherState.Rain ? true : false;
                    else
                        s = false;

                    if (j - 1 >= 0)
                        e = worldMap.weatherMap[i][j - 1].Cell.Statechange == WeatherSystem.WeatherState.Rain ? true : false;
                    else
                        e = false;
                    if (j + 1 < worldMap.row)
                        w = worldMap.weatherMap[i][j + 1].Cell.Statechange == WeatherSystem.WeatherState.Rain ? true : false;
                    else
                        w = false;

                    if ((n ? 1 : 0)
                            + (s ? 1 : 0)
                            + (e ? 1 : 0)
                            + (w ? 1 : 0) > 1)
                    {
                        worldMap.weatherMap[i][j].Cell.IsCloudy = true;
                    }
                    else
                    {
                        worldMap.weatherMap[i][j].Cell.IsCloudy = false;
                    }

                }
            }
        }

        private void CheckNeighborsLoopForm()
        {
            for (int i = 0; i < worldMap.row; i++)
            {
                for (int j = 0; j < worldMap.col; j++)
                {

                    double outgoing = worldMap.weatherMap[i][j].Cell.OutgoingRain / 4;

                    if (outgoing > .3)
                    {
                        if (i - 1 >= 0)
                            WeatherSim.SetIncomingRain(worldMap.weatherMap[i - 1][j].Cell, outgoing);
                        if (i + 1 < worldMap.row)
                            WeatherSim.SetIncomingRain(worldMap.weatherMap[i + 1][j].Cell, outgoing);
                        if (j - 1 >= 0)
                            WeatherSim.SetIncomingRain(worldMap.weatherMap[i][j - 1].Cell, outgoing);
                        if (j + 1 < worldMap.row)
                            WeatherSim.SetIncomingRain(worldMap.weatherMap[i][j + 1].Cell, outgoing);
                    }
                }
            }
        }


        private void CheckNeighborsToRain()
        {
            for (int i = 0; i < worldMap.row; i++)
            {
                for (int j = 0; j < worldMap.col; j++)
                {
                    bool north, south, east, west;
                    north = south = east = west = false;

                    if (i - 1 >= 0)
                        if (worldMap.weatherMap[i - 1][j].Cell.LocalRain > 0)
                            north = true;
                    if (i + 1 < worldMap.row)
                        if (worldMap.weatherMap[i + 1][j].Cell.LocalRain > 0)
                            south = true;
                    if (j - 1 > 0)
                        if (worldMap.weatherMap[i][j - 1].Cell.LocalRain > 0)
                            west = true;
                    if (j + 1 < worldMap.col)
                        if (worldMap.weatherMap[i][j + 1].Cell.LocalRain > 0)
                            east = true;

                    if (north && south && east && west && ((worldMap.weatherMap[i - 1][j].Cell.LocalRain +
                        worldMap.weatherMap[i + 1][j].Cell.LocalRain + worldMap.weatherMap[i][j - 1].Cell.LocalRain
                        + worldMap.weatherMap[i][j + 1].Cell.LocalRain) > 5))
                        WeatherSim.SurroundingRain(worldMap.weatherMap[i][j].Cell);

                }
            }
        }

        public bool Savemap()
        {
            return false;
        }


    }
}
