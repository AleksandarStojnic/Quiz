using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}