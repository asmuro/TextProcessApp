using Domain.Interfaces;
using System;

namespace Domain.Classes
{
    public class WordsStatisticService : IStatisticsService
    {
        #region IStatisticsService

        public int Calculate(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                return 0;
            }
            
            return CountWords(text);
        }

        public int CountWords(string text)
        {
            char[] punctuationCharacters = text.Where(char.IsPunctuation).Distinct().ToArray();
            var words = text.Split().Select(x => x.Trim(punctuationCharacters));
            return words.Where(x => !string.IsNullOrWhiteSpace(x)).Count();
        }        

        #endregion
    }
}
