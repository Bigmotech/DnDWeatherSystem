using System;

namespace WeatherGen.WeatherSystem
{
    static class ConditionsSystem
    {
        private static Random r = new Random(DateTime.Now.GetHashCode());
        internal static string RainCondition(double localRain)
        {
            double[] data = RainRate(localRain);
            string condition = "A sunny day";
            
            if(data[0] < .1 && data[0] > 0)
            {
                switch (r.Next(1, 3))
                {
                    case 1:
                        condition = "A light fog, vision is not limited and doesn't cause any disadvantage distant objects are not visible";
                        break;
                    case 2:
                        condition = "Fog, vision is limited. Lightly obscured can be applied to the area";
                        break;
                    case 3:
                        condition = "Heavy Fog, Very limited vision. The area is considered lightly or heavily obscured";
                        break;
                }
            }
            else if(data[0] > .09 && data[0] <= .1)
            {
                condition = "A light mist";
            }
            else if(data[0] > .1 && data[0] < .3)
            {
                condition = "A moderate rain, Light to dark clouds. No disadvantages are imposed but could be applied";
            }
            else if(data[0] >= .3)
            {

                condition = "The area is lightly obscured and creatures have disadvantage on Wisdom (Perception) checks that rely hearing and sight. Open flames such as tourches and campfires are extinguished";
                
            }
            else
            {
                condition = "No rain";
            }

            return condition;

        }
        internal static double[] RainRate(double localRain)
        {
            double RainRate;
            double Hours;
            double[] data = new double[2];
            if (localRain > 12)
            {
                data[0] = 12;
                data[1] = 24;
                return data;
            }
            else if(localRain <= 0)
            {
                data[0] = 0;
                data[1] = 24;
                return data;
            }
            else if(localRain < .1)
            {
                data[0] = .1;
                data[1] = r.Next(1,24);
                return data;
            }
            else if (localRain > 1 && localRain <= 2.3)
            {
                do
                {
                     Hours = r.Next(1, 23);
                    RainRate = localRain / Hours;
                } while (RainRate < 0.05 || RainRate > 0.5);
                
                 data[0] = Math.Round(RainRate, 3);
                data[1] = Hours;
                return data;
            }
            else if(localRain < 1)
            {
                do
                {
                     Hours = r.Next(1, 9);
                    RainRate = localRain / Hours;
                } while (RainRate < 0.05 || RainRate > 0.4);
                data[0] = Math.Round(RainRate, 3);
                data[1] = Hours;
                return data;
            }
            else
            {
               
                data[0] = 0;
                data[1] = 0;
                return data;
            }
            
        }

        internal static string CloudDirection(object direction)
        {
            throw new NotImplementedException();
        }

        internal static string TempCondition(object tempRange)
        {
            throw new NotImplementedException();
        }

        internal static string WindCondition(object tempRange)
        {
            throw new NotImplementedException();
        }
    }
}
