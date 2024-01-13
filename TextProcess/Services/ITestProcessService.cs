using Domain.Classes;
using Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TextProcess.Services
{
    public interface ITestProcessService
    {
        Task<string> GetOrderedText(string textToOrder, OrderType orderTypeSelected);

        Task<IEnumerable<OrderType>> GetOrderOptions();

        Task<TextStatistics> GetStatistics(string textToAnalyze);
    }
}
