namespace CIS174_Ticketing.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }
        public int PointValue { get; set; }
        public DateTime? DueDate { get; set; }
        public string StatusId { get; set; }
        public Status Status { get; set; }
        public bool Overdue =>
            StatusId == "open" && DueDate < DateTime.Today;

    }
}
