using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        IDictionary<String, ISet<TUser>> followers;

        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
            followers = new Dictionary<String, ISet<TUser>>();
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if (!followers.ContainsKey(group))
            {
                followers.Add(group, new HashSet<TUser>());
            }
            return followers[group].Add(user);
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                List<TUser> result = new List<TUser>();
                foreach (var group in followers.Values)
                {
                    result.AddRange(group);
                }
                return result;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            return followers.ContainsKey(group) ? followers[group] : new HashSet<TUser>();
        }
    }
}
