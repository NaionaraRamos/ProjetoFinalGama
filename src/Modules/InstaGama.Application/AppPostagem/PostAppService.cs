using InstaGama.Application.AppPostagem.Input;
using InstaGama.Application.AppPostagem.Interfaces;
using InstaGama.Application.AppPostagem.Output;
using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace InstaGama.Application.AppPostagem
{
    class PostAppService : IPostAppService
    {
        private readonly IPostRepository _postRepository;

        public PostAppService(IPostRepository PostRepository)
        {
            _postRepository = PostRepository;
        }

        public async Task<PostViewModel> GetByIdAsync(int id)
        {
            var post = await _postRepository
                                .GetByIdAsync(id)
                                .ConfigureAwait(false);

            if (post is null)
                return default;

            return new PostViewModel()
            {
                Text = post.Text,
                DatePost = post.DatePost,
                UserId = post.UserId,
                MediaPost = post.MediaPost
        };
        }

        public async Task<PostViewModel> InsertAsync(PostInput postInput)
        {
            var post = new Post(postInput.Text,
                                postInput.DatePost,
                                postInput.UserId,
                                postInput.MediaPost);

            if (!post.IsValid())
            {
                throw new ArgumentException("Existem dados que são obrigatórios e não foram preenchidos");
            }

            var id = await _postRepository
                                .InsertAsync(post)
                                .ConfigureAwait(false);

            return new PostViewModel()
            {
                Text = post.Text,
                DatePost = post.DatePost,
                UserId = post.UserId,
                MediaPost = post.MediaPost
            };
        }
    }
}
