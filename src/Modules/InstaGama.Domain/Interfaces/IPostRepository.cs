using System.Threading.Tasks;
using InstaGama.Domain.Entities;

namespace InstaGama.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<int> InsertAsync(Post post);
        Task<Post> GetByIdAsync(int id);
    }
}
