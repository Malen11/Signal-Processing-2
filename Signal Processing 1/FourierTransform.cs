using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signal_Processing_1
{
    public static class FourierTransform
    {
        public static (double Ak, double Bk)[] FourierTransformCoefficient(double[] data)
        {
            int N = data.Length;
            (double Ak, double Bk)[] result = new(double Ak, double Bk)[N];

            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    result[k].Ak += 1.0 / N * data[i] * Math.Cos(2.0 * Math.PI * k * i / N);
                    result[k].Bk += 1.0 / N * data[i] * Math.Sin(2.0 * Math.PI * k * i / N);
                }
            }

            return result;
        }

        public static (double Re, double Im)[] FastFourierTransform((double Re, double Im)[] data)
        {
            bool invert = true;
            int N = data.Count();

            double powerD = Math.Log(N, 2.0);
            int power = (int)Math.Round(powerD);

            if (Math.Abs(powerD - power) > 0.0000001)
            {
                throw new ArgumentException("Массив data должен быть размером, кратным 2!");
            }

            (double Re, double Im)[] reverseData = reverseArray(data);
            //reverseData = reverseArray(reverseData);

            for (int len = 2; len <= N; len <<= 1)
            {
                double angle = 2 * Math.PI / len * (invert ? -1 : 1);
                (double Re, double Im) wlen = (Math.Cos(angle), Math.Sin(angle));

                for (int i = 0; i < N; i += len)
                {
                    (double Re, double Im) w = (1, 0);

                    for (int j = 0; j < len / 2; ++j)
                    {
                        (double Re, double Im) u = reverseData[i + j];
                        (double Re, double Im) v = complexMult(reverseData[i + j + len / 2], w);

                        reverseData[i + j] = complexSum(u, v);
                        reverseData[i + j + len / 2] = complexSum(u, (-v.Re, -v.Im));
                        w = complexMult(w, wlen);
                    }
                }
            }

            if (invert)
            {
                for (int i = 0; i < reverseData.Length; i++)
                {
                    reverseData[i] = (reverseData[i].Re / N / 2, reverseData[i].Im / N / 2);
                }
            }

            //(double Re, double Im)[] reverseData = reverseArray(data);

            //for (int s = 1; s <= power; s++)
            //{
            //    int m = (int)Math.Pow(2, s);
            //    (double Re, double Im) wm = (Math.Cos(2 * Math.PI / m), Math.Sin(2 * Math.PI / m));

            //    for (int k = 0; k < N; k += m)
            //    {
            //        (double Re, double Im) w = (1, 0);

            //        for (int j = 0; j < m / 2 - 1; j++)
            //        {
            //            (double Re, double Im) u = reverseData[k + j];
            //            (double Re, double Im) t = complexMult(reverseData[k + j + m / 2], w);

            //            reverseData[k + j] = complexSum(u, t);
            //            reverseData[k + j + m / 2] = complexSum(u, (-t.Re, -t.Im));
            //            w = complexMult(w, wm);
            //        }
            //    }
            //}

            return reverseData;
        }

        public static (double Re, double Im)[] FourierTransformSpeed((double Re, double Im)[] data)
        {
            int N = data.Count();

            int power, M, err, L;

            power = 0;
            M = 0;
            err = N - (int)Math.Pow(2, power) * M;

            for (int selectedPower = 0, selectedM = 0, selectedErr = 0; Math.Pow(2, selectedPower) < N/2; selectedPower++)
            {
                selectedM = N / (int)Math.Pow(2, selectedPower);
                selectedErr = N - (int)Math.Pow(2, selectedPower) * selectedM;
                if(Math.Abs(selectedErr) <= Math.Abs(err) && selectedM < Math.Pow(2, selectedPower))
                {
                    power = selectedPower;
                    M = selectedM;
                    err = selectedErr;
                }
            }

            if (Math.Abs(N - (Math.Pow(2, power) * M)) > 0.1)
            {
                throw new ArgumentException("Массив data должен быть размером, кратным 2K*L!");
            }

            L = (int)Math.Pow(2, power);

            (double Re, double Im)[] halfWayData = new(double Re, double Im)[N];
            for(int m = 0; m < M; m++)
            {
                var temp = FastFourierTransform(data.Where((x, y) => y % M == m).ToArray());
                for (int i = 0; i < temp.Length; i++) {

                    halfWayData[i * M + m] = temp[i];
                }
            }

            (double Re, double Im)[] resultData = new(double Re, double Im)[N];
            for (int s = 0; s < M; s++)
            {
                for (int r = 0; r < L; r++)
                {
                    resultData[r + s * L] = (0, 0);
                    for (int m = 0; m < M; m++)
                    {
                        resultData[r + s * L] = complexSum(resultData[r + s * L], complexMult(halfWayData[m + r * M], (Math.Cos(2 * Math.PI * m * (r + s * L) / N), -Math.Sin(2 * Math.PI * m * (r + s * L) / N))));
                    }
                }
            }

            return resultData.Select(item => (item.Re / M, item.Im / M)).ToArray();
        }

        public static double[] AmplitudeSpectrum((double Ak, double Bk)[] Coefficient)
        {
            double[] result = new double[Coefficient.Length];

            for (int i = 0; i < Coefficient.Length; i++)
            {
                result[i] = Math.Sqrt(Coefficient[i].Ak * Coefficient[i].Ak + Coefficient[i].Bk * Coefficient[i].Bk);
            }

            return result;
        }

        public static double[] PhaseSpectrum((double Ak, double Bk)[] Coefficient)
        {
            double[] result = new double[Coefficient.Length];

            for (int i = 0; i < Coefficient.Length; i++)
            {
                result[i] = Math.Atan(Coefficient[i].Bk / Coefficient[i].Ak);
            }

            return result;
        }

        public static double[] FourierTransformReverse((double Ak, double Bk)[] Coefficient)
        {
            int N = Coefficient.Length;

            double[] result = new double[Coefficient.Length];

            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    result[k] += Coefficient[i].Ak * Math.Cos(2.0 * Math.PI * k * i / N) + Coefficient[i].Bk * Math.Sin(2.0 * Math.PI * k * i / N);
                }
            }

            return result;
        }

        public static (double Ak, double Bk)[] LPFilter((double Ak, double Bk)[] Coefficient, int end)
        {
            int N = Coefficient.Length;

            (double Ak, double Bk)[] result = new(double Ak, double Bk)[N];

            int notRemoved = Math.Max(Math.Min(end, N / 2), 0);

            for (int k = 0; k < notRemoved; k++)
            {
                result[k].Ak = Coefficient[k].Ak;
                result[k].Bk = Coefficient[k].Bk;
            }

            for (int k = N - notRemoved; k < N; k++)
            {
                result[k].Ak = Coefficient[k].Ak;
                result[k].Bk = Coefficient[k].Bk;
            }

            return result;
        }

        public static (double Ak, double Bk)[] HPFilter((double Ak, double Bk)[] Coefficient, int start)
        {
            int N = Coefficient.Length;

            (double Ak, double Bk)[] result = new(double Ak, double Bk)[N];

            int notRemoved = Math.Max(Math.Min(start, N / 2), 0);

            for (int k = notRemoved; k < N - notRemoved; k++)
            {
                result[k].Ak = Coefficient[k].Ak;
                result[k].Bk = Coefficient[k].Bk;
            }

            return result;
        }

        public static (double Ak, double Bk)[] BPFilter((double Ak, double Bk)[] Coefficient, int start, int end)
        {
            int N = Coefficient.Length;

            (double Ak, double Bk)[] result = new(double Ak, double Bk)[N];

            for (int k = start; k < end; k++)
            {
                result[k].Ak = Coefficient[k].Ak;
                result[k].Bk = Coefficient[k].Bk;
            }

            for (int k = N - end; k < N - start; k++)
            {
                result[k].Ak = Coefficient[k].Ak;
                result[k].Bk = Coefficient[k].Bk;
            }

            return result;
        }

        public static (double Ak, double Bk)[] NotchFilter((double Ak, double Bk)[] Coefficient, int pos0, int pos1)
        {
            int N = Coefficient.Length;

            (double Ak, double Bk)[] result = new(double Ak, double Bk)[N];

            for (int k = 0; k < pos0; k++)
            {
                result[k].Ak = Coefficient[k].Ak;
                result[k].Bk = Coefficient[k].Bk;
            }

            for (int k = pos1; k < N - pos1; k++)
            {
                result[k].Ak = Coefficient[k].Ak;
                result[k].Bk = Coefficient[k].Bk;
            }

            for (int k = N - pos0; k < N; k++)
            {
                result[k].Ak = Coefficient[k].Ak;
                result[k].Bk = Coefficient[k].Bk;
            }

            return result;
        }

        public static int reverseBite(int data, int power)
        {
            int rest = data;
            int reverseData = 0;

            //перевдим биты в зеркальную позицию
            for (int i = power - 1; i >= 0; i--)
            {
                reverseData += (rest % 2) * (int)Math.Pow(2, i);
                rest /= 2;
            }

            return reverseData;
        }

        public static (double Re, double Im)[] reverseArray((double Re, double Im)[] data)
        {
            int size = data.Count();
            (double Re, double Im)[] reverseData = new (double Re, double Im)[size];

            double powerD = Math.Log(size, 2.0);
            int power = (int)Math.Round(powerD);

            if (Math.Abs(powerD - power) > 0.0000001)
            {
                throw new ArgumentException("Массив data должен быть размером, кратным 2!");
            }

            for (int i = 0; i < size; i++)
            {
                reverseData[reverseBite(i, power)] = data[i];
            }

            return reverseData;
        }

        public static (double Re, double Im) complexSum((double Re, double Im) arg0, (double Re, double Im) arg1)
        {
            return (arg0.Re + arg1.Re, arg0.Im + arg1.Im);
        }

        public static (double Re, double Im) complexMult((double Re, double Im) arg0, (double Re, double Im) arg1)
        {
            return (arg0.Re * arg1.Re - arg0.Im * arg1.Im, arg0.Re * arg1.Im + arg0.Im * arg1.Re);
        }
    }
}
