using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Interfaces
{
    class ICommentRepository
    {
        Task<int> InsertAsync(Comment comment);
        Task<User> GetByLoginAsync(string login);
        Task<User> GetByIdAsync(int id);
    }
}
