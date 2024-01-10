namespace lab1_1.Tests
{
    using System;
    using Xunit;

    public class ProgramTests
    {
        [Fact]
        public void CountElementsLessThanC_ShouldReturnCorrectCount()
        {
            // Arrange
            double[] array = { 1.5, 2.3, 3.8, 4.2, 5.1 };
            double C = 4.0;

            // Act
            int result = Program.CountElementsLessThanC(array, C);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void FindLastNegativeIndex_ShouldReturnCorrectIndex()
        {
            // Arrange
            double[] array = { 1.5, -2.3, 3.8, -4.2, 5.1 };

            // Act
            int result = Program.FindLastNegativeIndex(array);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void SumIntPartsAfterLastNegative_ShouldReturnCorrectSum()
        {
            // Arrange
            double[] array = { 1.5, -2.3, 3.8, -4.2, 5.1 };

            // Act
            int result = Program.SumIntPartsAfterLastNegative(array, Program.FindLastNegativeIndex(array));

            // Assert
            Assert.Equal(9, result);
        }

        [Fact]
        public void SortArray_ShouldReturnSortedArray()
        {
            // Arrange
            double[] array = { 1.5, -2.3, 3.8, -4.2, 5.1 };

            // Act
            double[] result = Program.SortArray(array);

            // Assert
            Assert.Equal(new double[] { -2.3, -4.2, 1.5, 3.8, 5.1 }, result);
        }
    }
}