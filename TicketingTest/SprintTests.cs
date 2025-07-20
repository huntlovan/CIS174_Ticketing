using CIS174_Ticketing.Models;
namespace TicketingTest
{
    public class SprintTests
    {
        [Fact]
        public void Sprint_DefaultConstructor_InitializesPropertiesToEmptyStrings()
        {
            // Arrange
            var sprint = new Sprint();

            // Assert
            Assert.Equal(string.Empty, sprint.SprintId);
            Assert.Equal(string.Empty, sprint.Name);
        }

        [Fact]
        public void Sprint_SetProperties_AssignsValuesCorrectly()
        {
            // Arrange
            var sprint = new Sprint
            {
                SprintId = "S01",
                Name = "Sprint One"
            };

            // Assert
            Assert.Equal("S01", sprint.SprintId);
            Assert.Equal("Sprint One", sprint.Name);
        }

        [Fact]
        public void Sprint_Properties_CanBeModifiedAfterInstantiation()
        {
            // Arrange
            var sprint = new Sprint();

            // Act
            sprint.SprintId = "S02";
            sprint.Name = "Refactor Sprint";

            // Assert
            Assert.Equal("S02", sprint.SprintId);
            Assert.Equal("Refactor Sprint", sprint.Name);
        }
    }
}
