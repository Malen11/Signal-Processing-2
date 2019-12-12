using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signal_Processing_1
{
    public static class Walsh
    {
        public static  sbyte[,] AdamarMatrix(int N)
        {
            int L = (int)Math.Log(N, 2);
            sbyte[,] Ad = new sbyte[N, N];
            byte[,] keys = new byte[N, L];

            for (int k = 0; k < N; k++)
            {
                int rest = k;
                for (int i = 0; i < L; i++)
                {
                    keys[k, i] = (byte)(rest % 2);
                    rest /= 2;
                }
            }

            for (int u = 0; u < N; u++)
            {
                for (int v = 0; v < N; v++)
                {
                    Ad[u, v] = (sbyte)Math.Pow(-1, keys[u, L - 1] * keys[v, 0]);
                    for (int i = 1; i < L; i++)
                    {
                        Ad[u,v] *= (sbyte)Math.Pow(-1, (keys[u, L - i] + keys[u, L -i -1]) * keys[v, i]);
                    }
                }
            }

            return Ad;
        }

        public static double[] Transform(double[] data)
        {
            int N = data.Length;
            double[] result = new double[N];
            sbyte[,] Ad = AdamarMatrix(N);


            for(int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    result[i] += data[j] * Ad[j, i];
                }

                result[i] /= N;
            }

            return result;
        }

        public static double[] TransformReverse(double[] coefficient)
        {
            int N = coefficient.Length;
            double[] result = new double[N];
            sbyte[,] Ad = AdamarMatrix(N);


            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    result[i] += coefficient[j] * Ad[j, i];
                }
            }

            return result;
        }

        public static double[] AmplitudeSpectrum(double[] Coefficient)
        {
            int N = Coefficient.Length;
            double[] result = new double[N / 2 + 1];

            result[0] = Math.Abs(Coefficient[0]);
            for (int i = 1; i < N / 2; i++)
            {
                result[i] = Math.Sqrt(Coefficient[2 * i - 1] * Coefficient[2 * i - 1] + Coefficient[2 * i] * Coefficient[2 * i]);
            }

            result[N / 2] = Math.Abs(Coefficient[N - 1]);

            return result;
        }

        public static double[] PhaseSpectrum(double[] Coefficient)
        {
            int N = Coefficient.Length;
            double[] result = new double[N / 2 + 1];

            result[0] = 0;
            for (int i = 1; i < N / 2; i++)
            {
                result[i] = Math.Atan(Coefficient[2 * i - 1] / Coefficient[2 * i]);
            }

            result[N / 2] = Math.PI / 2;

            return result;
        }

        public static double[] LPFilter(double[] Coefficient, int end)
        {
            int N = Coefficient.Length;

            double[] result = new double[N];

            int notRemoved = Math.Max(Math.Min(end, N), 0);

            for (int k = 0; k < notRemoved; k++)
            {
                result[k] = Coefficient[k];
            }

            return result;
        }

        public static double[]  HPFilter(double[]  Coefficient, int start)
        {
            int N = Coefficient.Length;

            double[]  result = new double[N];

            int notRemoved = Math.Max(Math.Min(start, N / 2), 0);

            for (int k = notRemoved; k < N; k++)
            {
                result[k] = Coefficient[k];
            }

            return result;
        }

        public static double[]  BPFilter(double[]  Coefficient, int start, int end)
        {
            int N = Coefficient.Length;

            double[]  result = new double[N];

            for (int k = start; k < end; k++)
            {
                result[k] = Coefficient[k];
            }

            return result;
        }

        public static double[]  NotchFilter(double[]  Coefficient, int pos0, int pos1)
        {
            int N = Coefficient.Length;

            double[]  result = new double[N];

            for (int k = 0; k < pos0; k++)
            {
                result[k] = Coefficient[k];
            }

            for (int k = N - pos1; k < N; k++)
            {
                result[k] = Coefficient[k];
            }

            return result;
        }
    }
}
