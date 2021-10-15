using System;

namespace CodeEventDojo
{
    internal class EncondingErrorExecutor
    {
        private EncodingErrorValidator validator;
        public EncondingErrorExecutor()
        {
            validator = new EncodingErrorValidator();
        }

        internal long? FindError(long[] streamOfTotalValues, int preambleSize)
        {
            int windowFirstIndex = 0;
            int windowLastIndex = preambleSize;
            long? sumOfPairToValidate;
            long[] windowToValidate;

            do 
            {
                sumOfPairToValidate = streamOfTotalValues[windowLastIndex];
                windowToValidate = streamOfTotalValues[windowFirstIndex..windowLastIndex];

                windowFirstIndex++;
                windowLastIndex++;

                if (this.validator.IsValueTheSumOfPairs(windowToValidate, sumOfPairToValidate.Value)) 
                {
                    sumOfPairToValidate = null;
                }

            } while (!sumOfPairToValidate.HasValue && windowLastIndex < streamOfTotalValues.Length);

            return sumOfPairToValidate;
        }
    }
}