﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventCode2020Day9
{
    public class PartTwoTests
    {

        private long[] GetValuesStream()
        {
            return new long[] { 35
,20
,15
,25
,47
,40
,62
,55
,65
,95
,102
,117
,150
,182
,127
,219
,299
,277
,309
,576};
        }

            [Fact]
        public void WhenSetOfValuesContainMatchWindowSetIsReturned() 
        {
            EncondingErrorExecutor executor = new EncondingErrorExecutor();

            long[] values = GetValuesStream();
             
            long[] windowMatched = executor.FindSetOfValuesToSumUpToValue(values, 127);

                Assert.Collection<long>(windowMatched, 
                  firstElement => Assert.Equal(firstElement, 15)
                , (secondElement) => Assert.Equal(secondElement, 25)
    
                , (thirdElement) => Assert.Equal(thirdElement, 47)
    
                , (fourthElement) => Assert.Equal(fourthElement, 40));

        }

    }
}