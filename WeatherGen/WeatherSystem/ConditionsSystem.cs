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

        internal static string TempCondition(int temp)
        {
            if(temp <= 0)
            {
                return "Extremely Cold, Creatures exposed to the cold must succeed on a DC 10 Con Save\n" + 
                        "at the end of each hour or gain 1 level of exhaustion. Creatures with resistance\n" + 
                        "or immunity to cold damage automatically succeed as do creatues who are adpat to cold climates.\n" + 
                        "Creatures wearing cold weather gear makes the save at the end of the day";
            }
            else if(temp > 0 && temp <= 41)
            {
                return "It is cold";
            }
            else if(temp > 41 && temp <= 50)
            {
                return "It is cool";
            }
            else if(temp > 50 && temp <= 70)
            {
                return "It is fair";
            }
            else if(temp > 70 && temp <= 77)
            {
                return "It is hot";
            }
            else if(temp > 77 && temp <= 99)
            {
                return "it is very hot";
            }
            else if(temp >= 100)
            {
                return "Extremely Hot, Creatures exposed to the heat without access to dinkable water\n" + 
                    "must succeed on a Con Save at the end of each hour or gain 1 level of exhaustion.\n" + 
                    "DC 5 for the first and increases by 1 for each hour after. If a creature drinks water the DC says the same.\n" + 
                    "Creatures with resistance or immunity to fire damage automatically succeed as do creatures who are adapted to hot climates.";
            }
            else
            {
                return "What happened?";
            }
        }

        internal static string WindCondition(object tempRange)
        {
            throw new NotImplementedException();
        }
    }
}
