using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Web.Models
{
    public class AddNoteViewModel
    {
        [MaxLength(Note.TitleLength, ErrorMessage = "Title is too long")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Text is required")]
        [MaxLength(Note.TextLength, ErrorMessage = "Text is too long")]
        [DataType(DataType.Text)]
        public string Text { get; set; }
    }
}
