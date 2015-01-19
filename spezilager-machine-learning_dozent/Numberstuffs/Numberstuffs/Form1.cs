using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numberstuffs
{
    public partial class Form1 : Form
    {
        MaschineLearner ml;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ml.GetTrainDigits().ToString());
            MessageBox.Show(ml.GetTestDigits().ToString());
            MessageBox.Show(ml.NearestNeighbour().ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ml = new MaschineLearner();
            ml.Init();
        }
    }
}
