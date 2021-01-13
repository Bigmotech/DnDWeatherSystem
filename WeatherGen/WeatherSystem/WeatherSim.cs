using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGen.WeatherSystem
{
    public static class WeatherSim 
    {



        // Methods
        public static WeatherState RunDay(CellData cell)
        {
            cell.TotalRain = 0.0;
            if (cell.FirstDay)
            {
                cell.Statechange = WeatherState.NoRain;
                AddStateToChain(cell);
                cell.FirstDay = false;
            }
            cell.LocalRain = 0.0;
            if (cell.IncomingRain > 0.3)
            {

                cell.LocalRain += cell.IncomingRain;

            }
            else
            {
                cell.IncomingRainCheck = false;
            }

            if (cell.Statechange.Equals(WeatherState.Rain))
            {

                Clear_Rain_History(cell);

                cell.PrevState = cell.Statechange;
                if (!cell.IncomingRainCheck)
                {
                    cell.Statechange = WetChance(cell);

                }

                if (cell.Statechange.Equals(WeatherState.Rain))
                {
                    AddStateToChain(cell);
                    cell.chainRain.TryGetProbability(WeatherState.Rain, WeatherState.Rain, out double? probout);
                    GetAmountOfRain(cell,probout);
                }
                else
                {
                    AddStateToChain(cell);
                    SetOutgoingRain(cell);
                }
            }
            else
            {
                if (!cell.IncomingRainCheck)
                {
                    cell.Statechange = DryChance(cell);
                }
                cell.PrevState = cell.Statechange;
                if (cell.Statechange.Equals(WeatherState.NoRain))
                {
                    if (cell.IncomingRainCheck && cell.Statechange.Equals(WeatherState.NoRain))
                    {
                        cell.Statechange = WeatherState.Rain;
                        AddStateToChain(cell);
                        SetOutgoingRain(cell);
                    }
                    else
                        AddStateToChain(cell);
                }
                else if (cell.Statechange.Equals(WeatherState.Rain))
                {
                    AddStateToChain(cell);
                    cell.chainRain.TryGetProbability(WeatherState.Rain, WeatherState.Rain, out double? probout);
                    GetAmountOfRain(cell,probout);
                }
            }
            cell.IncomingRainCheck = false;
            GetInverseDryToWet(cell);
            GetInverseWetToWet(cell);
            
            return cell.Statechange;
        }


        static public void InitList(CellData cell)
        {
            cell.n = new List<WeatherState>()
            {

                WeatherState.Rain,
                WeatherState.Rain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.Rain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.NoRain,
                WeatherState.Rain,
                WeatherState.NoRain,
                WeatherState.Rain,
                WeatherState.NoRain,
                WeatherState.Rain,
                WeatherState.NoRain,
                WeatherState.Rain,
                WeatherState.NoRain,
                WeatherState.Rain,
                WeatherState.NoRain,
                WeatherState.Rain,
                WeatherState.NoRain,
                WeatherState.Rain,
                WeatherState.NoRain,
                WeatherState.Rain,
                WeatherState.NoRain,
                WeatherState.Rain,
                WeatherState.NoRain,
            };
            cell.WeatherHistory = new List<WeatherState>();
            cell.WeatherHistory.AddRange(cell.n);

        }

        static public void SurroundingRain(CellData cell)
        {
            cell.Statechange = WeatherState.Rain;
            cell.chainRain.TryGetProbability(WeatherState.Rain, WeatherState.Rain, out double? probout);
            GetAmountOfRain(cell,probout);
        }

        static public void ZeroIncoming(CellData cell)
        {
            cell.IncomingRain = 0.0;
        }

        static public void GetAmountOfRain(CellData cell,double? ProOfRain)
        {
            // Using a mixed expnential distribution to retun the amount of rain
            Random random = new Random(DateTime.Now.GetHashCode());
            double x = Accord.Statistics.Distributions.Univariate.ExponentialDistribution.Random(.05, random);
            double FirstDis = (double)ProOfRain * x;
            cell.LocalRain += Math.Round(FirstDis, 2);
            cell.TotalRain = cell.LocalRain + cell.IncomingRain;
            cell.IncomingRain = 0.0;
            SetOutgoingRain(cell);
        }

        static public void SetOutgoingRain(CellData cell)
        {
            cell.OutgoingRain = 0.0;
            if (cell.LocalRain >= 12)
            {
                cell.OutgoingRain = cell.LocalRain - 12;
                cell.LocalRain = 12;
            }
        }

        static public void SetIncomingRain(CellData cell,double incoming)
        {
            if (incoming > .3)
            {
                cell.IncomingRain += incoming;
                cell.IncomingRainCheck = true;
            }
            else
            {
                cell.IncomingRain += 0.0;
                cell.IncomingRainCheck = false;
            }
        }

        static public void Clear_Rain_History(CellData cell)
        {
            cell.WeatherHistory.Clear();
            cell.WeatherHistory.AddRange(cell.n);
            MakeDefault(cell);

        }

        static public void MakeDefault(CellData cell)
        {
            cell.chainRain.ClearMarkov();

            for (int i = 0; i < cell.n.Count; i++)
            {
                if (i + 1 < cell.n.Count)
                {
                    cell.chainRain.Add(cell.n[i], cell.n[i + 1]);
                }
            }

        }

        static public void GetInverseDryToWet(CellData cell)
        {
            Accord.Statistics.Distributions.Univariate.InverseGaussianDistribution inverse = new Accord.Statistics.Distributions.Univariate.InverseGaussianDistribution(.5, 1);
            cell.chainRain.TryGetProbability(WeatherState.NoRain, WeatherState.Rain, out double? D2W);
            if(D2W == null)
            {
                D2W = .9;
            }
            double crit = 1 - ((double)D2W / 2);
            cell.InverseNormalCDFDryToWet = inverse.DistributionFunction(crit);
        }

        static public void GetInverseWetToWet(CellData cell)
        {
            Accord.Statistics.Distributions.Univariate.InverseGaussianDistribution inverse = new Accord.Statistics.Distributions.Univariate.InverseGaussianDistribution(.5, 1);
            cell.chainRain.TryGetProbability(WeatherState.Rain, WeatherState.Rain, out double? W2W);
            if (W2W == null)
            {
                W2W = .9;
            }
            double crit = 1 - ((double)W2W / 2);
            cell.InverseNormalCDFWetToWet = inverse.DistributionFunction(crit);
        }

        static public WeatherState WetChance(CellData cell)
        {

            cell.chainRain.TryGetProbability(WeatherState.Rain, WeatherState.Rain, out double? prob);
            cell.RanNum = Accord.Statistics.Distributions.Univariate.NormalDistribution.Random(0.5, 0.2);
            while (cell.RanNum < 0 || cell.RanNum > 1)
            {
                cell.RanNum = Accord.Statistics.Distributions.Univariate.NormalDistribution.Random(0.5, .02);
            }
            if (cell.RanNum < prob)
            {
                return WeatherState.Rain;
            }
            else
            {
                return WeatherState.NoRain;
            }

        }

        static public WeatherState DryChance(CellData cell)
        {
            cell.chainRain.TryGetProbability(WeatherState.NoRain, WeatherState.Rain, out double? prob);
            cell.RanNum = Accord.Statistics.Distributions.Univariate.NormalDistribution.Random(0.5, 0.2);
            while (cell.RanNum < 0 || cell.RanNum > 1)
            {
                cell.RanNum = Accord.Statistics.Distributions.Univariate.NormalDistribution.Random(0.5, .02);
            }

            if (cell.RanNum < prob)
            {
                return WeatherState.Rain;
            }
            else
            {
                return WeatherState.NoRain;
            }
        }

        static public void AddStateToChain(CellData cell)
        {
            cell.chainRain.Add(cell.PrevState, cell.Statechange);
        }

    }


}
