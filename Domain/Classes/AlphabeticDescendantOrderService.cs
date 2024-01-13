using Domain.Interfaces;

namespace Domain.Classes
{
    public class AlphabeticDescendantOrderService : IOrderService
    {
        #region IOrderService

        string IOrderService.Order(string textToOrder)
        {
            var splittedText = textToOrder.Split(' ').ToList();
            var descendingOrder = splittedText.OrderByDescending(i => i);            
            return String.Join(" ", descendingOrder);            
        }

        #endregion
    }
}
