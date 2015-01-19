using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace machinelearning
{
    public partial class Form1 : Form
    {
        MachineLearner ml;

        public Form1()
        {
            InitializeComponent();
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            int test = ml.GetFish();
            int test2 = ml.GetTestFish();
            MessageBox.Show(test.ToString());
            MessageBox.Show(test2.ToString());
            double accouracy = ml.NearestNeighbour();
            MessageBox.Show(accouracy.ToString());
            MessageBox.Show(ml.Neuron());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ml = new MachineLearner();
            ml.Init();
        }
    }
}
