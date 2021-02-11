using System;

namespace InstaGama.Application.AppPostagem.Output
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DatePost { get; set; }
        public int UserId { get; set; }
        public string MediaPost { get; set; }
    }
}
