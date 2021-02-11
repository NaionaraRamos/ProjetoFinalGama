using InstaGama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Repositories
{
    class CommentRepository : ICommentRepository
    {
        private readonly IConfiguration _configuration;

        public CommentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT u.Id,
	                                 u.Nome,
	                                 u.Email,
	                                 u.Senha,
                                     u.DataNascimento,
                                     u.Foto,
	                                 g.Id as GeneroId,
	                                 g.Descricao
                                FROM 
	                                Usuario u
                                INNER JOIN 
	                                Genero g ON g.Id = u.GeneroId
                                WHERE 
	                                u.Email= '{login}'";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    var reader = await cmd
                                        .ExecuteReaderAsync()
                                        .ConfigureAwait(false);

                    while (reader.Read())
                    {
                        var user = new User(reader["Email"].ToString(),
                                            reader["Senha"].ToString(),
                                            reader["Nome"].ToString(),
                                            DateTime.Parse(reader["DataNascimento"].ToString()),
                                            new Gender(reader["Descricao"].ToString()),
                                            reader["Foto"].ToString());

                        user.SetId(int.Parse(reader["id"].ToString()));
                        user.Gender.SetId(int.Parse(reader["GeneroId"].ToString()));

                        return user;
                    }

                    return default;
                }
            }
        }

        public async Task<int> InsertAsync(Comment comment)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @"INSERT INTO
                                Comment (PostId,
                                         UserId,
                                         Content,
                                         Visiblity)
                                VALUES (@postId,
                                        @userId,
                                        @content,
                                        @visibility";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;

                    object p = cmd.Parameters.AddWithValue("postId", comment.PostId);
                    cmd.Parameters.AddWithValue("userId", comment.UserId);
                    cmd.Parameters.AddWithValue("content", comment.Content);
                    cmd.Parameters.AddWithValue("visibility", comment.Visibility);

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
