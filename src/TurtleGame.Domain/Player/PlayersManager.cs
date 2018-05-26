using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player.Players.Interfaces;
using TurtleGame.SharedKernel.Strategies.Interfaces;

namespace TurtleGame.Domain.Player
{
    public class PlayersManager : IPlayersManager
    {
        private readonly IGenericMixStrategy _mixStrategy;
        public IPlayers Players { get; }

        public PlayersManager(IPlayers players,
                              IGenericMixStrategy mixStrategy)
        {
            _mixStrategy = mixStrategy;
            Players = players;
        }
        public IPlayersManager GiveBetCards(IReadOnlyCollection<IBetCard> beatsCards)
        {
            if (beatsCards == null || beatsCards.Count != 5)
                throw new ArgumentException(nameof(beatsCards));

            Players.GiveCards(_mixStrategy.Mix(beatsCards.ToList()).ToList());
            return this;
        }

        /// <summary>
        /// Deal one raicing card to each player
        /// </summary>
        public IPlayersManager GiveRaicingCards()
        {
            for (var i = 0; i < 7; i++)
                Players.TakeCard();
            return this;
        }
    }
}