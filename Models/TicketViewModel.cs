namespace CIS174_Ticketing.Models
{
    public class TicketViewModel
    {
 
        public Filters Filters { get; set; } = new Filters("all-all-all");
        public List<Status> Statuses { get; set; } = new List<Status>();
        public List<Sprint> Categories { get; set; } = new List<Sprint>();
        public Dictionary<string, string> DueFilters { get; set; } = new Dictionary<string, string>();
        public List<Ticket> Tasks { get; set; } = new List<Ticket>();

        public Ticket CurrentTask { get; set; } = new Ticket();  // used for Add

        //[ValidateNever]
        //public Filters Filters { get; set; } = null!;
        //[ValidateNever]
        //public List<Status> Statuses { get; set; } = null!;
        //[ValidateNever]
        //public List<Category> Sprints { get; set; } = null!;
        //[ValidateNever]
        //public Dictionary<string, string> DueFilters { get; set; } = null!;
        //[ValidateNever]
        //public List<ToDo> Tasks { get; set; } = null!;

        //public ToDo CurrentTask { get; set; } = null!;  // used for Add
    }
}
