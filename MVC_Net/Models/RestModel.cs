using System;
namespace MVC_Net.Models
{
    public class RestModel
    {
        public RestModel()
        {
        }

		public string RestResponse { get; set; }
		public HondaApiSegments HondaSegments { get; set; }
    }
}
