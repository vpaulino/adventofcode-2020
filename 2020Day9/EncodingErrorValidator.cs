using System;

namespace CodeEventDojo
{
    public class EncodingErrorValidator {

        private  int preambleSize = 25;

        public bool IsValueTheSumOfPairs(long[] input, long valueToTest) 
        {
            int minIndex = Math.Max(0,input.Length - preambleSize);
            for (int currentIndex = minIndex; currentIndex < input.Length-1; currentIndex++)
            {
                for (int innerCurrentIndex = currentIndex+1; innerCurrentIndex < input.Length; innerCurrentIndex++)
                {
                    if (input[currentIndex] + input[innerCurrentIndex] == valueToTest)
                        return true;
                }    
            }

            return false;
        }
    
    }
}