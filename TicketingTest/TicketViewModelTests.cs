using Xunit;
using System.Collections.Generic;
using CIS174_Ticketing.Models; // Update with your actual namespace

public class TicketViewModelTests
{
    [Fact]
    public void Constructor_Initializes_AllCollectionsAndObjects()
    {
        // Arrange
        var viewModel = new TicketViewModel();

        // Assert
        Assert.NotNull(viewModel.Filters);
        Assert.NotNull(viewModel.Statuses);
        Assert.NotNull(viewModel.Sprints);
        Assert.NotNull(viewModel.DueFilters);
        Assert.NotNull(viewModel.Tasks);
        Assert.NotNull(viewModel.CurrentTask);
    }

    [Fact]
    public void CurrentTask_DefaultInstance_HasEmptyFields()
    {
        // Arrange
        var viewModel = new TicketViewModel();

        // Assert
        Assert.Equal(string.Empty, viewModel.CurrentTask.Description);
        Assert.Equal(string.Empty, viewModel.CurrentTask.SprintId);
        Assert.Equal(0, viewModel.CurrentTask.PointValue);
        Assert.Null(viewModel.CurrentTask.DueDate);
        Assert.Equal(string.Empty, viewModel.CurrentTask.StatusId);
    }

    [Fact]
    public void CanAssign_CustomData_ToCollections()
    {
        // Arrange
        var statusList = new List<Status> { new Status { StatusId = "qa", Name = "QA" } };
        var sprintList = new List<Sprint> { new Sprint { SprintId = "S01", Name = "Sprint 1" } };
        var tasks = new List<Ticket>
        {
            new Ticket { TicketId = 1, Description = "Fix login bug", SprintId = "S01", StatusId = "qa", PointValue = 5 }
        };

        var vm = new TicketViewModel
        {
            Statuses = statusList,
            Sprints = sprintList,
            Tasks = tasks
        };

        // Assert
        Assert.Single(vm.Statuses);
        Assert.Single(vm.Sprints);
        Assert.Single(vm.Tasks);
        Assert.Equal("Fix login bug", vm.Tasks[0].Description);
    }
}