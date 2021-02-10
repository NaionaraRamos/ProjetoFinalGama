using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Entities
{
    public class Like
    {
        public Like(int id, 
                    int postId, 
                    int userId)
        {
            Id = id;
            PostId = postId;
            UserId = userId;
        }
        public int Id { get; private set; }
        public int PostId { get; private set; }
        public int UserId { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
