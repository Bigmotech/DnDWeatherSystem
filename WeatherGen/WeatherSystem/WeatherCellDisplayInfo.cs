using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGen.WeatherSystem
{
    static class WeatherCellDisplayInfo
    {
        public static System.Windows.Forms.DialogResult Show(CellData cell)
        {
            WeatherFormData formData = new WeatherFormData(cell);
            return formData.ShowDialog();
        }
    }
}
