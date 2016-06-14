using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbiter
{
    class Simulation
    {
        public double[] x
        {
            get;
            private set;
        }
        public double[] y
        {
            get;
            private set;
        }
        public double[] vx
        {
            get;
            private set;
        }
        public double[] vy
        {
            get;
            private set;
        }
        public double[] t
        {
            get;
            private set;
        }
        public int i
        {
            get;
            private set;
        }
        public int N
        {
            get;
            private set;
        }

        public double TimeStep
        {
            get;
            set;
        }
        public double Length
        {
            get;
            set;
        }
        public IPlanet Planet
        {
            get;
            set;
        }

        public Simulation(double timeStep, double length, IPlanet planet)
        {
            TimeStep = timeStep;
            Length = length;
            Planet = planet;

            i = 0;
            N = (int)(length / timeStep) + 1;
            x = new double[N];
            y = new double[N];
            vx = new double[N];
            vy = new double[N];
            t = new double[N];

            x[0] = planet.Radius;
            y[0] = 0;
            vx[0] = 0;
            vy[0] = planet.Velocity;
        }

        public void Step()
        {
            if (i >= N - 1)
            {
                return;
            }

            double r = Math.Sqrt(Math.Pow(x[i], 2) + Math.Pow(y[i], 2));
            t[i + 1] = t[i] + TimeStep;
            vx[i + 1] = vx[i] - (4 * Math.Pow(Math.PI, 2) * x[i]) / (Math.Pow(r, 3)) * TimeStep;
            vy[i + 1] = vy[i] - (4 * Math.Pow(Math.PI, 2) * y[i]) / (Math.Pow(r, 3)) * TimeStep;
            x[i + 1] = x[i] + vx[i + 1] * TimeStep;
            y[i + 1] = y[i] + vy[i + 1] * TimeStep;

            i++;
        }
    }
}
