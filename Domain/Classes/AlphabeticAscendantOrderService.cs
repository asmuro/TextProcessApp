using Domain.Interfaces;

namespace Domain.Classes
{
    public class AlphabeticAscendantOrderService : IOrderService
    {
        #region IOrderService

        string IOrderService.Order(string textToOrder)
        {
            var splittedText = textToOrder.Split(' ').ToList();
            splittedText.Sort();            
            return String.Join(" ", splittedText);
        }

        #endregion
    }
}
