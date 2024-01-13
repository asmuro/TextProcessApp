using Domain.Classes;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Factories
{
    public static class OrderServiceStrategy
    {
        public static IOrderService GetOrderService(OrderType orderOption)
        {
            switch (orderOption)
            {
                case OrderType.AlphabeticAsc:
                    return new AlphabeticAscendantOrderService();
                case OrderType.AlphabeticDesc:
                    return new AlphabeticDescendantOrderService();
                case OrderType.LenghtAsc: 
                    return new LengthAscendantOrderService();

                default: 
                    return new DummyOrderService();
            }
        }
    }
}
