using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Signal_Processing_1;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Adamar()
        {

            int N = 8;
            sbyte[,] Ad = Walsh.AdamarMatrix(N);

            sbyte[,] AdTest = new sbyte[8, 8] {
                { 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, -1, -1, -1, -1 },
                { 1, 1, -1, -1, -1, -1, 1, 1 },
                { 1, 1, -1, -1, 1, 1, -1, -1 },
                { 1, -1, -1, 1, 1, -1, -1, 1 },
                { 1, -1, -1, 1, -1, 1, 1, -1 },
                { 1, -1, 1, -1, -1, 1, -1, 1 },
                { 1, -1, 1, -1, 1, -1, 1, -1 },
            };


            for (int i = 0; i < N; i++)
            {
                for(int j = 0; j< N; j++)
                {
                    if(Ad[i,j] != AdTest[i, j])
                    {
                        Assert.Fail();
                    }                    
                }
            }
        }

        [TestMethod]
        public void Transform()
        {
            double[] s = { 1, 2, 0, 3 };
            double[] XTest = { 1.5, 0, 0.5, -1 };

            double[] X = Walsh.Transform(s);

            
            for (int i = 0; i < s.Length; i++)
            {
                if (Math.Abs(X[i] - XTest[i]) > 0.0001)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void AmplitudeSpectrum()
        {
            double[] s = { 1, 2, 0, 3 };
            double[] ampSpecTest = { 1.5, 0.5, 1};

            double[] X = Walsh.Transform(s);
            double[] ampSpec = Walsh.AmplitudeSpectrum(X);


            for (int i = 0; i < ampSpec.Length; i++)
            {
                if (Math.Abs(ampSpec[i] - ampSpecTest[i]) > 0.0001)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void PhaseSpectrum()
        {
            double[] s = { 1, 2, 0, 3 };
            double[] phaseSpecTest = { 0, 0, Math.PI / 2 };

            double[] X = Walsh.Transform(s);
            double[] phaseSpec = Walsh.PhaseSpectrum(X);


            for (int i = 0; i < phaseSpec.Length; i++)
            {
                if (Math.Abs(phaseSpec[i] - phaseSpecTest[i]) > 0.0001)
                {
                    Assert.Fail();
                }
            }
        }
    }
}
