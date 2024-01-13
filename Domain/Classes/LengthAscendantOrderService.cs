using Domain.Interfaces;

namespace Domain.Classes
{
    public class LengthAscendantOrderService : IOrderService
    {
        #region IOrderService

        string IOrderService.Order(string textToOrder)
        {
            string[] splittedText = textToOrder.Split(' ');
            splittedText = splittedText.OrderBy(aux => aux.Length).ToArray();
            return String.Join(" ", splittedText);
        }

        #endregion
    }
}
