using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class CreateTodoRequestDto
    {
        [Required]
        public string Title { get; set; } = "";
        
        [Required]
        public bool IsDone { get; set; } = false;
    }
}