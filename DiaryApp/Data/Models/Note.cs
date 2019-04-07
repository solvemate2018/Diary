using DiaryApp.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiaryApp.Data.Models
{
    public class Note: IWritable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int UserID { get; set; }

        public Note(string title, string text)
        {
            Title = title;
            Text = text;
        }
    }
}
