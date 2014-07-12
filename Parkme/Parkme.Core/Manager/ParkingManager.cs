using Parkme.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkme.Core.Manager
{
    public class ParkingManager : IParkingManager
    {
        public List<Parking> GetParking(string pathToCSV)
        {
            var reader = new StreamReader(File.OpenRead(pathToCSV));
            var parkings = new List<Parking>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                Parking parkingTmpo = new Parking();
                parkingTmpo.MeterNo = values[0];
                parkings.Add(parkingTmpo);
            }
            return parkings;
        }
    }
}
