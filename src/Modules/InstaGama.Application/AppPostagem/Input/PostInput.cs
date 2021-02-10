using System;

namespace InstaGama.Application.AppPostagem.Input
{
    public class PostInput
    {
        public string Text { get; set; }
        public DateTime DatePost { get; set; }
        public int UserId { get; set; }
        public string MediaPost { get; set; }
    }
}
