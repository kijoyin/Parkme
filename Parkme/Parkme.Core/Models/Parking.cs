using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkme.Core.Models
{
    public class Parking
    {
        public string MeterNo { get; set; }
        public string Category { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string MaxStay { get; set; }
        public string Restrictions { get; set; }
        public string OperationalDay { get; set; }
        public string OperationsTime { get; set; }

        public string RateWeekDay { get;set;}
        public string RateWeekEnd { get; set; }
        public string LocationDescription { get; set; }
        public string VehicleBay { get; set; }
        public string MotorCycleBay { get; set; }
        public string MotorCycleRate { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
    }
}
