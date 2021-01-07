using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGen.WeatherSystem
{
    public static class TempetureGeneration
    {
        private const int MAX = 90;
        private const int MIN = -20;

        static private Random random = new Random(DateTime.Now.Second.GetHashCode());
        static public int GenerateTempeture(CellData cell)
        {
                double temp = (Math.Sin((cell.Day / 58.1) - 8) / 2) + .5;
                temp = DenormilazedData(temp);
                double adjust = random.NextDouble();
                adjust = DenormilazedDataAdjust(adjust);
                adjust = adjust + temp;
            return (int)adjust;

        }
               
        private static double DenormilazedDataAdjust(double adjust)
        {
            return ((10 - -10) * adjust) + -10;
        }

        private static double DenormilazedData(double Norm)
        {
            return ((MAX - MIN) * Norm) + MIN;

        }


    }
}
