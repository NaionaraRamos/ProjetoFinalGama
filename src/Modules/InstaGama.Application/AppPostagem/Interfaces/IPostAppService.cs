using InstaGama.Application.AppPostagem.Input;
using InstaGama.Application.AppPostagem.Output;
using System.Threading.Tasks;

namespace InstaGama.Application.AppPostagem.Interfaces
{
    public interface IPostAppService
    {
        Task<PostViewModel> InsertAsync(PostInput PostInput);
        Task<PostViewModel> GetByIdAsync(int id);
    }
}
