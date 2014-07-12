﻿using Parkme.Core.Models;
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
                var values = line.Split(',');
                Parking parkingTmpo = new Parking();
                parkingTmpo.MeterNo = values[0];
                parkingTmpo.Category = values[1];
                parkingTmpo.Street = values[2];
                parkingTmpo.Suburb = values[3];
                parkingTmpo.MaxStay = values[4];
                parkingTmpo.Restrictions = values[5];
                parkingTmpo.OperationalDay = values[6];
                parkingTmpo.OperationsTime = values[7];
                parkingTmpo.RateWeekDay = values[9];
                parkingTmpo.RateWeekEnd = values[10];
                parkingTmpo.LocationDescription = values[11];
                parkingTmpo.VehicleBay = values[12];
                parkingTmpo.MotorCycleBay = values[13];
                parkingTmpo.MotorCycleRate = values[14];
                decimal lat = new decimal();
                decimal lon = new decimal();
                if (Decimal.TryParse(values[15], out lat))
                {
                    parkingTmpo.Lat = lat;
                }
                if (Decimal.TryParse(values[16], out lon))
                {
                    parkingTmpo.Long = lon;
                }
                parkingTmpo.Long = Convert.ToDecimal(values[16]);
                parkings.Add(parkingTmpo);
            }
            return parkings;
        }
    }
}
