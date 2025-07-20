using System.Net.Sockets;
using CIS174_Ticketing.Models;

namespace TicketingTest
{
    public class TicketTests
    {
        [Fact]
        public void Overdue_ReturnsTrue_WhenOpenAndDueDateIsPast()
        {
            var ticket = new Ticket
            {
                StatusId = "open",
                DueDate = DateTime.Today.AddDays(-1)
            };

            Assert.True(ticket.Overdue);
        }

        [Fact]
        public void Overdue_ReturnsFalse_WhenNotOpen()
        {
            var ticket = new Ticket
            {
                StatusId = "closed",
                DueDate = DateTime.Today.AddDays(-1)
            };

            Assert.False(ticket.Overdue);
        }

        [Fact]
        public void Overdue_ReturnsFalse_WhenDueDateIsTodayOrFuture()
        {
            var ticket = new Ticket
            {
                StatusId = "open",
                DueDate = DateTime.Today
            };

            Assert.False(ticket.Overdue);
        }
    }
}
