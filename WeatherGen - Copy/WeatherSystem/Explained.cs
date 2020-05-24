using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherGen.WeatherSystem
{
    public partial class Explained : Form
    {
        public Explained()
        {
            InitializeComponent();
        }
        public Explained(string caption)
        {
            InitializeComponent();
            label1.Text = caption;
        }
    }
}
