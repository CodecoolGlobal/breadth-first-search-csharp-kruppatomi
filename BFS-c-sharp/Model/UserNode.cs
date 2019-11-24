using System.Collections.Generic;
using System.Threading;

namespace BFS_c_sharp.Model
{
    public class UserNode
    {
        //it was a property earlyer in the code
        static int nextId;
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private readonly HashSet<UserNode> _friends = new HashSet<UserNode>();

        public HashSet<UserNode> Friends
        {
            get { return _friends; }
        }

        public UserNode() {}

        public UserNode(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = Interlocked.Increment(ref nextId);
        }

        public void AddFriend(UserNode friend)
        {
            Friends.Add(friend);
            friend.Friends.Add(this);
        }

        public override string ToString()
        {
            // Check The Friends Name
            foreach (var friend in Friends) {
            
            System.Console.WriteLine("Friends ID: {0} Friends Firstname: {1} Friends Lastname: {2} ", friend.Id, friend.FirstName, friend.LastName );
            }
            return Id + " " + FirstName + " " + LastName + "(" + Friends.Count + ")";
        }
    }
}
