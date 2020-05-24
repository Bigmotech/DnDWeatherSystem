using System;
using WeatherGen.WeatherSystem;

namespace WeatherGen.WeatherSystem
{
    class ContainerMap
    {

        private readonly int[] grid = new int[2];
        private readonly Random r = new Random(DateTime.Today.GetHashCode());
        private readonly WeatherCelliconDisplay[][] controlContainers;

        public ContainerMap(int row, int col)
        {
            grid[0] = row;
            grid[1] = col;
            controlContainers = new WeatherCelliconDisplay[grid[0]][];
            LoadArray();
            LoadInMap();
        }


        public ContainerMap(int[] coords)
        {
            grid = coords;
            controlContainers = new WeatherCelliconDisplay[grid[0]][];
            LoadArray();
            LoadInMap();

        }

        private void LoadArray()
        {
            for (int i = 0; i < controlContainers.Length; i++)
                controlContainers[i] = new WeatherCelliconDisplay[grid[1]];
        }

        private void LoadInMap()
        {
            for (int i = 0; i < grid[0]; i++)
            {
                for (int j = 0; j < grid[1]; j++)
                {
                    controlContainers[i][j] = new WeatherCelliconDisplay(new CellData(r, i, j));
                    controlContainers[i][j].OutgoingRainEvent += ContainerMap_OutgoingRainEvent1;
                    //WeatherSim.RunDay(controlContainers[i][j].Cell);
                }
            }
            for (int i = 0; i < grid[0]; i++)
            {
                for (int j = 0; j < grid[1]; j++)
                {
                    WeatherSim.RunDay(controlContainers[i][j].Cell);
                    TempetureGeneration.GenerateTempeture(controlContainers[i][j].Cell);
                }
            }
        }

        private void ContainerMap_OutgoingRainEvent1(object sender, OutgoingRainEventArgs e)
        {

            double outgoing = controlContainers[e.Row][e.Column].Cell.OutgoingRain / 4;

            if (outgoing > .3)
            {
                if (e.Row - 1 >= 0)
                    try
                    {
                        WeatherSim.SetIncomingRain(controlContainers[e.Row - 1][e.Column].Cell, outgoing);
                    }
                    catch (NullReferenceException ex)
                    {
                        controlContainers[e.Row - 1][e.Column].Cell = new CellData(r, e.Row, e.Column);
                        Console.WriteLine(ex.Message);
                    }
                if (e.Row + 1 < grid[0])
                    try
                    {
                        WeatherSim.SetIncomingRain(controlContainers[e.Row + 1][e.Column].Cell, outgoing);
                    }
                    catch (NullReferenceException ex)
                    {
                        controlContainers[e.Row + 1][e.Column].Cell = new CellData(r, e.Row, e.Column);
                        Console.WriteLine(ex.Message);
                    }
                if (e.Column - 1 >= 0)
                    try
                    {
                        WeatherSim.SetIncomingRain(controlContainers[e.Row][e.Column - 1].Cell, outgoing);
                    }
                    catch (NullReferenceException ex)
                    {
                        controlContainers[e.Row][e.Column - 1].Cell = new CellData(r, e.Row, e.Column);
                        Console.WriteLine(ex.Message);
                    }
                if (e.Column + 1 < grid[0])
                    try
                    {
                        WeatherSim.SetIncomingRain(controlContainers[e.Row][e.Column + 1].Cell, outgoing);
                    }
                    catch (NullReferenceException ex)
                    {
                        controlContainers[e.Row][e.Column + 1].Cell = new CellData(r, e.Row, e.Column);
                        Console.WriteLine(ex.Message);
                    }

            }
        }

        public WeatherCelliconDisplay[][] RunFormDay()
        {
            for (int i = 0; i < grid[0]; i++)
            {
                for (int j = 0; j < grid[1]; j++)
                {
                    WeatherSim.RunDay(controlContainers[i][j].Cell);
                }
            }
            CheckNeighborsRain();
            CheckNeighborsLoopForm();
            CheckNeighborsToRain();
            return controlContainers;
        }

        private void CheckNeighborsRain()
        {
            for (int i = 0; i < grid[0]; i++)
            {
                for (int j = 0; j < grid[1]; j++)
                {
                    bool n, s, e, w;
                    if (i - 1 >= 0)
                        n = controlContainers[i - 1][j].Cell.Statechange == WeatherSystem.WeatherState.Rain ? true : false;
                    else
                        n = false;
                    if (i + 1 < grid[0])
                        s = controlContainers[i + 1][j].Cell.Statechange == WeatherSystem.WeatherState.Rain ? true : false;
                    else
                        s = false;

                    if (j - 1 >= 0)
                        e = controlContainers[i][j - 1].Cell.Statechange == WeatherSystem.WeatherState.Rain ? true : false;
                    else
                        e = false;
                    if (j + 1 < grid[0])
                        w = controlContainers[i][j + 1].Cell.Statechange == WeatherSystem.WeatherState.Rain ? true : false;
                    else
                        w = false;

                    if ((n ? 1 : 0)
                            + (s ? 1 : 0)
                            + (e ? 1 : 0)
                            + (w ? 1 : 0) > 1)
                    {
                        controlContainers[i][j].Cell.IsCloudy = true;
                    }
                    else
                    {
                        controlContainers[i][j].Cell.IsCloudy = false;
                    }

                }
            }
        }

        private void CheckNeighborsLoopForm()
        {
            for (int i = 0; i < grid[0]; i++)
            {
                for (int j = 0; j < grid[1]; j++)
                {

                    double outgoing = controlContainers[i][j].Cell.OutgoingRain / 4;

                    if (outgoing > .3)
                    {
                        if (i - 1 >= 0)
                            WeatherSim.SetIncomingRain(controlContainers[i - 1][j].Cell, outgoing);
                        if (i + 1 < grid[0])
                            WeatherSim.SetIncomingRain(controlContainers[i + 1][j].Cell, outgoing);
                        if (j - 1 >= 0)
                            WeatherSim.SetIncomingRain(controlContainers[i][j - 1].Cell, outgoing);
                        if (j + 1 < grid[0])
                            WeatherSim.SetIncomingRain(controlContainers[i][j + 1].Cell, outgoing);
                    }
                }
            }
        }


        private void CheckNeighborsToRain()
        {
            for (int i = 0; i < grid[0]; i++)
            {
                for (int j = 0; j < grid[1]; j++)
                {
                    bool north, south, east, west;
                    north = south = east = west = false;

                    if (i - 1 >= 0)
                        if (controlContainers[i - 1][j].Cell.LocalRain > 0)
                            north = true;
                    if (i + 1 < grid[0])
                        if (controlContainers[i + 1][j].Cell.LocalRain > 0)
                            south = true;
                    if (j - 1 > 0)
                        if (controlContainers[i][j - 1].Cell.LocalRain > 0)
                            west = true;
                    if (j + 1 < grid[1])
                        if (controlContainers[i][j + 1].Cell.LocalRain > 0)
                            east = true;

                    if (north && south && east && west && ((controlContainers[i - 1][j].Cell.LocalRain +
                        controlContainers[i + 1][j].Cell.LocalRain + controlContainers[i][j - 1].Cell.LocalRain
                        + controlContainers[i][j + 1].Cell.LocalRain) > 5))
                        WeatherSim.SurroundingRain(controlContainers[i][j].Cell);

                }
            }
        }



    }
}
