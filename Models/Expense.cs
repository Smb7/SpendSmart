using System.ComponentModel.DataAnnotations;

namespace Spendsmart.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Value { get; set; }

        [Required]
        // warning not nullable add ? to fix that warning
        public string? Description { get; set; }

        public string? Date { get; set; }

        public string? Monthly { get; set; }
    }
}
