using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signal_Processing_1
{
    /// <summary>
    /// Типы входных данных
    /// </summary>
    public enum DataType {
        
        NotSet      = 0,
        Test        = 1,
        Cardio      = 2,
        Reo         = 3,
        Velo        = 4,
        Spiro       = 5
    };

    public static class ConvertData
    {
        public static double[] ConvertToCardio(double[] data)
        {
            int size = data.Count();
            double[] result = new double[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = (data[i] - 127) / 60;
            }

            return result;
        }

        public static double[] ConvertToReo(double[] data)
        {
            int size = data.Count();
            double[] result = new double[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = (0.1 * data[i] / 100.0);
            }

            return result;
        }

        public static double[] ConvertToVelo(double[] data)
        {
            int size = data.Count();
            double[] result = new double[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = (data[i] - 512.0) / 240.0;
            }

            return result;
        }

        public static double[] ConvertToSpiro(double[] data)
        {
            int size = data.Count();
            double[] result = new double[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = (data[i] - 512.0) / 100.0;
            }

            return result;
        }
    }
}
