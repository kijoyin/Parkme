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
    }
}
