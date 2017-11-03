namespace blueSwash.Models
{
    public class LikedIdeas
    {
        public int likedIdeasId {get; set;}
        public int usersId {get; set;}
        public Users user {get; set;}
        public int ideasId {get; set;}
        public Ideas idea {get; set;}
    }
}