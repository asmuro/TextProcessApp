using Domain.Interfaces;

namespace Domain.Classes
{
    public class DummyOrderService : IOrderService
    {
        #region IOrderService

        string IOrderService.Order(string textToOrder)
        {
            return textToOrder;
        }

        #endregion
    }
}
