using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signal_Processing_1
{
    public partial class MainForm : Form
    {
        private string dataFileName;
        private double[] fileData;
        private double[] data;
        private DataType type;

        //private (double Ak, double Bk)[] coef;

        public MainForm()
        {
            InitializeComponent();

            dataFileName = null;
            data = null;
            type = DataType.NotSet;

            fileNameLabel.Text = "Файл не выбран";

            //coef = null;
        }

        /// <summary>
        /// Обработчик кнопки "Выбрать файл..."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dataFileName = openFileDialog.FileName;
                    //writeFile();
                    fileData = getDataFromFile(dataFileName).ToArray();
                    data = new double[fileData.Count()];

                    //coef = null;

                    var button = (Button)sender;

                    switch (button.Name)
                    {
                        case "selectTestFileButton":
                            //writeFile();
                            type = DataType.Test;
                            data = (double[])fileData.Clone();
                            break;

                        case "selectCardioFileButton":
                            type = DataType.Cardio;
                            data = ConvertData.ConvertToCardio(fileData);
                            break;

                        case "selectReoFileButton":
                            type = DataType.Reo;
                            data = ConvertData.ConvertToReo(fileData);
                            break;

                        case "selectVeloFileButton":
                            type = DataType.Velo;
                            data = ConvertData.ConvertToVelo(fileData);
                            break;

                        case "selectSpiroFileButton":
                            type = DataType.Spiro;
                            data = ConvertData.ConvertToSpiro(fileData);
                            break;

                        default:
                            throw new ArgumentException("Необрабатываемое нажатие клавиши");
                    }

                    //обрезаем до степени 2
                    int power = (int)Math.Log(data.Count(), 2.0);
                    data = resizeData(data, (int)Math.Pow(2, power));

                    fileNameLabel.Text = dataFileName;
                    minNumericUpDown.Minimum = 0;
                    maxNumericUpDown.Maximum = data.Count();

                    MessageBox.Show("Данные успешно загружены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    dataFileName = null;
                    data = null;
                    type = DataType.NotSet;
                    fileNameLabel.Text = "Файл не загружен";

                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Построить по данным график и показать его
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showBaseSignalButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (data == null)
                {
                    throw new NullReferenceException("Данные не были загруженны!");
                }

                var form = new ShowChartForm(data, dataFileName.Split('/').Last(), type);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showAmplitudeSpectrumButton_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();

            try
            {
                int N = data.Count();

                double powerD = Math.Log(N, 2.0);

                int power, M, err;

                power = (int)powerD;

                double[] resizedData = resizeData(data, (int)(Math.Pow(2, power)));

                (double Re, double Im)[] exponentData = resizedData.Select(x => (x, 0.0)).ToArray();

                watch.Start();
                double[] coef0 = Walsh.Transform(resizedData);
                double[] amplSpec0 = Walsh.AmplitudeSpectrum(coef0);
                watch.Stop();
                var form0 = new showSpectrumForm(amplSpec0, "Амплитудный спектр Уолш", SpectrumType.Amplitude, amplSpec0.Length, watch.ElapsedMilliseconds);
                form0.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPhaseSpectrumButton_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();

            try
            {
                int N = data.Count();

                double powerD = Math.Log(N, 2.0);

                int power;

                power = (int)powerD;

                double[] resizedData = resizeData(data, (int)(Math.Pow(2, power)));

                (double Re, double Im)[] exponentData = resizedData.Select(x => (x, 0.0)).ToArray();

                watch.Start();
                double[] coef0 = Walsh.Transform(resizedData);
                double[] phaseSpec0 = Walsh.PhaseSpectrum(coef0);
                watch.Stop();
                var form0 = new showSpectrumForm(phaseSpec0, "Фазовый спектр Уолш", SpectrumType.Phase, phaseSpec0.Length, watch.ElapsedMilliseconds);
                form0.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showTestAmplitudeSpectrumButton_Click(object sender, EventArgs e)
        {
            try
            {
                int N = 512;

                double[] amplSpec = new double[N];

                amplSpec[0] = 0.5;
                for (int k = 1; k < N; k++)
                {
                    amplSpec[k] = Math.Abs(1.0 / (Math.PI * k) * Math.Sin(Math.PI * k / 2.0));
                }

                var formStep = new showSpectrumTestForm(amplSpec, "Тестовый амплитудный спектр ступенька", SpectrumType.Amplitude, (int)minNumericUpDown.Value, (int)maxNumericUpDown.Value);
                formStep.Show();

                amplSpec[0] = Math.Sqrt(0 + Math.Pow(0, 2));
                for (int k = 1; k < N; k++)
                {
                    amplSpec[k] = Math.Sqrt(0 + Math.Pow(1.0 / Math.PI / k, 2));
                }

                var formSaw = new showSpectrumTestForm(amplSpec, "Тестовый амплитудный спектр пила", SpectrumType.Amplitude, (int)minNumericUpDown.Value, (int)maxNumericUpDown.Value);
                formSaw.Show();

                amplSpec[0] = Math.Sqrt(Math.Pow(0.5, 2) + 0);
                for (int k = 1; k < N; k++)
                {
                    if ((k % 2) == 0)
                    {
                        amplSpec[k] = Math.Sqrt(0 + 0);
                    }
                    else
                    {
                        amplSpec[k] = Math.Sqrt(Math.Pow(2.0 / (Math.PI * k * Math.PI * k), 2) + 0);
                    }
                }

                var formTri = new showSpectrumTestForm(amplSpec, "Тестовый амплитудный спектр треугольник", SpectrumType.Amplitude, (int)minNumericUpDown.Value, (int)maxNumericUpDown.Value);
                formTri.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showAmplitudeSpectrumTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                (double Ak, double Bk)[] coef = FourierTransform.FourierTransformCoefficient(data);

                double[] amplSpec = FourierTransform.AmplitudeSpectrum(coef);

                var form = new showSpectrumTestForm(amplSpec, "Амплитудный спектр", SpectrumType.Amplitude, (int)minNumericUpDown.Value, (int)maxNumericUpDown.Value);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            try   {
                double[] coef = Walsh.Transform(data);

                var form = new FilterForm(coef, dataFileName, type);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Получить данные из файла
        /// </summary>
        /// <returns></returns>
        private List<double> getDataFromFile(string fileName)
        {
            List<double> data = new List<double>();

            if (fileName == null)
            {
                throw new ArgumentNullException("Имя файла с данными не установлено!");
            }

            using (FileStream fs = File.Open(fileName, FileMode.Open))
            using (TextReader tr = new StreamReader(fs))
            {
                while (tr.Peek() != -1)
                {
                    string line = tr.ReadLine();
                    string[] strValues = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string strValue in strValues)
                    {
                        data.Add(Double.Parse(strValue));
                    }
                }
            }

            return data;
        }

        /// <summary>
        /// Записать какие-то данные в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writeFile()
        {
            int n = 512;
            double k = 1.0 / (n / 2.0);

            int[] data = new int[n];

            var file = File.OpenWrite(dataFileName);

            using (var sw = new StreamWriter(file))
            {
                for (int i = 0; i < n; i++)
                {
                    if (i < (n / 2))
                    {
                        sw.WriteLine(1);
                    }
                    else
                    {
                        sw.WriteLine(0);
                    }
                }
            }
        }

        private void showAmplitudeSpectrumFFTButton_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();

            try
            {
                double powerD = Math.Log(data.Count(), 2);
                int power = (int)Math.Round(powerD);
                int newSize = (int)Math.Pow(2, power);

                double[] resizedData = resizeData(data, newSize);

                (double Re, double Im)[] exponentData = resizedData.Select(x => (x, 0.0)).ToArray();

                watch.Start();
                (double Ak, double Bk)[] coef0 = FourierTransform.FastFourierTransform(exponentData).Select(x => (2 * x.Re, 2 * x.Im)).ToArray();

                double[] amplSpec0 = FourierTransform.AmplitudeSpectrum(coef0);
                watch.Stop();
                var form0 = new showSpectrumForm(amplSpec0, "Амплитудный спектр БПФ", SpectrumType.Amplitude, 360, watch.ElapsedMilliseconds);
                form0.Show();

                watch.Start();
                (double Ak, double Bk)[] coef1 = FourierTransform.FourierTransformCoefficient(resizedData);

                double[] amplSpec1 = FourierTransform.AmplitudeSpectrum(coef1);
                watch.Stop();
                var form1 = new showSpectrumForm(amplSpec1, "Амплитудный спектр ДПФ", SpectrumType.Amplitude, 360, watch.ElapsedMilliseconds);
                form1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double[] resizeData(double[] data, int newSize)
        {
            int oldSize = data.Count();

            double[] resizedData = new double[newSize];
            
            for (int i = 0; i < newSize; i++)
            {
                if(i < oldSize)
                {
                    resizedData[i] = data[i];
                }
                else
                {
                    resizedData[i] = 0;
                }
            }

            return resizedData;
        }

        private void showAmplitudeSpectrumFTSButton_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();

            try
            {
                int N = data.Count();

                double powerD = Math.Log(N, 2.0);

                int power, M, err;

                power = 1;
                M = 1;
                err = (int)(N - Math.Pow(2, power) * M);

                for (int selectedPower = 1, selectedM = 1, selectedErr = 0; Math.Pow(2, selectedPower) < N / 2; selectedPower++)
                {
                    selectedM = (int)Math.Round((double)N / Math.Pow(2, selectedPower));
                    selectedErr = (int)(N - Math.Pow(2, selectedPower) * selectedM);
                    if (Math.Abs(selectedErr) <= Math.Abs(err) && selectedM < Math.Pow(2, selectedPower))
                    {
                        M = selectedM;
                        power = selectedPower;
                        err = selectedErr;
                    }
                }

                double[] resizedData = resizeData(data, (int)(Math.Pow(2, power) * M));

                (double Re, double Im)[] exponentData = resizedData.Select(x => (x, 0.0)).ToArray();

                watch.Start();
                (double Ak, double Bk)[] coef0 = FourierTransform.FourierTransformSpeed(exponentData).Select(x => (2 * x.Re, 2 * x.Im)).ToArray();
                double[] amplSpec0 = FourierTransform.AmplitudeSpectrum(coef0);
                watch.Stop();
                var form0 = new showSpectrumForm(amplSpec0, "Амплитудный спектр ДПФу", SpectrumType.Amplitude, 360, watch.ElapsedMilliseconds);
                form0.Show();

                watch.Start();
                (double Ak, double Bk)[] coef1 = FourierTransform.FourierTransformCoefficient(resizedData);
                double[] amplSpec1 = FourierTransform.AmplitudeSpectrum(coef1);
                watch.Stop();
                var form1 = new showSpectrumForm(amplSpec1, "Амплитудный спектр ДПФ", SpectrumType.Amplitude, 360, watch.ElapsedMilliseconds);
                form1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showAmplitudeSpectrumWalshButton_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();

            try
            {
                int N = data.Count();

                double powerD = Math.Log(N, 2.0);

                int power, M, err;

                power = (int)powerD;

                double[] resizedData = resizeData(data, (int)(Math.Pow(2, power)));

                (double Re, double Im)[] exponentData = resizedData.Select(x => (x, 0.0)).ToArray();

                watch.Start();
                double[] coef0 = Walsh.Transform(resizedData);
                double[] amplSpec0 = Walsh.AmplitudeSpectrum(coef0);
                watch.Stop();
                var form0 = new showSpectrumForm(amplSpec0, "Амплитудный спектр Уолш", SpectrumType.Amplitude, amplSpec0.Length, watch.ElapsedMilliseconds);
                form0.Show();

                watch.Start();
                (double Ak, double Bk)[] coef1 = FourierTransform.FourierTransformCoefficient(resizedData);
                double[] amplSpec1 = FourierTransform.AmplitudeSpectrum(coef1);
                watch.Stop();
                var form1 = new showSpectrumForm(amplSpec1, "Амплитудный спектр ДПФ", SpectrumType.Amplitude, 360, watch.ElapsedMilliseconds);
                form1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPhaseSpectrumWalshButton_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();

            try
            {
                int N = data.Count();

                double powerD = Math.Log(N, 2.0);

                int power, M, err;

                power = (int)powerD;

                double[] resizedData = resizeData(data, (int)(Math.Pow(2, power)));

                (double Re, double Im)[] exponentData = resizedData.Select(x => (x, 0.0)).ToArray();

                watch.Start();
                double[] coef0 = Walsh.Transform(resizedData);
                double[] phaseSpec0 = Walsh.PhaseSpectrum(coef0);
                watch.Stop();
                var form0 = new showSpectrumForm(phaseSpec0, "Фазовый спектр Уолш", SpectrumType.Phase, phaseSpec0.Length, watch.ElapsedMilliseconds);
                form0.Show();

                watch.Start();
                (double Ak, double Bk)[] coef1 = FourierTransform.FourierTransformCoefficient(resizedData);
                double[] phaseSpec1 = FourierTransform.PhaseSpectrum(coef1);
                watch.Stop();
                var form1 = new showSpectrumForm(phaseSpec1, "Фазовый спектр ДПФ", SpectrumType.Phase, 360, watch.ElapsedMilliseconds);
                form1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterWalshButton_Click(object sender, EventArgs e)
        {

        }
    }
}
