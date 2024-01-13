using Domain;
using Domain.Classes;
using Domain.Enums;

namespace Application.Services
{
    public interface ITextProcessApplicationService
    {
        IEnumerable<OrderType> GetOrderOptions();        

        string GetOrderedText(string textToOrder, OrderType orderOption);        

        TextStatistics GetStatistics(string textToAnalyze);
        
    }
}