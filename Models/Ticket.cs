using System.ComponentModel.DataAnnotations;

namespace CIS174_Ticketing.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please select a sprint.")]
        public string SprintId { get; set; } = string.Empty;
        public Sprint Sprint { get; set; }
        [Required(ErrorMessage = "Please select a Point Value.")]
        public int PointValue { get; set; }
        [Required(ErrorMessage = "Please enter a due date.")]
        public DateTime? DueDate { get; set; }
        [Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; }
        public Status Status { get; set; }
        public bool Overdue =>
            StatusId == "open" && DueDate < DateTime.Today;

    }
}
