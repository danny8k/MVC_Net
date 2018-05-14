using System;
using System.Collections.Generic;
namespace MVC_Net.Models
{
    public class HondaApiSegments
    {
		public class Segment
        {
            public string segmentId { get; set; }
            public string segmentName { get; set; }
        }
        
        public bool success { get; set; }
        public IList<Segment> segments { get; set; }
        
    }
}
