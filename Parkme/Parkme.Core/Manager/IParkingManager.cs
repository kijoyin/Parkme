using Parkme.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkme.Core.Manager
{
    interface IParkingManager
    {
        List<Parking> GetParking(string pathToCSV);
        List<ParkingSearchItem> GetNearybyParking(string location);
        Location ConvertAddress(string location);
        List<ParkingSearchItem> GetNearybyParking(Location location);
    }
}
