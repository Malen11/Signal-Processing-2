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
    public partial class FilterForm : Form
    {
        private double[] coef;
        private string name;
        DataType type;

        public FilterForm(double[] coef, string name, DataType type)
        {
            InitializeComponent();

            this.coef = coef;
            this.name = name;
            this.type = type;

            notchNumericUpDown0.Minimum = notchNumericUpDown1.Minimum = bPFilterNnumericUpDown0.Minimum = bPFilterNumericUpDown1.Minimum = hPFilterNumericUpDown.Minimum = lPFilterNumericUpDown.Minimum = 0;
            notchNumericUpDown0.Maximum = notchNumericUpDown1.Maximum = bPFilterNnumericUpDown0.Maximum = bPFilterNumericUpDown1.Maximum = hPFilterNumericUpDown.Maximum = lPFilterNumericUpDown.Maximum = coef.Length / 2;
            notchComboBox.SelectedIndex = bPFilterComboBox.SelectedIndex = hPFilterComboBox.SelectedIndex = lPFilterComboBox.SelectedIndex = 0;
        }

        private void lPFilterButton_Click(object sender, EventArgs e)
        {
            int threshold = (int)lPFilterNumericUpDown.Value;
            if(lPFilterComboBox.Text == "Гц")
            {
                threshold = (int)(threshold / (360.0 / coef.Count()));
            }

            double[] coefFiltered = Walsh.LPFilter(coef, threshold);

            double[] filteredData = Walsh.TransformReverse(coefFiltered);

            var form = new ShowChartForm(filteredData, name + " НЧ фильтр", type);
            form.Show();
        }

        private void hPFilterButton_Click(object sender, EventArgs e)
        {
            int threshold = (int)hPFilterNumericUpDown.Value;
            if (hPFilterComboBox.Text == "Гц")
            {
                threshold = (int)(threshold / (360.0 / coef.Count()));
            }

            double[] coefFiltered = Walsh.HPFilter(coef, threshold);

            double[] filteredData = Walsh.TransformReverse(coefFiltered);

            var form = new ShowChartForm(filteredData, name + " ВЧ фильтр", type);
            form.Show();
        }

        private void bPFilterButton_Click(object sender, EventArgs e)
        {
            int threshold0 = (int)bPFilterNnumericUpDown0.Value;
            int threshold1 = (int)bPFilterNumericUpDown1.Value;

            if (bPFilterComboBox.Text == "Гц")
            {
                threshold0 = (int)(threshold0 / (360.0 / coef.Count()));
                threshold1 = (int)(threshold1 / (360.0 / coef.Count()));
            }

            double[] coefFiltered = Walsh.BPFilter(coef, threshold0, threshold1);

            double[] filteredData = Walsh.TransformReverse(coefFiltered);

            var form = new ShowChartForm(filteredData, name + " полосовой фильтр", type);
            form.Show();
        }

        private void notchFilterButton_Click(object sender, EventArgs e)
        {
            int threshold0 = (int)notchNumericUpDown0.Value;
            int threshold1 = (int)notchNumericUpDown1.Value;

            if (notchComboBox.Text == "Гц")
            {
                threshold0 = (int)(threshold0 / (360.0 / coef.Count()));
                threshold1 = (int)(threshold1 / (360.0 / coef.Count()));
            }

            double[] coefFiltered = Walsh.NotchFilter(coef, threshold0, threshold1);

            double[] filteredData = Walsh.TransformReverse(coefFiltered);

            var form = new ShowChartForm(filteredData, name + " режекторный фильтр", type);
            form.Show();
        }
    }
}
