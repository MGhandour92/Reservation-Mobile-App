using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class CustomerCarViewModel
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }

        [Required]
        public string? Make { get; set; }
        [Required]
        public string? Model { get; set; }
        [Required]
        public string? Year { get; set; }
        [Required]
        public string? License { get; set; }
    }
}
