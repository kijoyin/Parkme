using Newtonsoft.Json;
using Parkme.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            int count = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (count == 0)
                {
                    count++;
                    continue;

                }

                var values = line.Split(',');
                Parking parkingTmpo = new Parking();
                decimal rateWeekday = new decimal();
                decimal rateWeekend = new decimal();
                decimal lat = new decimal();
                decimal lon = new decimal();

                parkingTmpo.MeterNo = values[0];
                parkingTmpo.Category = values[1];
                parkingTmpo.Street = values[2];
                parkingTmpo.Suburb = values[3];
                parkingTmpo.MaxStay = values[4];
                parkingTmpo.Restrictions = values[5];
                parkingTmpo.OperationalDay = values[6];
                parkingTmpo.OperationsTime = values[7];
                if (Decimal.TryParse(values[9], out rateWeekday))
                {
                    parkingTmpo.RateWeekDay = rateWeekday;
                }
                if (Decimal.TryParse(values[10], out rateWeekend))
                {
                    parkingTmpo.RateWeekEnd = rateWeekend;
                }
                parkingTmpo.LocationDescription = values[11];
                parkingTmpo.VehicleBay = values[12];
                parkingTmpo.MotorCycleBay = values[13];
                parkingTmpo.MotorCycleRate = values[14];
                parkingTmpo.Location = new Location();
                if (Decimal.TryParse(values[15], out lat))
                {
                    parkingTmpo.Location.Latitude = lat;
                }
                if (Decimal.TryParse(values[16], out lon))
                {
                    parkingTmpo.Location.Longitude = lon;
                }
                parkings.Add(parkingTmpo);
            }
            return parkings;
        }


        public List<ParkingSearchItem> GetNearybyParking(string location, string filePath)
        {
            var list = GetParking(filePath);
            var result = new List<ParkingSearchItem>();
            var loc=
            foreach (Parking item in list)
            {
                var r = new ParkingSearchItem();
                double distance=distance();
                result.Add(r);
            }
            return null;
        }

        public Location ConvertAddress(string location)
        {
            HttpWebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address=" + location) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var results = JsonConvert.DeserializeObject<dynamic>(reader.ReadToEnd());
                var Lat = results.results[0].geometry.location.lat;
                var Long = results.results[0].geometry.location.lng;
            }
            throw new NotImplementedException();
                   
        }

        public List<ParkingSearchItem> GetNearybyParking(Location location)
        {
            throw new NotImplementedException();
        }

        private double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
