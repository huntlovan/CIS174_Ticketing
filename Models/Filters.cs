namespace CIS174_Ticketing.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all";
            string[] filters = FilterString.Split('-');
            CategoryId = filters[0];
            Due = filters[1];
            StatusId = filters[2];
        }
        public string FilterString { get; }
        public string CategoryId { get; }
        public string Due { get; }
        public string StatusId { get; }

        public bool HasCategory => CategoryId.ToLower() != "all";
        public bool HasDue => Due.ToLower() != "all";
        public bool HasStatus => StatusId.ToLower() != "all";

        public static Dictionary<string, string> StatusFilterValues =>
                  new Dictionary<string, string> {
                { "todo", "To Do" },
                { "inprogress", "In Progress" },
                { "qa", "QA" },
                { "done","Done"}
                  };
        public bool IsToDo => Due.ToLower() == "todo";
        public bool IsInProgress => Due.ToLower() == "inprogress";
        public bool IsQA => Due.ToLower() == "qa";
        public bool IsDone => Due.ToLower() == "done";
    }
}
