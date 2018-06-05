﻿using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.RacingCards.Interfaces;
using Xunit;

namespace TurtleGame.Domain.RacingCards
{

    public class PreConditionNoMoreThanFourShould: PreconditionShouldBase
    {
        

        public PreConditionNoMoreThanFourShould()
        {
            Sut = new PreConditionNoMoreThanFour();
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        private void Validate_Return_Value(int countOfRaicingCards, bool resultValue)
        {
            var result = Sut.Validate(RacingCards.Create(new List<IRacingCard>(Enumerable.Range(0, countOfRaicingCards)
                .ToList()
                .Select(x => new Mock<IRacingCard>().Object))));

            result.Should().Be(resultValue);
        }
       
    }

}