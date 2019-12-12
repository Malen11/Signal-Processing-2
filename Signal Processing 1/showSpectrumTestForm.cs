using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signal_Processing_1
{
    public partial class showSpectrumTestForm : Form
    {
        double[] data;
        SpectrumType type;
        int min, max;

        public showSpectrumTestForm(double[] data, string name, SpectrumType type, int min, int max)
        {
            InitializeComponent();

            this.Text = name;
            this.data = data;
            this.type = type;
            this.min = min;
            this.max = max;

            dataChart.ChartAreas[0].AxisX.Title = "Номера отсчётов";

            dataChart.ChartAreas[0].AxisX.Interval = 10;

            DrawChart();
        }

        private void DrawChart()
        {
            //int min = (int)minNumericUpDown.Value;
            //int max = (int)maxNumericUpDown.Value;

            //double h =  360.0 / data.Length; 

            //dataChart.Series[0].Points.Clear();
            //dataChart.ChartAreas[0].AxisX.Minimum = min;
            //dataChart.ChartAreas[0].AxisX.Maximum = max;

            //for (int i = (int)(min / h); i < (int)(max / h); i++)
            //{
            //    dataChart.Series[0].Points.AddXY(i * h, data[i]);
            //}

            dataChart.Series[0].Points.Clear();
            dataChart.ChartAreas[0].AxisX.Minimum = min;
            dataChart.ChartAreas[0].AxisX.Maximum = max;
            dataChart.ChartAreas[0].AxisX.IntervalOffset = (dataChart.ChartAreas[0].AxisX.Interval - min) % dataChart.ChartAreas[0].AxisX.Interval;

            dataChart.ChartAreas[0].AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;

            for (int i = min; i < max; i++)
            {
                dataChart.Series[0].Points.AddXY(i, data[i]);
            }
        }
    }
}
