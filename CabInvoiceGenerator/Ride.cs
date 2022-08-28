using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Ride class to set data for particular Ride i.e premium or normal;
    /// </summary>
    public class Ride
    {
        //Variables.
        public double distance;
        public int time;
        /// <summary>
        /// Parameterised Constructor For Setting Data.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
