﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class Ride
    {
        // variables used
        public double distance;
        public int time;

        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}