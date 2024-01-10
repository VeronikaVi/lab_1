using Xunit;
using lab1_2;

namespace lab1_2Tests
{
    public class ProgramTests
    {
        [Fact]
        public void CountRowsWithZero_ShouldReturnCorrectCount()
        {
            // Arrange
            int[,] matrix = { { 1, 2, 3 }, { 0, 5, 6 }, { 7, 8, 9 } };

            // Act
            int result = Program.CountRowsWithZero(matrix);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void FindLongestSeriesColumn_ShouldReturnCorrectColumn()
        {
            // Arrange
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 8 }, { 9, 10, 11 } };

            // Act
            int result = Program.FindLongestSeriesColumn(matrix);

            // Assert
            Assert.Equal(2, result);
        }
    }
}