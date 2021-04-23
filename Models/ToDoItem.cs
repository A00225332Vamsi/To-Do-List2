using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList1.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
         ErrorMessage = "Invalid email format")]
        public string UserEmail { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string Title { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Description cannot exceed 150 characters")]
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }

        [Required]
        public DateTime? DueDate { get; set; }
        public bool Done { get; set; }
        public DateTime DoneDate { get; set; }
    }
}
