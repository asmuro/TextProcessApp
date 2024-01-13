using Domain;
using Domain.Classes;
using Domain.Enums;
using Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TextProcessApplicationService : ITextProcessApplicationService
    {
        public IEnumerable<OrderType> GetOrderOptions()
        {
            return Enum.GetValues(typeof(OrderType)).Cast<OrderType>().ToList();
        }

        public string GetOrderedText(string textToOrder, OrderType orderOption)
        {
            var orderService = OrderServiceStrategy.GetOrderService(orderOption);
            return orderService.Order(textToOrder);
        }

        public TextStatistics GetStatistics(string textToAnalyze)
        {
            var textStatistics = new TextStatistics();
            textStatistics.HyphensQuantity = StatisticsServiceStrategy.GetStatisticsService(Statistics.Hyphens).Calculate(textToAnalyze);
            textStatistics.WordQuantity = StatisticsServiceStrategy.GetStatisticsService(Statistics.Word).Calculate(textToAnalyze);
            textStatistics.SpacesQuantity = StatisticsServiceStrategy.GetStatisticsService(Statistics.Spaces).Calculate(textToAnalyze);
            return textStatistics;
        }
    }
}
