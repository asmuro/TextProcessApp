using Application.Services;
using Domain.Classes;
using Domain.Enums;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTestProject.Services
{
    internal class TextProcessApplicationServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TextProcessApplicationService_GetOrderOptions_ShouldGetExpectedOrderOptions()
        {
            //Arrange
            var textProcessService = new TextProcessApplicationService();

            //Act
            var orderOptions = textProcessService.GetOrderOptions();

            //Assert
            orderOptions.Count().Should().Be(Enum.GetValues(typeof(OrderType)).Length);            
        }

        [TestCase("Hello World As Is", OrderType.AlphabeticAsc, "As Hello Is World")]
        [TestCase("Performance is better on winter time", OrderType.AlphabeticDesc, "winter time Performance on is better")]
        [TestCase("The leaves are green on the tree", OrderType.LenghtAsc, "on The are the tree green leaves")]
        public void TextProcessApplicationService_GetOrderedText_ReturnsOrderedText(
            string inputText, OrderType orderOption, string expectedResult)
        {
            // Arrange
            TextProcessApplicationService textProcessService = new TextProcessApplicationService();            

            // Act
            string orderedText = textProcessService.GetOrderedText(inputText, orderOption);

            // Assert
            orderedText.Should().BeEquivalentTo(expectedResult);            
        }

        [TestCase("This is a sample text.", 0, 5, 4)]
        [TestCase("Another text with some spaces.", 0, 5, 4)]
        [TestCase("Testing- the hyphens--.", 3, 3, 2)]
        public void GetStatistics_ReturnsTextStatistics(string inputText, int hyphensQuantity, int wordQuantity, int spacesQuantity)
        {
            // Arrange
            TextProcessApplicationService textProcessService = new TextProcessApplicationService();
            
            // Act
            TextStatistics textStatistics = textProcessService.GetStatistics(inputText);

            // Assert
            textStatistics.Should().NotBeNull();
            textStatistics.HyphensQuantity.Should().Be(hyphensQuantity);
            textStatistics.WordQuantity.Should().Be(wordQuantity);
            textStatistics.SpacesQuantity.Should().Be(spacesQuantity);            
        }
    }
}
