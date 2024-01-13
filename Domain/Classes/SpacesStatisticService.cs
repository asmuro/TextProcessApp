using Domain.Interfaces;

namespace Domain.Classes
{
    public class SpacesStatisticService : IStatisticsService
    {
        #region IStatisticsService

        public int Calculate(string text)
        {
            return text.Count(Char.IsWhiteSpace);
        }

        #endregion
    }
}
