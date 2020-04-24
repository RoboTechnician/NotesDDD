using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Note
    {
        public const int TextLength = 255;
        public const int TitleLength = 64;

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
    }
}
