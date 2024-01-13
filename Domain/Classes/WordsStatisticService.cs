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

            text = this.NormalizeWhiteSpace(text);
            text = text.Trim();
            return text.Split().Length;
        }

        private string NormalizeWhiteSpace(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            int current = 0;
            char[] output = new char[input.Length];
            bool skipped = false;

            foreach (char c in input.ToCharArray())
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!skipped)
                    {
                        if (current > 0)
                            output[current++] = ' ';

                        skipped = true;
                    }
                }
                else
                {
                    skipped = false;
                    output[current++] = c;
                }
            }

            return new string(output, 0, current);
        }

        #endregion
    }
}
