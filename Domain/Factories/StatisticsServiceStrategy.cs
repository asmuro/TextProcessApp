using Domain.Classes;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Factories
{
    public static class StatisticsServiceStrategy
    {
        public static IStatisticsService GetStatisticsService(Statistics statistics)
        {
            switch (statistics)
            {
                case Statistics.Hyphens:
                    return new HyphensStatisticService();
                case Statistics.Word:
                    return new WordsStatisticService();
                case Statistics.Spaces: 
                    return new SpacesStatisticService();

                default: 
                    return new DummyStatisticService();
            }
        }
    }
}
