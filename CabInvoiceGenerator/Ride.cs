using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        // variables used
        public double distance;
        public double time;

        public Ride(double distance, double time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
