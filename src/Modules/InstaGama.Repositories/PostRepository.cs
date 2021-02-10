using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace InstaGama.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public PostRepository(IUserRepository userRepository, 
                              IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT p.Id,
	                                 p.Text,
	                                 p.DatePost,
                                     p.MediaPost,
                                     u.Id as UserId,
                                FROM 
	                                Post p
                                INNER JOIN 
	                                User u ON u.Id = u.UserId
                                WHERE 
	                                u.Id= '{id}'";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    var reader = await cmd
                                        .ExecuteReaderAsync()
                                        .ConfigureAwait(false);

                    while (reader.Read())
                    {
                        var post = new Post(reader["Text"].ToString(),
                                            DateTime.Parse(reader["DataPost"].ToString()),
                                            //consertar
                                            reader["UserId"].ToString(),
                                            reader["MediaPost"].ToString());

                        post.SetId(int.Parse(reader["id"].ToString()));
                        //consertar
                        post.UserId.SetId(int.Parse(reader["UserId"].ToString()));

                        return post;
                    }

                    return default;
                }
            }
        }

        public async Task<int> InsertAsync(Post post)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @"INSERT INTO
                                Usuario (Text,
                                         DatePost,
                                         UserId,
                                         MediaPost)
                                VALUES (@text,
                                        @datePost,
                                        @userId,
                                        @mediaPost); SELECT scope_identity();";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("text", post.Text);
                    cmd.Parameters.AddWithValue("datePost", post.DatePost);
                    cmd.Parameters.AddWithValue("userId", post.UserId);
                    cmd.Parameters.AddWithValue("mediaPost", post.MediaPost);

                    con.Open();
                    var id = await cmd
                                    .ExecuteScalarAsync()
                                    .ConfigureAwait(false);

                    return int.Parse(id.ToString());
                }
            }
        }
    }
}
