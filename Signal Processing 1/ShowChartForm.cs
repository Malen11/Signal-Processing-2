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
    public partial class ShowChartForm : Form
    {
        double[] data;
        DataType type;

        public ShowChartForm(double[] data, string name, DataType type)
        {
            InitializeComponent();

            this.Text = name;
            this.data = data;
            this.type = type;

            switch (type)
            {
                case DataType.Test:
                    SetTestChartParams();
                    break;

                case DataType.Cardio:
                    SetCardioChartParams();
                    break;

                case DataType.Reo:
                    SetReoChartParams();
                    break;

                case DataType.Velo:
                    SetVeloChartParams();
                    break;

                case DataType.Spiro:
                    SetSpiroChartParams();
                    break;

                default:
                    throw new ArgumentException("Неожиданный тип данных");
            }
            
            dataChart.ChartAreas[0].AxisX.Interval = 0.5;
            //dataChart.ChartAreas[0].AxisX.IntervalOffset = - dataChart.ChartAreas[0].AxisX.Minimum;

            minNumericUpDown.Minimum = 0;
            minNumericUpDown.Maximum = data.Length;

            maxNumericUpDown.Minimum = 0;
            maxNumericUpDown.Maximum = data.Length;

            minNumericUpDown.Value = 0;
            maxNumericUpDown.Value = data.Length;

            minValueLabel.Text = "Минимальное значение ";
            maxValueLabel.Text = "Максимальное значение ";

            DrawChart();
        }

        private void changeIntervalButton_Click(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void DrawChart()
        {
            int min = (int)minNumericUpDown.Value;
            int max = (int)maxNumericUpDown.Value;

            dataChart.Series[0].Points.Clear();
            dataChart.ChartAreas[0].AxisX.Minimum = min / 360.0;
            dataChart.ChartAreas[0].AxisX.Maximum = max / 360.0;

            for (int i = min; i < max; i++)
            {
                dataChart.Series[0].Points.AddXY(i / 360.0, data[i]);
            }
        }

        private void SetTestChartParams( )
        {
            dataChart.ChartAreas[0].AxisX.Title = "cек";
            dataChart.ChartAreas[0].AxisX.Minimum = 0;
            dataChart.ChartAreas[0].AxisX.Maximum = 2.0;

        }

        private void SetCardioChartParams( )
        {
            dataChart.ChartAreas[0].AxisX.Title = "cек";
            dataChart.ChartAreas[0].AxisX.Minimum = 0;

            dataChart.ChartAreas[0].AxisY.Title = "мВ";
            //dataChart.ChartAreas[0].AxisY.Minimum = Math.Round((data.Min() - 127) / 60.0, MidpointRounding.AwayFromZero) - 0.5;
            //dataChart.ChartAreas[0].AxisY.Maximum = Math.Round((data.Max() - 127) / 60.0, MidpointRounding.AwayFromZero) + 0.5;
        }

        private void SetReoChartParams( )
        {
            dataChart.ChartAreas[0].AxisX.Title = "cек";
            dataChart.ChartAreas[0].AxisX.Minimum = 0;

            dataChart.ChartAreas[0].AxisY.Title = "мОм";
        }

        private void SetVeloChartParams( )
        {
            dataChart.ChartAreas[0].AxisX.Title = "cек";
            dataChart.ChartAreas[0].AxisX.Minimum = 0;

            dataChart.ChartAreas[0].AxisY.Title = "мВ";
        }

        private void SetSpiroChartParams( )
        {
            dataChart.ChartAreas[0].AxisX.Title = "cек";
            dataChart.ChartAreas[0].AxisX.Minimum = 0;

            dataChart.ChartAreas[0].AxisY.Title = "Л";
        }

        private void SetAmplitudeChartParams()
        {
            dataChart.ChartAreas[0].AxisX.Title = "Номера отсчётов";
            dataChart.ChartAreas[0].AxisX.Minimum = 0;
        }

        //private void minValueTrackBar_Scroll(object sender, EventArgs e)
        //{
        //    if (minValueTrackBar.Value >= maxValueTrackBar.Value)
        //    {
        //        minValueTrackBar.Value = maxValueTrackBar.Value - 1;
        //    }

        //    minValueLabel.Text = "Минимальное значение(N): " + minValueTrackBar.Value;
        //}

        //private void maxValueTrackBar_Scroll(object sender, EventArgs e)
        //{
        //    if (maxValueTrackBar.Value <= minValueTrackBar.Value)
        //    {
        //        maxValueTrackBar.Value = minValueTrackBar.Value + 1;
        //    }

        //    maxValueLabel.Text = "Максимальное значение(N): " + maxValueTrackBar.Value;
        //}
    }
}
