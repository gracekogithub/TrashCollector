using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageCollector.Models
{
    public class GoogleMap
    {
        public class City
        {
            [Key]
            public int Id { get; set; }
            public string Title { get; set; }

            public double Lat { get; set; }

            public double Lng { get; set; }
        }
    }
}
