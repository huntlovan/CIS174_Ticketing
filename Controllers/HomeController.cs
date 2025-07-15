using System.Diagnostics;
using CIS174_Ticketing.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_Ticketing.Controllers
{
    public class HomeController : Controller
    {
        private TicketContext context;
        public HomeController(TicketContext ctx) => context = ctx;

        public ViewResult Index(string id)
        {
            // load current filters and data needed for filter drop downs in ToDoViewModel
            var model = new TicketViewModel
            {
                Filters = new Filters(id),
                Categories = context.Sprints.ToList(),
                Statuses = context.Statuses.ToList(),
                DueFilters = Filters.StatusFilterValues
            };

            //get open tasks from database based on current filters

            IQueryable<Ticket> query = context.Tickets;

            if (model.Filters.HasCategory)
            {
                query = query.Where(t => t.StatusId == model.Filters.CategoryId);
            }
            if (model.Filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == model.Filters.StatusId);
            }
            if (model.Filters.HasDue)
            {
                var today = DateTime.Today;
                if (model.Filters.IsToDo)
                    query = query.Where(t => t.DueDate < today);
                else if (model.Filters.IsInProgress)
                    query = query.Where(t => t.DueDate > today);
                else if (model.Filters.IsQA)
                    query = query.Where(t => t.DueDate == today);
            }
            model.Tasks = query.OrderBy(t => t.Status).ToList();

            return View(model);
        }

        [HttpGet]
        public ViewResult Add()
        {
            var model = new TicketViewModel
            {
                Categories = context.Sprints.ToList(),
                Statuses = context.Statuses.ToList(),
                CurrentTask = new Ticket { StatusId = "todo" }  // set default value for drop-down
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(TicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Add(model.CurrentTask);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                model.Categories = context.Sprints.ToList();
                model.Statuses = context.Statuses.ToList();
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public IActionResult MarkComplete([FromRoute] string id, Ticket selected)
        {
            selected = context.Tickets.Find(selected.Id)!;  // use null-forgiving operator to suppress null warning
            if (selected != null)
            {
                selected.StatusId = "closed";
                context.SaveChanges();
            }

            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public IActionResult DeleteComplete(string id)
        {
            var toDelete = context.Tickets
                .Where(t => t.StatusId == "closed").ToList();

            foreach (var task in toDelete)
            {
                context.Tickets.Remove(task);
            }
            context.SaveChanges();

            return RedirectToAction("Index", new { ID = id });
        }
    }
}
