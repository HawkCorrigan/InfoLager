using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace machinelearning
{
    class Fish
    {


        public double Brightness{get;private set;}

        public double Length { get; private set; }

        public double Type { get; private set; }

        public Fish(double brightness, double length, double type)
        {
            this.Brightness = brightness;
            this.Length = length;
            this.Type = type;
        }
    }
}
