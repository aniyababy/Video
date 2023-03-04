using System;

namespace Video.Domain.Videos.Views
{
    public class ConcernUserListView
    {
        public ConcernUserListView() { }

        public Guid Id { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string? Avatar { get; set; }

        public ConcernUserListView(Guid id, string? name, string? username, string? avatar)
        {
            Id = id;
            Name = name;
            Username = username;
            Avatar = avatar;
        }
    }
}
