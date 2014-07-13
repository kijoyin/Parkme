using Parkme.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parkme.Models
{
    public class PSearchViewModel
    {
        public PSearchViewModel()
        {
            this.IsDefault = false;
            this.Parkings = new List<ParkingSearchItem>();
        }
        public bool IsDefault { get; set; }
        public List<ParkingSearchItem> Parkings { get; set; }
        public string SearchTerm { get; set; }
    }
}