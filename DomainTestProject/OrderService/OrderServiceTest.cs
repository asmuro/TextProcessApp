using Domain.Classes;
using Domain.Interfaces;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTestProject.OrderService
{
    public class OrderServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        #region Alphabetic Ascendeant Order Service

        [Test]
        public void Order_EmptyString_ReturnsEmptyString()
        {
            // Arrange
            IOrderService orderService = new AlphabeticAscendantOrderService();

            // Act
            string result = orderService.Order("");

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void Order_SingleWord_ReturnsSameWord()
        {
            // Arrange
            IOrderService orderService = new AlphabeticAscendantOrderService();
            var singleWordText = "Hello";
            // Act
            string result = orderService.Order(singleWordText);

            // Assert
            result.Should().Be(singleWordText);            
        }

        [Test]
        public void Order_MultipleWords_ReturnsWordsInAlphabeticAscendantOrder()
        {
            // Arrange
            IOrderService orderService = new AlphabeticAscendantOrderService();
            var multipleWordText = "Banana Apple Orange";

            // Act
            string result = orderService.Order(multipleWordText);

            // Assert
            result.Should().Be("Apple Banana Orange");            
        }

        [Test]
        public void Order_WordsWithNumbers_ReturnsWordsAndNumbersInAlphabeticAscendantOrder()
        {
            // Arrange
            IOrderService orderService = new AlphabeticAscendantOrderService();
            var multipleWordWithNumbersText = "Banana 123 Apple 456 Orange";

            // Act
            string result = orderService.Order(multipleWordWithNumbersText);

            // Assert
            result.Should().Be("123 456 Apple Banana Orange");
        }

        #endregion

        #region Alphabetical Descendant Order Service

        [Test]
        public void Order_EmptyString_ShouldReturnEmptyString()
        {
            // Arrange
            IOrderService orderService = new AlphabeticDescendantOrderService();

            // Act
            string result = orderService.Order("");

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void Order_SingleWord_ShouldReturnSameWord()
        {
            // Arrange
            IOrderService orderService = new AlphabeticDescendantOrderService();

            // Act
            string result = orderService.Order("Hello");

            // Assert
            result.Should().Be("Hello");
        }

        [Test]
        public void Order_MultipleWords_ShouldReturnWordsInAlphabeticDescendantOrder()
        {
            // Arrange
            IOrderService orderService = new AlphabeticDescendantOrderService();

            // Act
            string result = orderService.Order("Banana Apple Orange");

            // Assert
            result.Should().Be("Orange Banana Apple");
        }

        [Test]
        public void Order_WordsWithNumbers_ShouldReturnWordsAndNumbersInAlphabeticDescendantOrder()
        {
            // Arrange
            IOrderService orderService = new AlphabeticDescendantOrderService();

            // Act
            string result = orderService.Order("Banana 123 Apple 456 Orange");

            // Assert
            result.Should().Be("Orange Banana Apple 456 123");
        }

        #endregion

        #region Length Ascendant Order Service

        [Test]
        public void LengthAscendantOrder_EmptyString_ShouldReturnEmptyString()
        {
            // Arrange
            IOrderService orderService = new LengthAscendantOrderService();

            // Act
            string result = orderService.Order("");

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void LengthAscendantOrder_SingleWord_ShouldReturnSameWord()
        {
            // Arrange
            IOrderService orderService = new LengthAscendantOrderService();

            // Act
            string result = orderService.Order("Hello");

            // Assert
            result.Should().Be("Hello");
        }

        [Test]
        public void LengthAscendantOrder_MultipleWords_ShouldReturnWordsInLengthAscendantOrder()
        {
            // Arrange
            IOrderService orderService = new LengthAscendantOrderService();

            // Act
            string result = orderService.Order("Banana Apple Orange");

            // Assert
            result.Should().Be("Apple Banana Orange");
        }

        [Test]
        public void LengthAscendantOrder_WordsWithNumbers_ShouldReturnWordsAndNumbersInLengthAscendantOrder()
        {
            // Arrange
            IOrderService orderService = new LengthAscendantOrderService();

            // Act
            string result = orderService.Order("Banana 123 Apple 456 Orange");

            // Assert
            result.Should().Be("123 456 Apple Banana Orange");
        }

        #endregion

        #region Dummy Order Service

        [Test]
        public void DummyOrder_EmptyString_ShouldReturnEmptyString()
        {
            // Arrange
            IOrderService orderService = new DummyOrderService();

            // Act
            string result = orderService.Order("");

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void DummyOrder_SingleWord_ShouldReturnSameWord()
        {
            // Arrange
            IOrderService orderService = new DummyOrderService();

            // Act
            string result = orderService.Order("Hello");

            // Assert
            result.Should().Be("Hello");
        }

        [Test]
        public void DummyOrder_MultipleWords_ShouldReturnSameText()
        {
            // Arrange
            IOrderService orderService = new DummyOrderService();

            // Act
            string result = orderService.Order("Banana Apple Orange");

            // Assert
            result.Should().Be("Banana Apple Orange");
        }

        [Test]
        public void DummyOrder_WordsWithNumbers_ShouldReturnSameText()
        {
            // Arrange
            IOrderService orderService = new DummyOrderService();

            // Act
            string result = orderService.Order("Banana 123 Apple 456 Orange");

            // Assert
            result.Should().Be("Banana 123 Apple 456 Orange");
        }

        #endregion


    }
}
