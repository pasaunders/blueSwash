using System.Collections.Generic;

namespace blueSwash.Models
{
    public class Users
    {
        public int usersId {get; set;}
        public string name {get; set;}
        public string alias {get; set;}
        public string email {get; set;}
        public string password {get; set;}

        public List<Ideas> ideas {get; set;}
        // public List<int> likes {get; set;}

        public Users()
        {
            ideas = new List<Ideas>();
            // likes = new List<int>();
        }
    }
}