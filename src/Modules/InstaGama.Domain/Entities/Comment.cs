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
                        string text)
        {
            Id = id;
            PostId = postId;
            UserId = userId;
            Text = text;
        }
        public int Id { get; private set; }
        public int PostId { get; private set; }
        public int UserId { get; private set; }
        public string Text { get; private set; }

        public bool IsValid()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(Text))
            {
                valid = false;
            }

            return valid;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
