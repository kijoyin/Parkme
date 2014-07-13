using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkme.Core.Models
{
    public class ParkingSearchItem
    {
        public string distance { get; set; }
        public string Name { get; set; }
        public decimal Fare { get; set; }
        public Parking Parking { get; set; }
        public double distanceindouble { get; set; }
        public bool Isfree { get; set; }
        public string freeCss { get; set; }
    }
}
