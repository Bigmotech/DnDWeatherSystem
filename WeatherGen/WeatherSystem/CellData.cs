using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGen.WeatherSystem
{
    public class CellData : System.ComponentModel.INotifyPropertyChanged
    {


        public MarkovChain<WeatherState, WeatherState> chainRain = new MarkovChain<WeatherState, WeatherState>();
        #region


        //Fields

        public List<WeatherState> WeatherHistory;
        public List<WeatherState> n;

        private bool _incomingRainCheck;
        private bool _firstDay = true;
        private bool _surroundedFlag;
        private bool _iscloudy;
        private double _localRain;
        private double _incomingRain;
        private double _outgoingRain;
        private double _totalRain;
        private double _ranNumb;
        private readonly Random random;
        private int[] _coordinates = new int[2];
        private int _currentTemp;
        private int _day;
        private Direction _direction;
        private WeatherState _prevState;
        private WeatherState _statechange;
        private Temperature _tempDiscription;
        private double _drydaytowetday;
        private double _wetdaytowetday;
        private double _drydaytodryday;
        private double _wetdaytodryday;

        //events
        public event PropertyChangedEventHandler PropertyChanged;


        // properties
        
        //Generation properties
        public double DrydayTowetDay { get => _drydaytowetday; set { _drydaytowetday = value; OnPropertyChanged("DrydayTowetDay"); } }
        public double WetdayTowetDay { get => _wetdaytowetday; set { _wetdaytowetday = value; OnPropertyChanged("WetdayTowetDay"); } }
        public double DrydayTodryDay { get => _drydaytodryday; set { _drydaytodryday = value; OnPropertyChanged("DrydayTodryDay"); } }
        public double WetdayTodryDay { get => _wetdaytodryday; set { _wetdaytodryday = value; OnPropertyChanged("WetdayTodryDay"); } }
        public double InverseNormalCDFDryToWet { get; set; }
        public double InverseNormalCDFWetToWet { get; set; }
        public WeatherState Statechange { get => _statechange; set { _statechange = value; OnPropertyChanged("Statechange"); } }
        public WeatherState PrevState { get => _prevState; set { _prevState = value; OnPropertyChanged("PrevState"); } }
        public double RanNum { get => _ranNumb; set { _ranNumb = value; OnPropertyChanged("RanNum"); } }

        //Rain
        public double LocalRain { get => _localRain; set { _localRain = value; OnPropertyChanged("LocalRain"); } }
        public bool IncomingRainCheck { get => _incomingRainCheck; set { _incomingRainCheck = value; OnPropertyChanged("IncomingRainCheck"); } }
        public double OutgoingRain { get => _outgoingRain; set { _outgoingRain = value; if (_outgoingRain > .3) OnPropertyChanged("OutgoingRain"); } }
        public double IncomingRain { get => _incomingRain; set { _incomingRain = value; OnPropertyChanged("IncomingRain"); } }
        public double TotalRain { get => _totalRain; set { _totalRain = value; OnPropertyChanged("TotalRain"); } }
        
        //Temp
        public int CurrentTemp { get => _currentTemp; internal set { _currentTemp = value; OnPropertyChanged("CurrentTemp"); } }
        public Temperature TempDiscription { get => _tempDiscription; set { _tempDiscription = value; OnPropertyChanged("TempDiscription"); } }

        //Discription
        public int Day { get => _day; internal set { if (_day > 365) { _day = 0; } _day = value; OnPropertyChanged("Day"); } }
        public bool SurroundedFlag { get => _surroundedFlag; set { _surroundedFlag = value; OnPropertyChanged("SurroundedFlag"); } }
        public bool IsCloudy { get => _iscloudy; set { _iscloudy = value; OnPropertyChanged("TempDiscription"); } }
        public bool FirstDay { get => _firstDay; set { _firstDay = value; OnPropertyChanged("FirstDay"); } }
        public int[] Coordinates { get => _coordinates; set { _coordinates = value; OnPropertyChanged("Coordinates"); } }
        public Terrian currentTerrian { get; set; }
        public Direction Direction { get => _direction; internal set { _direction = value; OnPropertyChanged("Direction"); } }




        #endregion

        //Consturctors
        public CellData()
        {

        }
        public CellData(Random r)
        {
            random = r;
            WeatherSim.InitList(this);
            WeatherSim.MakeDefault(this);

        }
        public CellData(Random r, int[] coord) : this(r, coord[0], coord[1])
        {
            random = r;
        }
        public CellData(Random r, int row, int col) : this(r)
        {

            this.Coordinates[0] = row;
            this.Coordinates[1] = col;
            random = r;
        }

        //events
        public void OnPropertyChanged(string proptertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proptertyName));
        }


        //overrides
        public override string ToString()
        {
            return Statechange.ToString() + " " + Coordinates[0] + "|" + Coordinates[1];
        }
        public void SetAdjacentCells()
        {

        }
    }


}







