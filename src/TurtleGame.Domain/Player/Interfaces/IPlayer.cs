﻿using System;
using System.Collections.Generic;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Player.Interfaces
{
    public interface IPlayer
    {
        int BetCardsQuantity { get; }
        void GiveCard(IBetCard betCard);
        void ChooseSecondBet();

        IReadOnlyCollection<IRacingCard> RacingCards { get; }
        void TakeRacingCard();
        ISideBoderSelected ChooseSideOfTrack(ITrack track);
        bool CardsTurn(Func<IReadOnlyCollection<IRacingCard>, bool> selectedCardsConfirmation);
    }
}