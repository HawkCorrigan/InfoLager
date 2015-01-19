using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace machinelearning
{
    class MachineLearner
    {
        List<Fish> trainfishes;
        List<Fish> testfishes;
        StreamReader srtraindata;
        StreamReader srtraintype;
        StreamReader srtestdata;
        StreamReader srtesttype;

        private const string typefile = "fish_target_train.txt";
        private const string datafile = "fish_data_train.txt";
        private const string testfiletypes = "fish_target_test.txt";
        private const string testfiledata = "fish_data_test.txt";


        public void Init()
        {
            trainfishes = new List<Fish>();
            testfishes = new List<Fish>();
            srtestdata = new StreamReader("fish_data_test.txt");
            srtesttype = new StreamReader("fish_target_test.txt");
            srtraindata = new StreamReader("fish_data_train.txt");
            srtraintype = new StreamReader("fish_target_train.txt");
        }

        public int GetFish()
        {
            Fish bufferfish = new Fish(0,0,0);
            string typeline;
            string dataline;
            string[] datalinesplit;
            int i = 0;
            while (!srtraindata.EndOfStream)
            {
                ++i;
                dataline = srtraindata.ReadLine();
                typeline = srtraintype.ReadLine().Trim();
                datalinesplit = dataline.Split(new string[] { "   " },StringSplitOptions.RemoveEmptyEntries);

                trainfishes.Add(new Fish(Convert.ToDouble(datalinesplit[0], CultureInfo.InvariantCulture), Convert.ToDouble(datalinesplit[1], CultureInfo.InvariantCulture), Convert.ToDouble(typeline, CultureInfo.InvariantCulture)));
            }
            return i;
        }

        public int GetTestFish()
        {
            Fish bufferfish = new Fish(0, 0, 0);
            string typeline;
            string dataline;
            string[] datalinesplit;
            int i = 0;
            while (!srtestdata.EndOfStream)
            {
                ++i;
                dataline = srtestdata.ReadLine();
                typeline = srtesttype.ReadLine().Trim();
                datalinesplit = dataline.Split(new string[] { "   " }, StringSplitOptions.RemoveEmptyEntries);

                testfishes.Add(new Fish(Convert.ToDouble(datalinesplit[0], CultureInfo.InvariantCulture), Convert.ToDouble(datalinesplit[1], CultureInfo.InvariantCulture), Convert.ToDouble(typeline, CultureInfo.InvariantCulture)));
            }
            return i;
        }
        
        public string Neuron()
        {
            double w1 = 0;
            double w2 = 0;
            double w3 = 0;
            double t = 0;
            double sum;
                for (int i=0; i<1000; i++)
                {
                    foreach (Fish train in trainfishes)
                    {
                        sum = w1 + w2 * train.Brightness + w3 * train.Length;
                        if (sum <= 0)
                            t = 0;
                        else
                            t = 1;

                        if (t==0 && train.Type==1)
                        {
                            w1 += 1;
                            w2 += train.Brightness;
                            w3 += train.Length;
                        }
                        if (t==1 && train.Type==0)
                        {
                            w1 -= 1;
                            w2 -= train.Brightness;
                            w3 -= train.Length;
                        }
                    }

                }

                int counter = 0;
                int right = 0;
                foreach (Fish test in testfishes)
                {
                    ++counter;
                    sum = w1 + w2 * test.Brightness + w3 * test.Length;
                    if (sum <= 0)
                        t = 0;
                    else
                        t = 1;
                    if (t == test.Type)
                        ++right;
                }




                return (w1.ToString() + " " + w2.ToString() + " " + w3.ToString()+" "+((double)right/counter).ToString())+" "+right.ToString()+" "+counter.ToString();
        }

        public double NearestNeighbour()
        {
            Fish bestFish = new Fish(0,0,0);
            double bestDistance = Double.MaxValue;
            double currentDist;
            int counter = 0;
            int right = 0;
            foreach (Fish testfish in testfishes)
            {
                ++counter;
                foreach (Fish trainfish in trainfishes)
                {
                    currentDist = Math.Sqrt(Math.Pow(testfish.Brightness - trainfish.Brightness, 2) + Math.Pow(testfish.Length - trainfish.Length, 2));
                    if (currentDist < bestDistance)
                    {
                        bestFish = trainfish;
                        bestDistance = currentDist;
                    }
                }
                bestDistance = Double.MaxValue;
                if (bestFish.Type == testfish.Type)
                    ++right;
                }

                return ((double)right/counter);
            }
    }
}
