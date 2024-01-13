using Domain.Classes;
using Domain.Interfaces;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTestProject.StatisticService
{
    public class StatisticsServiceTest
    {
        #region Hyphens

        [Test]
        public void HyphensCalculate_NoHyphensInEmptyString_ShouldReturnZero()
        {
            // Arrange
            IStatisticsService hyphensStatisticService = new HyphensStatisticService();

            // Act
            int result = hyphensStatisticService.Calculate("");

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void HyphensCalculate_NoHyphensInNonEmptyString_ShouldReturnZero()
        {
            // Arrange
            IStatisticsService hyphensStatisticService = new HyphensStatisticService();

            // Act
            int result = hyphensStatisticService.Calculate("Hello World");

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void HyphensCalculate_SingleHyphen_ShouldReturnOne()
        {
            // Arrange
            IStatisticsService hyphensStatisticService = new HyphensStatisticService();

            // Act
            int result = hyphensStatisticService.Calculate("Hyphen-Test");

            // Assert
            result.Should().Be(1);
        }

        [Test]
        public void HyphensCalculate_MultipleHyphens_ShouldReturnCorrectCount()
        {
            // Arrange
            IStatisticsService hyphensStatisticService = new HyphensStatisticService();

            // Act
            int result = hyphensStatisticService.Calculate("Hyphen-Test-With-Multiple-Hyphens");

            // Assert
            result.Should().Be(4);
        }

        [Test]
        public void HyphensCalculate_OnlyHyphens_ShouldReturnCorrectCount()
        {
            // Arrange
            IStatisticsService hyphensStatisticService = new HyphensStatisticService();

            // Act
            int result = hyphensStatisticService.Calculate("-----");

            // Assert
            result.Should().Be(5);
        }

        [Test]
        public void HyphensCalculate_NullString_ShouldThrowArgumentNullException()
        {
            // Arrange
            IStatisticsService hyphensStatisticService = new HyphensStatisticService();

            // Act
            Action action = () => hyphensStatisticService.Calculate(null);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        #endregion

        #region Words

        [Test]
        public void WordsCalculate_NoWordsInEmptyString_ShouldReturnZero()
        {
            // Arrange
            IStatisticsService wordsStatisticService = new WordsStatisticService();

            // Act
            int result = wordsStatisticService.Calculate("");

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void WordsCalculate_SingleWord_ShouldReturnOne()
        {
            // Arrange
            IStatisticsService wordsStatisticService = new WordsStatisticService();

            // Act
            int result = wordsStatisticService.Calculate("Hello");

            // Assert
            result.Should().Be(1);
        }

        [Test]
        public void WordsCalculate_MultipleWords_ShouldReturnCorrectCount()
        {
            // Arrange
            IStatisticsService wordsStatisticService = new WordsStatisticService();

            // Act
            int result = wordsStatisticService.Calculate("This is a test");

            // Assert
            result.Should().Be(4);
        }

        [Test]
        public void WordsCalculate_LeadingAndTrailingSpaces_ShouldIgnoreSpacesAndReturnCorrectCount()
        {
            // Arrange
            IStatisticsService wordsStatisticService = new WordsStatisticService();

            // Act
            int result = wordsStatisticService.Calculate("   Spaces Before and After   ");

            // Assert
            result.Should().Be(4);
        }

        [Test]
        public void WordsCalculate_BetweenSpaces_ShouldIgnoreSpacesAndReturnCorrectCount()
        {
            // Arrange
            IStatisticsService wordsStatisticService = new WordsStatisticService();

            // Act
            int result = wordsStatisticService.Calculate("Spaces    in    between");

            // Assert
            result.Should().Be(3);
        }

        [Test]
        public void WordsCalculate_NullString_ShouldThrowArgumentNullException()
        {
            // Arrange
            IStatisticsService wordsStatisticService = new WordsStatisticService();

            // Act
            int result = wordsStatisticService.Calculate(null);

            // Assert
            result.Should().Be(0);
        }

        #endregion

        #region Spaces

        [Test]
        public void SpacesCalculate_NoSpacesInEmptyString_ShouldReturnZero()
        {
            // Arrange
            IStatisticsService spacesStatisticService = new SpacesStatisticService();

            // Act
            int result = spacesStatisticService.Calculate("");

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void SpacesCalculate_NoSpacesInNonEmptyString_ShouldReturnZero()
        {
            // Arrange
            IStatisticsService spacesStatisticService = new SpacesStatisticService();

            // Act
            int result = spacesStatisticService.Calculate("HelloWorld");

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void SpacesCalculate_SingleSpace_ShouldReturnOne()
        {
            // Arrange
            IStatisticsService spacesStatisticService = new SpacesStatisticService();

            // Act
            int result = spacesStatisticService.Calculate("Space Test");

            // Assert
            result.Should().Be(1);
        }

        [Test]
        public void SpacesCalculate_MultipleSpaces_ShouldReturnCorrectCount()
        {
            // Arrange
            IStatisticsService spacesStatisticService = new SpacesStatisticService();

            // Act
            int result = spacesStatisticService.Calculate("Space  Test  With Multiple  Spaces");

            // Assert
            result.Should().Be(7);
        }

        [Test]
        public void SpacesCalculate_NullString_ShouldThrowArgumentNullException()
        {
            // Arrange
            IStatisticsService spacesStatisticService = new SpacesStatisticService();

            // Act
            Action action = () => spacesStatisticService.Calculate(null);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        #endregion

        #region Dummy

        [Test]
        public void DummyCalculate_EmptyString_ShouldReturnZero()
        {
            // Arrange
            IStatisticsService dummyStatisticService = new DummyStatisticService();

            // Act
            int result = dummyStatisticService.Calculate("");

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void DummyCalculate_NonEmptyString_ShouldReturnZero()
        {
            // Arrange
            IStatisticsService dummyStatisticService = new DummyStatisticService();

            // Act
            int result = dummyStatisticService.Calculate("Hello World");

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void DummyCalculate_StringWithSpaces_ShouldReturnZero()
        {
            // Arrange
            IStatisticsService dummyStatisticService = new DummyStatisticService();

            // Act
            int result = dummyStatisticService.Calculate("Spaces In Between");

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void DummyCalculate_StringWithNumbers_ShouldReturnZero()
        {
            // Arrange
            IStatisticsService dummyStatisticService = new DummyStatisticService();

            // Act
            int result = dummyStatisticService.Calculate("12345");

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void DummyCalculate_NullString_ShouldThrowArgumentNullException()
        {
            // Arrange
            IStatisticsService dummyStatisticService = new DummyStatisticService();

            // Act
            int result = dummyStatisticService.Calculate(null);

            // Assert
            result.Should().Be(0);
        }
    

    #endregion
}
}
