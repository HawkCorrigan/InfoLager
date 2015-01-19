using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numberstuffs
{
    class MaschineLearner
    {
        Dictionary<double[],double> traindigits;
        Dictionary<double[],double> testdigits;
        StreamReader srtraindata;
        StreamReader srtraintype;
        StreamReader srtestdata;
        StreamReader srtesttype;

        private const string traintypefile = "digits_target_train.txt";
        private const string traindatafile = "digits_data_train.txt";
        private const string testdatafile = "digits_data_test.txt";
        private const string testtypefile = "digits_target_test.txt";


        public void Init()
        {
            traindigits = new Dictionary<double[],double>();
            testdigits = new Dictionary<double[],double>();
            srtestdata = new StreamReader(testdatafile);
            srtesttype = new StreamReader(testtypefile);
            srtraindata = new StreamReader(traindatafile);
            srtraintype = new StreamReader(traintypefile);
        }

        public int GetTrainDigits()
        {
            int[] data;
            int type;
            string dataline;
            string typeline;
            string[] datalinesplit;
            double[] datalinedata;
            int i = 0;
            while (!srtraindata.EndOfStream)
            {
                ++i;
                dataline = srtraindata.ReadLine();
                typeline = srtraintype.ReadLine().Trim();
                datalinesplit = dataline.Split(new string[] { "   " }, StringSplitOptions.RemoveEmptyEntries);

                datalinedata = Array.ConvertAll(datalinesplit, s => double.Parse(s)/100000);
                traindigits.Add(datalinedata, Convert.ToDouble(typeline));
            }
            return i;
        }

        public int GetTestDigits()
        {
            int[] data;
            int type;
            string dataline;
            string typeline;
            string[] datalinesplit;
            double[] datalinedata;
            int i = 0;
            while (!srtestdata.EndOfStream)
            {
                ++i;
                dataline = srtestdata.ReadLine();
                typeline = srtesttype.ReadLine().Trim();
                datalinesplit = dataline.Split(new string[] { "   " }, StringSplitOptions.RemoveEmptyEntries);
                datalinedata = Array.ConvertAll(datalinesplit, s => double.Parse(s)/100000);
                
                testdigits.Add(datalinedata, Convert.ToDouble(typeline));
            }
            return i;
        }

        public double NearestNeighbour()
        {
            double besttarget = 999;
            double bestDistance = Double.MaxValue;
            double currentDist=0;
            int counter = 0;
            int right = 0;
            foreach (KeyValuePair<double[],double> testentry in testdigits)
            {
                ++counter;
                bestDistance = Double.MaxValue;
                besttarget = 999;
                foreach (KeyValuePair<double[],double> trainentry in traindigits)
                {
                    currentDist = 0;
                    for (int i = 0; i < trainentry.Key.Length; i++)
                    {
                        currentDist += Math.Pow(testentry.Key[i]-trainentry.Key[i], 2);
                    }
                    if (currentDist < bestDistance)
                    {
                        besttarget = trainentry.Value;
                        bestDistance = currentDist;
                    }
                }
                
                if (besttarget == testentry.Value)
                    ++right;
            }

            return ((double)right / counter);
        }

    }
}
