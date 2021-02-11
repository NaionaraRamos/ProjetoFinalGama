using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Entities
{
    public class Comment
    {
        public Comment(int id,
                       int postId,
                       int userId,
                       String content,
                       bool visibility)
        {
            Id = id;
            UserId = userId;
            PostId = postId;
            Content = content;
            Visibility = visibility;
        }

        public int Id { get; private set; }
        public int PostId { get; private set; }
        public int UserId { get; private set; }
        public String Content { get; private set; }
        public bool Visibility { get; private set; }
    }
}
