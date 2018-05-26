using System;
namespace MVC_Net.Models
{
    public class User
    {
        private Db4freeContext context;

        public int id { get; set; }

        public string username { get; set; }
        public string password { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }

    }
}
