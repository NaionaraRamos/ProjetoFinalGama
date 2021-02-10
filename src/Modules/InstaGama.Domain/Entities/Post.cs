using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Entities
{
    public class Post
    {
        public Post(string text, 
                    DateTime datePost, 
                    int userId, 
                    string mediaPost)
        {
            Text = text;
            DatePost = datePost;
            UserId = userId;
            MediaPost = mediaPost;
        }

        public int Id { get; private set; }
        public string Text { get; private set; }
        public DateTime DatePost { get; private set; }
        public int UserId { get; private set; }
        public string MediaPost { get; private set; }

        public bool IsValid()
        {
            bool valid = true;

            if(string.IsNullOrEmpty(Text) && string.IsNullOrEmpty(MediaPost))
            {
                valid = false;
            }

            if(UserId <= 0 || DatePost.ToShortDateString() == "01/01/0001")
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
