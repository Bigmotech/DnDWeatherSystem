using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGen.WeatherSystem
{

    public enum Direction
    {
        None,
        North,
        West,
        East,
        South
    }
    public enum Fog
    {
        None,
        Light,
        Normal,
        Heavy
    }
    public enum Raintype
    {
        None,
        Mist,
        Light,
        Normal,
        Heavy,
        Flood
    }
    public enum Wind
    {
        None,
        Light,
        Normal,
        Heavy,
        Gale

    }
    public enum Temperature
    {
        Freezing,
        Cold,
        Cool,
        Warm,
        Hot,
        Scortching
    }
    public enum Terrian
    {
        Mountain = 0,
        Water = 1,
        Land = 2,
        None = 3,
    }
    public enum WeatherState
    {
        None = 0,
        Rain = 1,
        NoRain = 2
    }
    public enum Clouds
    {
        Scattered,
        Overcast,
        Cloudy,
        DarkCloudy,
        Clear
    }

}
