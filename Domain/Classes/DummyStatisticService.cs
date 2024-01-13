using Domain.Interfaces;
using System;

namespace Domain.Classes
{
    public class DummyStatisticService : IStatisticsService
    {
        #region IStatisticsService

        public int Calculate(string text)
        {
            return 0;
        }

        #endregion
    }
}
