using System.Collections.Generic;
using System;

namespace blueSwash.Models
{
    public class Ideas
    {
        public int ideasId {get; set;}
        public string text {get; set;}
        public int usersId {get; set;}
        public Users creator {get; set;}
        // public List<LikedIdeas> liked {get; set;}

        // public Ideas()
        // {
        //     liked = new List<LikedIdeas>();
        // }
    }
}