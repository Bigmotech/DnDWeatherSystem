using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGen.WeatherSystem
{
    [DataContract]
    public class CellData : System.ComponentModel.INotifyPropertyChanged
    {


        public MarkovChain<WeatherState, WeatherState> chainRain = new MarkovChain<WeatherState, WeatherState>();
        #region


        //Fields
        [DataMember(Name = "WeatherHistory")]
        public List<WeatherState> WeatherHistory;
        public List<WeatherState> n;
        private bool _firstDay = true;
        private WeatherState _prevState;
        private WeatherState _statechange;
        private bool _incomingRainCheck;
        private double _localRain;
        private double _incomingRain;
        private double _outgoingRain;
        private double _totalRain;
        private Direction _direction;
        public double RanNum;
        private readonly Random random;
        public int[] Coordinates = new int[2];
        private Temperature _tempDiscription;
        private int _maxTemp;
        private int _minTemp;
        private bool _surroundedFlag;
        private bool _iscloudy;
        private int _currentTemp;
        private int _day;

        //events
        public event PropertyChangedEventHandler PropertyChanged;


        // properties
        
        public Terrian currentTerrian { get; set; }
        public bool FirstDay { get => _firstDay; set { _firstDay = value; OnPropertyChanged("FirstDay"); } }
        public bool IsCloudy { get => _iscloudy; set { _iscloudy = value; OnPropertyChanged("TempDiscription"); } }
        public Temperature TempDiscription { get => _tempDiscription; set { _tempDiscription = value; OnPropertyChanged("TempDiscription"); } }
        public WeatherState PrevState { get => _prevState; set { _prevState = value; OnPropertyChanged("PrevState"); } }
        public WeatherState Statechange { get => _statechange; set { _statechange = value; OnPropertyChanged("Statechange"); } }
        public bool IncomingRainCheck { get => _incomingRainCheck; set { _incomingRainCheck = value; OnPropertyChanged("IncomingRainCheck"); } }
        public double InverseNormalCDFDryToWet { get; set; }
        public double InverseNormalCDFWetToWet { get; set; }
        public double LocalRain { get => _localRain; set { _localRain = value; OnPropertyChanged("LocalRain"); } }
        public double IncomingRain { get => _incomingRain; set { _incomingRain = value; OnPropertyChanged("IncomingRain"); } }
        public double OutgoingRain { get => _outgoingRain; set { _outgoingRain = value; if (_outgoingRain > .3) OnPropertyChanged("OutgoingRain"); } }
        public double TotalRain { get => _totalRain; set { _totalRain = value; OnPropertyChanged("TotalRain"); } }
        public int MaxTemp { get => _maxTemp; internal set { _maxTemp = value; OnPropertyChanged("MaxTemp"); } }
        public int MinTemp { get => _minTemp; internal set { _minTemp = value; OnPropertyChanged("MinTemp"); } }
        public int CurrentTemp { get => _currentTemp; internal set { _currentTemp = value; OnPropertyChanged("CurrentTemp"); } }
        public Direction Direction { get => _direction; internal set { _direction = value; OnPropertyChanged("Direction"); } }
        public bool SurroundedFlag { get => _surroundedFlag; set { _surroundedFlag = value; OnPropertyChanged("SurroundedFlag"); } }
        public int Day { get => _day; internal set { _day = value; OnPropertyChanged("Day"); } }


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







