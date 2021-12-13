using System;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username can't be null");
            }
            else
            {
                FullName = fullName;
                Username = username;
                Age = age;
            }
        }

        public uint? Age { get; }

        public string FullName { get; }

        public string Username { get; }

        public bool IsAgeDefined => Age.HasValue;

        // TODO implement missing methods (try to autonomously figure out which are the necessary methods)
    }
}
