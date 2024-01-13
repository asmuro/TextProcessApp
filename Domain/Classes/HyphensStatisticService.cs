using Domain.Interfaces;

namespace Domain.Classes
{
    public class HyphensStatisticService : IStatisticsService
    {
        #region IStatisticsService

        public int Calculate(string text)
        {
            return text.Count(x => x == '-');
        }

        #endregion
    }
}
