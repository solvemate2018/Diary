using DiaryApp.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiaryApp.Data.Models
{
    public class User: IUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        public List<Note> Notes { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Notes = new List<Note>();
        }
    }
}
